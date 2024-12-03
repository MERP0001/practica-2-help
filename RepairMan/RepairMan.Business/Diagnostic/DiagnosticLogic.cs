using Microsoft.EntityFrameworkCore;
using RepairMan.DataAccess;
using RepairMan.DataClasses.Repairing.Diagnostic;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;

namespace RepairMan.Business
{
    public class DiagnosticLogic : IDiagnosticLogic
    {
        private readonly RepairManContext _context;
        public int Confidence = 50;
        private readonly IQueryable<Diagnostic> _diagnostics;
        private readonly IQueryable<Question> _questions;
        private readonly IQueryable<Pronostic> _pronostics;
        

        public DiagnosticLogic(RepairManContext context)
        {
            _context = context;
            _diagnostics = _context.Diagnostics.Include(x => x.Answers).Include(x => x.Pronostic).AsNoTracking();
            _questions = _context.Questions.AsNoTracking();
            _pronostics = _context.Pronostics.Include(x => x.Questions).ThenInclude(x => x.Question).AsNoTracking();
        }

        public Diagnostic StartDiagnostic()
        {
            var diagnostic = new Diagnostic { Date = DateTime.UtcNow, Answers = new List<Answer>() };
            _context.Add(diagnostic);
            _context.SaveChanges();

            return diagnostic;
        }

        public Diagnostic GetDiagnostic(Guid diagnosticId)
        {
            var diagnostic = _diagnostics.FirstOrDefault(x => x.DiagnosticId == diagnosticId);
            if (diagnostic == null)
            {
                return null;
            } 
            diagnostic.Answers ??= new List<Answer>();
            return diagnostic;
        }

        public Diagnostic SaveDiagnostic(Diagnostic diagnostic)
        {
            _context.Update(diagnostic);
            _context.SaveChanges();
            return diagnostic;
        }
        
        public double GetDiagnosticConfidence(Diagnostic diagnostic)
        {
            if (diagnostic.Pronostic == null || !diagnostic.Answers.Any())
            {
                return 0;
            }

            var questions = diagnostic.Pronostic.Questions.ToList();
            var answers = diagnostic.Answers.ToList();
            var questionsCount = questions.Count;
            var coincidentalQuestions = questions.Count(x => answers.Any(z => x.QuestionId == z.QuestionId));
            return coincidentalQuestions / questionsCount * 100;
        }

        public Diagnostic ComputeDiagnostic(Diagnostic diagnostic)
        {
            diagnostic.Pronostic = GetFactiblePronostics(diagnostic.Answers).FirstOrDefault();
            diagnostic.Confidence = GetDiagnosticConfidence(diagnostic);
            SaveDiagnostic(diagnostic);
            return diagnostic;
        }

        public IEnumerable<Pronostic> GetCoincidentalPronostics(IEnumerable<Pronostic> pronostics, Answer answer)
        {
            if(answer.Response)
            {
                return pronostics.Where(pronostic => pronostic.Questions.Any(question => question.QuestionId == answer.QuestionId));
            }

            return pronostics.Where(pronostic => !pronostic.Questions.Any(question => question.QuestionId == answer.QuestionId));
        }

        public Dictionary<Pronostic, decimal> GetCoincidentalPronostics(IEnumerable<Pronostic> pronostics, IEnumerable<Answer> answers)
        {
            Dictionary<Pronostic, decimal> pronosticConfidence = new Dictionary<Pronostic, decimal>();
            foreach (var pronostic in pronostics)
            {
                pronosticConfidence.Add(pronostic, 0);
                pronosticConfidence[pronostic] = pronostic.Questions.Count(question => answers.Any(answer => answer.AnswerId == question.QuestionId)) / pronostic.Questions.Count();
            }
            return pronosticConfidence;
        }

        public IEnumerable<Pronostic> GetFactiblePronostics(IEnumerable<Answer> answers)
        {
            IEnumerable<Pronostic> moreFactiblePronostic = _pronostics.Include(x => x.Questions);
            for (var i = 0; i < answers.Count(); i++)
            {
                moreFactiblePronostic = GetCoincidentalPronostics(moreFactiblePronostic, answers.ElementAt(i));
            }
            return moreFactiblePronostic;
        }

        public IEnumerable<Question> GetNextQuestions(IEnumerable<Answer> answers = null)
        {
            if (answers == null || !answers.Any())
            {
                var rand = new Random();
                return _questions.Where(x => x.IsInitial);
            }

            IEnumerable<Pronostic> factiblePronostics = GetFactiblePronostics(answers);
            if (!factiblePronostics.Any())
            {
                return null;
            }

            var lastLogicPronostic = factiblePronostics.First();
            var questionsNotAnswered = lastLogicPronostic.Questions.Where(question => !answers.Any(answer => answer.QuestionId == question.QuestionId)).ToList();
            return _questions.ToList().Where(x => questionsNotAnswered.Any(z => x.QuestionId == z.QuestionId));
        }
    }
}

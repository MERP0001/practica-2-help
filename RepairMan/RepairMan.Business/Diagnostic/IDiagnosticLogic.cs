using RepairMan.DataClasses.Repairing.Diagnostic;
using System;
using System.Collections.Generic;

namespace RepairMan.Business
{
    public interface IDiagnosticLogic
    {
        Diagnostic ComputeDiagnostic(Diagnostic diagnostic);
        IEnumerable<Pronostic> GetCoincidentalPronostics(IEnumerable<Pronostic> pronostics, Answer answer);
        Dictionary<Pronostic, decimal> GetCoincidentalPronostics(IEnumerable<Pronostic> pronostics, IEnumerable<Answer> answers);
        Diagnostic GetDiagnostic(Guid DiagnosticId);
        IEnumerable<Pronostic> GetFactiblePronostics(IEnumerable<Answer> answers = null);
        IEnumerable<Question> GetNextQuestions(IEnumerable<Answer> answers = null);
        Diagnostic SaveDiagnostic(Diagnostic diagnostic);
        Diagnostic StartDiagnostic();
    }
}
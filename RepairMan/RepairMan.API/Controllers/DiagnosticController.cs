using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepairMan.Business;
using RepairMan.DataClasses.Repairing.Diagnostic;

namespace RepairMan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosticController : ControllerBase
    {
        private readonly IDiagnosticLogic _diagnosticLogic;

        public DiagnosticController(IDiagnosticLogic diagnosticLogic)
        {
            _diagnosticLogic = diagnosticLogic;
        }

        [HttpPost]
        public IActionResult StartDiagnostic()
        {
            return Ok(_diagnosticLogic.StartDiagnostic());
        }

        [HttpGet("{id}")]
        public IActionResult GetDianostic(Guid id)
        {
            var diagnostic = _diagnosticLogic.GetDiagnostic(id);
            if(diagnostic != null)
            {
                return NotFound();
            }
            return Ok(diagnostic);
        }

        [HttpGet("{id}/answers")]
        public IActionResult GetAnswers(Guid id)
        {
            var diagnostic = _diagnosticLogic.GetDiagnostic(id);
            if (diagnostic == null)
            {
                return NotFound();
            }
            return Ok(diagnostic.Answers);
        }

        [HttpGet("{id}/pronostic")]
        public IActionResult GetPronostic(Guid id)
        {
            var diagnostic = _diagnosticLogic.GetDiagnostic(id);
            if (diagnostic == null)
            {
                return NotFound();
            }
            _diagnosticLogic.ComputeDiagnostic(diagnostic);
            if(diagnostic.Pronostic == null)
            {
                return NotFound();
            } 
            return Ok(diagnostic.Pronostic);
        }

        [HttpPost("{id}/answers")]
        public IActionResult AnswerQuestion(Guid id, Answer answer)
        {
            var diagnostic = _diagnosticLogic.GetDiagnostic(id);
            if (diagnostic == null)
            {
                return NotFound();
            }
           
            diagnostic.Answers.Add(answer);
            _diagnosticLogic.SaveDiagnostic(diagnostic);
            return Ok(answer);
        }

        [HttpGet("{id}/questions/next")]
        public IActionResult GetNextQuestions(Guid id)
        {
            var diagnostic = _diagnosticLogic.GetDiagnostic(id);
            if (diagnostic == null)
            {
                return NotFound();
            }

            var questions = _diagnosticLogic.GetNextQuestions(diagnostic.Answers);
            if(questions == null)
            {
                return NotFound();
            }
            return Ok(questions);
        }
    }
}
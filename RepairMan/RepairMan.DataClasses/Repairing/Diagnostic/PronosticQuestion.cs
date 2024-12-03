using System;
using System.Collections.Generic;
using System.Text;

namespace RepairMan.DataClasses.Repairing.Diagnostic
{
    public class PronosticQuestion
    {
        public Guid PronosticQuestionId { get; set; }

        public Guid PronosticId { get; set; }

        public Pronostic Pronostic { get; set; }

        public Guid QuestionId { get; set; }

        public Question Question { get; set; }
    }
}

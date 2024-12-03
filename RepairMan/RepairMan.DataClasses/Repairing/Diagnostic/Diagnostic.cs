using System;
using System.Collections.Generic;
using System.Text;

namespace RepairMan.DataClasses.Repairing.Diagnostic
{
    public class Diagnostic
    {
        /// <summary>
        /// Identificacion de diagnostico
        /// </summary>
        public Guid DiagnosticId { get; set; }

        /// <summary>
        /// Respuestas al diagnostico
        /// </summary>
        public IList<Answer> Answers { get; set; } = new List<Answer>();

        /// <summary>
        /// Pronostico final del diagnostico
        /// </summary>
        /// 
        public Guid? PronosticId { get; set; }
        public Pronostic Pronostic { get; set; }


        public double Confidence { get; set; }
        /// <summary>
        /// Fecha del diagnostico
        /// </summary>
        public DateTime Date { get; set; }
    }
}

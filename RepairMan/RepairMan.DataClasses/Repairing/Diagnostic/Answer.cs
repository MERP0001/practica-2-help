using System;

namespace RepairMan.DataClasses.Repairing.Diagnostic
{
    public class Answer
    {
        /// <summary>
        /// Identificacion de la respuesta
        /// </summary>
        public Guid AnswerId { get; set; }

        /// <summary>
        /// Pregunta a la que esta asociada la respuesta.
        /// </summary>
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }

        public Guid DiagnosticId { get; set; }
        public Diagnostic Diagnostic { get; set; }
        /// <summary>
        /// Respuesta del booleano Si : No
        /// </summary>
        public bool Response { get; set; }
    }
}
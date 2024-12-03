using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepairMan.DataClasses.Repairing.Diagnostic
{
    public class Question
    {
        /// <summary>
        /// Identificacion de la pregunta
        /// </summary>
        public Guid QuestionId { get; set; }

        /// <summary>
        /// Texto de la pregunta
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Respuesta afirmativa, por lo general deberia ser "Si"
        /// </summary>
        public string AffirmativeAnswer { get; set; }


        /// <summary>
        /// Respuesta negativa, por lo general deberia ser "No"
        /// </summary>
        public string NegativeAnswer { get; set; }

        /// <summary>
        /// Es una pregunta inicial?
        /// </summary>
        public bool IsInitial { get; set; }
    }
}

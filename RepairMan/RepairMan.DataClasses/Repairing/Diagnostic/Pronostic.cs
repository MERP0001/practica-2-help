using System;
using System.Collections.Generic;
using System.Text;

namespace RepairMan.DataClasses.Repairing.Diagnostic
{
    public class Pronostic
    {
        /// <summary>
        /// Identificacion del pronostico
        /// </summary>
        public Guid PronosticId { get; set; }

        /// <summary>
        /// Nombre del pronostico
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descripcion del pronostico
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Preguntas afirmativas associadas al pronostico
        /// </summary>
        public IEnumerable<PronosticQuestion> Questions { get; set; } = new List<PronosticQuestion>();

    }
}

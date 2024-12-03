using RepairMan.DataClasses.Motoring;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace RepairMan.DataClasses.Common
{
    public class User
    {
        /// <summary>
        /// Identificacion del usuario
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Nombre de acceso del usuario (Generalmente el correo electronico)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Clave encriptada
        /// </summary>
        [JsonIgnore]
        public string Password { get; set; }

        /// <summary>
        /// Estado del usuario.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Informacion de contacto
        /// </summary>
        /// 
        public Guid ContactId { get; set; }
        public Contact Contact { get; set; }

        /// <summary>
        /// Fecha de creacion
        /// </summary>
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public IList<Vehicle> Vehicles { get; set; }

        public List<string> Roles { get; set; } = new List<string>();
    }
}

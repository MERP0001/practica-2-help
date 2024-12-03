using RepairMan.DataClasses.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepairMan.DataClasses.Motoring
{
    public class Vehicle
    {
        /// <summary>
        /// Identificacion del Vehiculo
        /// </summary>
        public Guid VehicleId { get; set; }

        /// <summary>
        /// Fecha de salida del vehiculo
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Color del vehiculo
        /// </summary>
        public string Color { get; set; }


        public Guid UserId { get; set; }
        public User User { get; set; } 

        /// <summary>
        /// Modelo del vehiculo
        /// </summary>
        public Guid ModelId { get; set; }
        public Model Model { get; set; }

    }
}

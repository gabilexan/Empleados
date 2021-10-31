using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Empleados.Models
{
    public partial class Empleado
    {
        public int Idempleado { get; set; }
        [Display(Name = "Nombre")]
        [RegularExpression(@"[a-zA-Z\s]", ErrorMessage = "Introduzca un nombre  válido")]
        [StringLength(100, ErrorMessage = "Longitud maxima 100")]
        [Required]
        public string NombreEmpleado { get; set; }
        [Display(Name = "Apellido")]
        [RegularExpression(@"[a-zA-Z\s]", ErrorMessage = "Introduzca un apellido  válido")]
        [StringLength(100, ErrorMessage = "Longitud maxima 100")]
        [Required]
        public string ApellidoEmpleado { get; set; }
        [Display(Name = "Telefono")]
        [StringLength(20, ErrorMessage = "Longitud maxima 20")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Formato de  telefono no válido")]
        [Required]
        public string TelefonoEmpleado { get; set; }
        [Display(Name = "Email")]
        [Required]
        [StringLength(200, ErrorMessage = "Longitud maxima 200")]
        [EmailAddress(ErrorMessage = "Ingrese un email válido")]
        public string CorreoEmpleado { get; set; }
        [Required]
        [Display(Name = "File")]
        public byte[] Foto { get; set; }
        [Display(Name = "Fecha Contrato ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        [Required]
        public DateTime FechaContratacion { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesarrolloIntegral.Shared.Models
{
    public class PerfilUsuario
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del perfil")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede contener más de {1} caracteres.")]

        public string? Nombre { get; set; }

        public int Estado { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM.Models
{
   
    public class Usuario
    {
        public int ID{ get; set; }
     
        [Required(ErrorMessage = "Usuario Requerido.")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "Contraseña  Requerida.")]
        public string Password { get; set; }
        public string Tipo { get; set; }
    }
    
    }
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM.Models
{
   
    public class Contacto
    {
     
     public int ID{get; set;}
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
      
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
        public string Puesto { get; set; }

        public virtual  Cliente cliente { get; set; }
        [Display(Name = "Cliente")]
        public int IDCliente{get; set;}
        public  virtual Usuario usuario{get; set;}
        
        public int IDUsuario{get;set;}
    }
}
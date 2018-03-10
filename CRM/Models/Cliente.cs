using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM.Models
{
   
    public class Cliente
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

         [Display(Name = "Cédula")]
        public string Cedula { get; set; }
        
        [Display(Name = "Página web")]
        public string Pagina_Web { get; set; }
         
        [Display(Name = " Dirección")]
        public string Direccion { get; set; }
        
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
        public string Sector { get; set; }
         public  virtual Usuario usuario{get; set;}
        
        public int IDUsuario{get;set;}

    }
    }
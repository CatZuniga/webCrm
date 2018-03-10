
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM.Models
{
   
    public class Ticket
    {
     
    
        public int ID { get; set; }
        
         [Display(Name = "Título")]
        public string Titulo { get; set; }
        public string Detalle { get; set; }
           [Display(Name ="Quien reportó el problema")]
        public string Quien_reporto { get; set; }
         [Display(Name ="Estado actual")]
        public string Estado_Actual { get; set; }
        public virtual  Cliente cliente { get; set; }
        public int IDCliente{get; set;}
        public  virtual Usuario usuario{get; set;}
        
        public int IDUsuario{get;set;}        
    }
}
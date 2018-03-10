
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM.Models
{
   
    public class Reunion
    {
     
        public int ID { get; set; }
        public string Titulo { get; set; }

  [Display(Name = "Día y Hora"), DataType(DataType.Date)]
    public DateTime DiaHora { get; set; }
        
       
         [Display(Name = "Es virtual")]
        public bool Virtual { get; set; }

    public virtual  Cliente cliente { get; set; }
        public int IDCliente{get; set;}
        public  virtual Usuario usuario{get; set;}
        
        public int IDUsuario{get;set;}
   
   }
    }
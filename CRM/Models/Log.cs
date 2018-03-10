using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRM.Models;
using Microsoft.AspNetCore.Http;
using System.Web;


namespace CRM.Models
{

    public class Log
    {

        public static bool logged = false;
        public Log()
        {

        }
        public static bool Login(Usuario user)
        {

            if (user != null)
            {
                return logged = true;

            }

            return logged = false;

        }


    }
}



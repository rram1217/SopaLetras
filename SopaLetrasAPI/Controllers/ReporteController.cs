using SopaLetrasAPI.Data;
using SopaLetrasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SopaLetrasAPI.Controllers
{
    public class ReporteController : ApiController
    {
        // GET api/<controller>
        public Cuenta Get()
        {
            return ReporteData.Report();
        }
    }
}
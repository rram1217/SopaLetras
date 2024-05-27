using SopaLetrasAPI.Models;
using SopaLetrasAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SopaLetrasAPI.Controllers
{
    public class ContieneNombreController : ApiController
    {
        //private readonly BusquedaPalabra buscarPalabra;
        //public ContieneNombreController(BusquedaPalabra buscarPalabra)
        //{
        //    this.buscarPalabra = buscarPalabra;
        //}



        // POST api/<controller>
        public Respuesta Post([FromBody] Sopa sopa)
        {
            BusquedaPalabra buscarPalabra = new BusquedaPalabra();            
            return buscarPalabra.Buscar(sopa);
        }

    }
}
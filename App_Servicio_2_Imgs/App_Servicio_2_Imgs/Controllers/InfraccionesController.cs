using App_Servicio_2_Imgs.Clases;
using App_Servicio_2_Imgs.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace App_Servicio_2_Imgs.Controllers
{
    [RoutePrefix("api/Infraccion")]
    public class InfraccionesController : ApiController
    {
        [HttpGet]
        [Route("ConsultarImagenes")]
        public IQueryable ConsultarImagenes(string Placa)
        {
            clsInfraccion infraccion = new clsInfraccion();
            return infraccion.ConsultarImagenesXInfraccion(Placa);
        }
        [HttpDelete]
        [Route("EliminarImagen")]
        public string EliminarImagen(int idFoto)
        {
            clsFotoInfraccion foto = new clsFotoInfraccion();
            return foto.Borrar(idFoto);
        }
        [HttpGet]
        [Route("Consultar")]
        public Infraccion Consultar(string Placa)
        {
            clsInfraccion infraccion = new clsInfraccion();
            return infraccion.Consultar(Placa);
        }
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Infraccion infraccion)
        {
            clsInfraccion Infraccion = new clsInfraccion();
            Infraccion.infraccion  = infraccion;
            return Infraccion.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Infraccion infraccion)
        {
            clsInfraccion Infraccion = new clsInfraccion();
            Infraccion.infraccion = infraccion;
            return Infraccion.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(string Placa)
        {
            clsInfraccion Infraccion = new clsInfraccion();
            return Infraccion.Borrar(Placa);
        }
        [HttpPost]
        [Route("InsertarVehiculo")]
        public string InsertarVehiculo([FromBody] Vehiculo vehiculo)
        {
            clsVehiculo Vehiculo = new clsVehiculo();
            Vehiculo.vehiculo = vehiculo;
            return Vehiculo.Insertar();
        }
    }
}
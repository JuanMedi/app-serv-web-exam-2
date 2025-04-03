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
        [HttpGet]
        [Route("Consultar")]
        public Infraccion Consultar(string Placa)
        {
            clsInfraccion infraccion = new clsInfraccion();
            return infraccion.Consultar(Placa);
        }
        [HttpGet]
        [Route("ConsultarMultasPorPlaca")]
        public List<object> ConsultarMultasPorPlaca(string placa)
        {
            clsInfraccion infraccion = new clsInfraccion();
            return infraccion.ConsultarMultasPorPlaca(placa);
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

        [HttpDelete]
        [Route("EliminarImagenesPorInfraccion")]
        public string EliminarImagenesPorInfraccion(int idFotoMulta)
        {
            clsFotoInfraccion foto = new clsFotoInfraccion();
            return foto.BorrarImagenesPorInfraccion(idFotoMulta);
        }

        [HttpPost]
        [Route("Insertar")]
        public string InsertaryValidar([FromBody] Infraccion infraccion)
        {
            if (infraccion == null || string.IsNullOrEmpty(infraccion.PlacaVehiculo))
            {
                return "Error: Datos inválidos";
            }

            clsInfraccion Infraccion = new clsInfraccion();
            using (var db = new DBExamenEntities())
            {
                bool placaExiste = db.Infraccions.Any(i => i.PlacaVehiculo == infraccion.PlacaVehiculo);

                if (placaExiste)
                {
                    return "Error: La infracción con esta placa ya existe.";
                }
            }
            Infraccion.infraccion = infraccion;
            return Infraccion.Insertar();
        }
    }
}
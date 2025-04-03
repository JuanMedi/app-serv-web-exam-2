using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using App_Servicio_2_Imgs.Models;

namespace App_Servicio_2_Imgs.Clases
{
    public class clsInfraccion
    {
        private DBExamenEntities dbinfraccion = new DBExamenEntities();
        public Infraccion infraccion { get; set; }

        public string Insertar()
        {
            try
            {
                dbinfraccion.Infraccions.Add(infraccion);
                dbinfraccion.SaveChanges();
                return "Infraccion insertada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar la Infraccion: " + ex.Message;
            }
        }

        public Infraccion Consultar(string Placa)
        {
            Infraccion inf = dbinfraccion.Infraccions.Where(e => e.PlacaVehiculo == infraccion.PlacaVehiculo).First();
            return inf;
        }

        public string Actualizar()
        {
            Infraccion inf = Consultar(infraccion.PlacaVehiculo);
            if (inf == null)
            {
                return "Infraccion no existe";
            }
            dbinfraccion.Infraccions.AddOrUpdate(infraccion);
            dbinfraccion.SaveChanges();
            return "Infraccion actualizada correctamente";
        }

        public string Borrar(string Placa)
        {
            Infraccion inf = Consultar(Placa);
            if (inf == null)
            {
                return "Infraccion no existe";
            }
            dbinfraccion.Infraccions.Remove(inf);
            dbinfraccion.SaveChanges();
            return "Infraccion eliminada correctamente";
        }

        public IQueryable ConsultarImagenesXInfraccion(string Placa)
        {
            return from I in dbinfraccion.Set<Infraccion>()
                   join V in dbinfraccion.Set<Vehiculo>()
                   on I.PlacaVehiculo equals V.Placa
                   join Im in dbinfraccion.Set<FotoInfraccion>()
                   on I.idFotoMulta equals Im.idFoto
                   where I.PlacaVehiculo == Placa
                   orderby Im.NombreFoto
                   select new
                   {
                       Placa = V.Placa,
                       Vehiculo = V.Marca,
                       idFotoMulta = Im.idFoto,
                       Infraccion = I.idFotoMulta,
                       idImagen = Im.idFoto,
                       Imagen = Im.NombreFoto
                   };
        }
    }
}

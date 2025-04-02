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

        public Infraccion Consultar(int IdFotoMulta)
        {
            Infraccion inf = dbinfraccion.Infraccions.Where(e => e.idFotoMulta == infraccion.idFotoMulta).First();
            return inf;
        }

        public string Actualizar()
        {
            Infraccion inf = Consultar(infraccion.idFotoMulta);
            if (inf == null)
            {
                return "Infraccion no existe";
            }
            dbinfraccion.Infraccions.AddOrUpdate(infraccion);
            dbinfraccion.SaveChanges();
            return "Infraccion actualizada correctamente";
        }

        public string Borrar()
        {
            Infraccion inf = Consultar(infraccion.idFotoMulta);
            if (inf == null)
            {
                return "Infraccion no existe";
            }
            dbinfraccion.Infraccions.Remove(inf);
            dbinfraccion.SaveChanges();
            return "Infraccion eliminada correctamente";
        }
}
}

using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using App_Servicio_2_Imgs.Models;

namespace App_Servicio_2_Imgs.Clases
{
    public class clsFotoInfraccion
    {
        private DBExamenEntities dbfoto = new DBExamenEntities();
        public FotoInfraccion foto { get; set; }
        public string Insertar()
        {
            try
            {
                dbfoto.FotoInfraccions.Add(foto);
                dbfoto.SaveChanges();
                return "Foto insertada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar la foto: " + ex.Message;
            }
        }
        public FotoInfraccion Consultar(int IdFoto)
        {
            FotoInfraccion fot = dbfoto.FotoInfraccions.Where(e => e.idFoto == foto.idFoto).First();
            return fot;
        }
        public string Actualizar()
        {
            FotoInfraccion fot = Consultar(foto.idFoto);
            if (fot == null)
            {
                return "Foto no existe";
            }
            dbfoto.FotoInfraccions.AddOrUpdate(foto);
            dbfoto.SaveChanges();
            return "Foto actualizada correctamente";
        }
        public string Borrar()
        {
            FotoInfraccion fot = Consultar(foto.idFoto);
            if (fot == null)
            {
                return "Foto no existe";
            }
            dbfoto.FotoInfraccions.Remove(fot);
            dbfoto.SaveChanges();
            return "Foto eliminada correctamente";
        }

    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;
using App_Servicio_2_Imgs.Models;

namespace App_Servicio_2_Imgs.Clases
{
    public class clsFotoInfraccion
    {
        private DBExamenEntities dbfoto = new DBExamenEntities();
        public FotoInfraccion foto { get; set; }

        public string idFotoMulta { get; set; }
        
        public List<string> Archivos { get; set; }  

        public string GuardarImagenes()
        {
            try
            {

                if (Archivos.Count > 0)
                {
                    foreach (string archivo in Archivos)
                    {
                        FotoInfraccion Imagen = new FotoInfraccion();
                        Imagen.idFotoMulta = Convert.ToInt32(idFotoMulta);
                        Imagen.NombreFoto  = archivo;
                        dbfoto.FotoInfraccions.Add(Imagen);
                        dbfoto.SaveChanges();
                    }
                    return "Imagenes guardadas correctamente";
                } else
                {
                    return "No se enviaron los Archivos para guardar";
                }

            } catch
            {
                return "No se enviaron los Archivos para guardar";
            }
        }

        public string BorrarImagenesPorInfraccion(int idFotoMulta)
        {
            try
            {
                var imagenes = dbfoto.FotoInfraccions.Where(f => f.idFotoMulta == idFotoMulta).ToList();

                if (!imagenes.Any())
                {
                    return "No hay imágenes asociadas a esta infracción.";
                }

                string ruta = HttpContext.Current.Server.MapPath("~/Archivos");

                foreach (var imagen in imagenes)
                {
                    string archivo = Path.Combine(ruta, imagen.NombreFoto);
                    if (File.Exists(archivo))
                    {
                        File.Delete(archivo);
                    }
                    dbfoto.FotoInfraccions.Remove(imagen);
                }

                dbfoto.SaveChanges();
                return "Imágenes eliminadas correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al eliminar imágenes: " + ex.Message;
            }
        }


    }
}
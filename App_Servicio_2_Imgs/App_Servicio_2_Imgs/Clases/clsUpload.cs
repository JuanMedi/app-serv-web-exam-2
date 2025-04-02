using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Http;
using System.IO;

namespace App_Servicio_2_Imgs.Clases
{
    public class clsUpload
    {
        public HttpRequestMessage request { get; set; }
        public string Datos { get; set; }
        public string Proceso { get; set; }
        private List<string> Archivos { get; set; }
        public async Task<HttpResponseMessage> GrabarArchivo()
        {
            if (!request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/Archivos");
            List<string> Archivos = new List<string>();
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                await request.Content.ReadAsMultipartAsync(provider);
                foreach (MultipartFileData file in provider.FileData)
                {
                    string fileName = file.Headers.ContentDisposition.FileName;
                    if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
                    {
                        fileName = fileName.Trim('"');
                    }
                    if (fileName.Contains(@"/") || fileName.Contains(@"\"))
                    {
                        fileName = Path.GetFileName(fileName);
                    }
                    if (File.Exists(Path.Combine(root, fileName)))
                    {
                        File.Delete(file.LocalFileName);
                        return request.CreateErrorResponse(HttpStatusCode.Conflict, "El archivo ya existe");
                    }
                    
                    Archivos.Add(fileName);

                    File.Move(file.LocalFileName, Path.Combine(root, fileName));

                }
                string Respuesta = ProcesarArchivo(Archivos);
                return request.CreateResponse(HttpStatusCode.OK, "Archivos subidos correctamente");
            }
            catch (System.Exception e)
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error al cargar el archivo: " + e);
            }

        }

        private string ProcesarArchivo(List<string> Archivos)
        {
            switch (Proceso.ToUpper())
            {
                case "INFRACCION":
                    clsFotoInfraccion foto = new clsFotoInfraccion();
                    foto.Archivos = Archivos;
                    return foto.GuardarImagenes();
                default:
                    return "Proceso no encontrado";
            }


        }
    }
}
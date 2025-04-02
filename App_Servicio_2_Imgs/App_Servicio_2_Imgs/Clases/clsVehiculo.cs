using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using App_Servicio_2_Imgs.Models;

namespace App_Servicio_2_Imgs.Clases
{
    public class clsVehiculo
    {
        private DBExamenEntities dbvehiculo = new DBExamenEntities();
        public Vehiculo vehiculo { get; set; }

        public string Insertar()
        {
            try
            {
                dbvehiculo.Vehiculoes.Add(vehiculo);
                dbvehiculo.SaveChanges();
                return "Vehiculo insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el vehiculo: " + ex.Message;
            }
        }

        public Vehiculo Consultar(string Placa)
        {
            Vehiculo ve = dbvehiculo.Vehiculoes.Where(e => e.Placa == vehiculo.Placa).First();
            return ve;
        }

        public string Actualizar()
        {
            Vehiculo veh = Consultar(vehiculo.Placa);
            if (veh == null)
            {
                return "Vehiculo no existe";
            }
            dbvehiculo.Vehiculoes.AddOrUpdate(vehiculo);
            dbvehiculo.SaveChanges();
            return "Vehiculo actualizado correctamente";
        }

        public string Borrar()
        {
            Vehiculo veh = Consultar(vehiculo.Placa);
            if (veh == null)
            {
                return "Vehiculo no existe";
            }
            dbvehiculo.Vehiculoes.Remove(veh);
            dbvehiculo.SaveChanges();
            return "Vehiculo eliminado correctamente";
        }
    }
}
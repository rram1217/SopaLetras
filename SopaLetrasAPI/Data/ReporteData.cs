using SopaLetrasAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SopaLetrasAPI.Data
{
    public class ReporteData
    {
        public static Cuenta Report()
        {
            Cuenta cuenta = new Cuenta();
            using (SqlConnection connection = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("reporte_cuenta", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cuenta = new Cuenta()
                            {
                                cuenta_contieneNombre = Convert.ToInt32(reader["contieneNombre"]),
                                cuenta_noContieneNombre = Convert.ToInt32(reader["noContieneNombre"]),
                                relacion = Convert.ToDouble(reader["relacion"])

                            };
                        }
                    }

                    return cuenta;
                }
                catch (Exception)
                {
                    return cuenta;
                }
            }
        }
    }
}
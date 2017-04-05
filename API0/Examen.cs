using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API0
{
    public class Examen
    {
        public static string InsertExamen(string desc, string nombre, int ID_Certificador, int tiempo, int ID_Tipo_Examen, string Url)
        {
            string con = ConfigurationManager.ConnectionStrings["Preparate"].ToString();
            Parameter[] p = new Parameter[] {

                 new Parameter("@Desc", desc),
                 new Parameter("@Nombre", nombre),
                 new Parameter("@ID_Certificador", ID_Certificador),
                 new Parameter("@Tiempo_Sugerido", tiempo),
                 new Parameter("@ID_Tipo_Examen", ID_Tipo_Examen),
                 new Parameter("@url_oficial", Url)
            };
            return Utilities.FirstDataFromTable(con, "InsertExamen", p);
        }

        public static void Deletexamen(int id)
        {
            string con = ConfigurationManager.ConnectionStrings["Preparate"].ToString();
            Parameter[] p = new Parameter[] {

                 new Parameter("@ID", id)
            };
            Console.WriteLine(Utilities.ExecuteStoredProcedure(con, "DeleteExamen", p));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API0;
using System.Configuration;

namespace TestAPI
{
    class Program
    {
        static void Main(string[] args)
        {

            string con = ConfigurationManager.ConnectionStrings["Preparate"].ToString();
            Parameter[] p = new Parameter[] { new Parameter("@name","Alexis")};
            String res = Utilities.FirstDataFromTable(con, "hola", p);
            Console.WriteLine(res);
            Console.ReadLine();



            Parameter[] p = new Parameter[] {
                 new Parameter("@name", "Alexis"),
                 new Parameter("@pass", "Alexis"),
                 new Parameter("@mail", "Alexis")
            };
        }
    }
}

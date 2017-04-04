using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API0
{
    public class Pregunta
    {
        String pregunta;
        string[] respuestas;
        int RespuestaCorrecta;
        string urlImagen;
        int tipoPregunta;
        string ayuda;
        int tema;

        public static string insertarTema(string descripcion)
        {
            string con = ConfigurationManager.ConnectionStrings["Preparate"].ToString();
            Parameter[] p = new Parameter[] { new Parameter("@Desc", descripcion) };
            return Utilities.FirstDataFromTable(con, "InsertTema", p);
        }

    }
}

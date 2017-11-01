using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Persona> lista = new List<Persona>();
            ProvedorDeDatos pd=new ProvedorDeDatos();
            lista = pd.ObtenerPersonaBD();
            foreach (Persona i in lista)
            {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine("\n\n\nID ENCONTRADO\n"+pd.ObtenerPersonaPorIDBD(1).ToString());
            Console.Read();
            //List<Persona> lista = ProvedorDeDatos.ObtenerPersonaHC();
            //foreach (Persona i in lista)
            //{
            //    Console.WriteLine(i.ToString());
            //}

            //// --------------------------------
            //Persona per = ProvedorDeDatos.ObtenerPersonaPorID(1);
            //Console.WriteLine("Traigo el id: " + per.id);

            //// ------------------------------------------
            //Persona per2 = ProvedorDeDatos.ObtenerPersonaPorID(6);
            //if (per2 == null)
            //{
            //    Console.WriteLine("No existe un objeto con ese id.");
            //}
            ////--------------------------------------------
            //Persona per3=new Persona(5,"Toto","Mattia",21);
            //ProvedorDeDatos.AgregarPersona(per3);
            ////---------------------------------------------
            //ProvedorDeDatos.EliminarPersona(lista[2]);
            ////----------------------------------------------





        }
    }
}

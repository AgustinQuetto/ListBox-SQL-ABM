using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public class ProvedorDeDatos
    {
        SqlConnection sqlcon = new SqlConnection(Properties.Settings.Default.Conexion);
        SqlCommand sqlcomm;

        public ProvedorDeDatos()
        {

        }
        public List<Persona> ObtenerPersonaBD()
        {
            List<Persona> lista = new List<Persona>();
            sqlcomm = new SqlCommand();

            sqlcomm.Connection = sqlcon;
            sqlcomm.CommandType = CommandType.Text;
            sqlcomm.CommandText = "SELECT * FROM Personas";

            sqlcon.Open();
            SqlDataReader sqlread = sqlcomm.ExecuteReader();

            while (sqlread.Read())
            {
                Persona per = new Persona((int)sqlread[0], (string)sqlread[1], (string)sqlread[2], (int)sqlread[3]);
                lista.Add(per);
            }
            sqlcon.Close();
            return lista;
        }
        public Persona ObtenerPersonaPorIDBD(int id)
        {
            sqlcomm = new SqlCommand();

            sqlcomm.Connection = sqlcon;
            sqlcomm.CommandType = CommandType.Text;
            sqlcomm.CommandText = "SELECT * FROM Personas WHERE Id=" + id;

            sqlcon.Open();
            SqlDataReader sqlread = sqlcomm.ExecuteReader();

            Persona per;
            if (sqlread.HasRows)
            {
                sqlread.Read();
                per = new Persona((int)sqlread[0], (string)sqlread[1], (string)sqlread[2], (int)sqlread[3]);
                sqlcon.Close();
            }

            else
            {
                sqlcon.Close();
                   return null;
            }

            
            return per;
        }

        public bool AgregarPersonaBD(Persona per)
        {
            sqlcomm = new SqlCommand();
            sqlcomm.Connection = sqlcon;
            sqlcomm.CommandType = CommandType.Text;
            sqlcomm.CommandText = "INSERT INTO Personas (nombre,apellido,edad) Values("+"'"+per.nombre+"'"+","+"'"+per.apellido+"'"+","+per.edad+")";
            sqlcon.Open();

            sqlcomm.ExecuteNonQuery();
            sqlcon.Close();
            return true;
        }

        public bool ModificarPersonaBD(Persona per)
        {
            sqlcomm = new SqlCommand();
            sqlcomm.Connection = sqlcon;
            sqlcomm.CommandType = CommandType.Text;
            sqlcomm.CommandText = "UPDATE Personas SET nombre = '"+per.nombre+"', apellido = '"+per.apellido+"', edad = '"+per.edad+"' WHERE id="+per.id;
            sqlcon.Open();

            sqlcomm.ExecuteNonQuery();
            sqlcon.Close();
            return true;
        }

        public bool EliminarPersonaBD(int id)
        {
            sqlcomm = new SqlCommand();
            sqlcomm.Connection = sqlcon;
            sqlcomm.CommandType = CommandType.Text;
            sqlcomm.CommandText = "DELETE FROM Personas WHERE ID="+id;
            sqlcon.Open();

            sqlcomm.ExecuteNonQuery();
            sqlcon.Close();
            return true;
        }
        
        public static List<Persona> ObtenerPersonaHC()
        {

            Persona per1 = new Persona(1, "Lucas", "Massa", 20);
            Persona per2 = new Persona(2, "Pancho", "Di Marzo", 21);
            Persona per3 = new Persona(3, "Santiago", "Bonazi", 20);
            Persona per4 = new Persona(4, "Martin", "Alberio", 20);
            List<Persona> lista = new List<Persona>();
            lista.Add(per1);
            lista.Add(per2);
            lista.Add(per3);
            lista.Add(per4);

            return lista;
        }
        public static Persona ObtenerPersonaPorID(int id)
        {
            List<Persona> lista = ObtenerPersonaHC();

            foreach (Persona i in lista)
            {
                if (i.id == id)
                    return i;
            }
            return null;
        }
        public static bool AgregarPersona(Persona per)
        {
            List<Persona> lista = ObtenerPersonaHC();
            lista.Add(per);
            return true;

        }
        public static bool ModificarPersona(Persona per)
        {
            List<Persona> lista = ObtenerPersonaHC();

            for (int i = 0; i < lista.Count; i++)
            {
                if (per.id == lista[i].id)
                {
                    lista[i] = per;
                    return true;
                }
            }
            return false;
        }
        public static bool EliminarPersona(Persona per)
        {
            List<Persona> lista = ObtenerPersonaHC();
            Persona per2 = ObtenerPersonaPorID(per.id);
            if (lista.Remove(per2))
            {
                return true;
            }
            return false;
        }
    }
}

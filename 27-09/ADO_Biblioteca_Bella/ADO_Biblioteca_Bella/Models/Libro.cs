using ADO_Biblioteca_Bella.Models.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Biblioteca_Bella.Models
{
    internal class Libro
    {
        public int LibroId { get; set; }

        public string LibroCod { get; set; } = null!;

        public string Titolo { get; set; } = null!;

        public string AnnoPub { get; set; } = null!;

        public bool IsDisp { get; set; } = true;


        public override string ToString()
        {
            return $"[LIBRO] {LibroCod} {Titolo} {AnnoPub} {IsDisp}";
        }

        public string StampDettaglioL()
        {
            return $"[LIBRO] {LibroCod} {Titolo} {AnnoPub} {IsDisp}";
        }



        /*
         * Controllare la GetByAvailable, il metodo funziona ma bisogna trasformarlo in LINQ -> uso la lista  List<Libro> eleL = new List<Libro>();?
         * 
         * 
         * 
         */

        public List<Libro> GetAllByAvailable()
        {
            List<Libro> eleL = new List<Libro>();

            using (SqlConnection connessione = new SqlConnection(Config.ConnKey))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connessione;
                cmd.CommandText = "SELECT libroID, libroCOD, titolo, anno_pub, isDisp FROM Libro WHERE isDisp = 1";

                try
                {
                    connessione.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Libro lib = new Libro()
                        {
                            LibroId = reader.GetInt32(0),
                            LibroCod = reader.GetString(1),
                            Titolo = reader.GetString(2),
                            // TODO - Implementare/convertire 
                            AnnoPub = reader.GetString(3),
                            IsDisp = reader.GetBoolean(4),
                        };

                        eleL.Add(lib);

                        Console.WriteLine(lib);
                    }
                }
                catch (Exception ex)
                // TODO aggiungere messaggio personalizzato al catch
                { Console.WriteLine($"{ex.Message}"); }
                finally
                {
                    connessione.Close();
                }
            }

            return eleL;
        }

    }
}

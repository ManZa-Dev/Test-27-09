using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Biblioteca_Bella.Models.DAL
{
    internal class LibroDAO : IDao<Libro>
    {

        private static LibroDAO? istanza;

        public static LibroDAO GetInstance()
        {
            if (istanza == null)
                istanza = new LibroDAO();
            return istanza;
        }

        private LibroDAO() { }

        public bool delete(Libro par)
        {
            bool ris = false;

            using (SqlConnection connessione = new SqlConnection(Config.ConnKey))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connessione;

                cmd.CommandText = "DELETE FROM Libro where libroCOD = @codi ";
                cmd.Parameters.AddWithValue("@codi", par.LibroCod);

                try
                {
                    connessione.Open();

                    int affRows = cmd.ExecuteNonQuery();
                    if (affRows > 0)
                        ris = true;

                    //TODO Controllare se può rimanere nel finally
                    //connessione.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally { connessione.Close(); }
            }
            return ris;
        }

        public List<Libro> GetAll()
        {
            List<Libro> eleL = new List<Libro>();

            using (SqlConnection connessione = new SqlConnection(Config.ConnKey))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connessione;
                cmd.CommandText = "SELECT libroID, libroCOD, titolo, anno_pub, isDisp FROM Libro";

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

        public Libro? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool insert(Libro par)
        {
            bool ris = false;

            using (SqlConnection connessione = new SqlConnection(Config.ConnKey))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connessione;

                cmd.CommandText = "INSERT INTO Libro(titolo, ann_pub, isDisp) VALUES (@tito, @anno, @disp)";
                cmd.Parameters.AddWithValue("@tito", par.Titolo);
                cmd.Parameters.AddWithValue("@anno", par.AnnoPub);
                cmd.Parameters.AddWithValue("@disp", par.IsDisp);

                try
                {
                    connessione.Open();

                    int affRows = cmd.ExecuteNonQuery();
                    if (affRows > 0)
                        ris = true;

                    //TODO Controllare se può rimanere nel finally
                    //connessione.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally { connessione.Close(); }
            }
            return ris;
        }

        public bool update(Libro par)
        {
            throw new NotImplementedException();
        }
    }
}

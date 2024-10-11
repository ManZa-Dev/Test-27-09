using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Biblioteca_Bella.Models.DAL
{
    internal class PrestitoDAO : IDao<Prestito>
    {

        private static PrestitoDAO? istanza;

        public static PrestitoDAO GetInstance()
        {
            if (istanza == null)
                istanza = new PrestitoDAO();
            return istanza;
        }

        private PrestitoDAO() { }

        public bool delete(Prestito par)
        {
            bool ris = false;

            using (SqlConnection connessione = new SqlConnection(Config.ConnKey))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connessione;

                cmd.CommandText = "DELETE FROM Prestito where prestitoCOD = @codi ";
                cmd.Parameters.AddWithValue("@codi", par.PrestitoCod);

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

        public List<Prestito> GetAll()
        {
            //List<Utente> eleU = new List<Utente>();
            //List<Libro> eleL = new List<Libro>();

            List<Prestito> eleP = new List<Prestito>();

            using (SqlConnection connessione = new SqlConnection(Config.ConnKey))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connessione;
                cmd.CommandText = "SELECT prestitoID, prestitoCOD, ini_prest, fin_prest, utenteRIF, libroRIF FROM Prestito";

                try
                {
                    connessione.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Prestito pre = new Prestito()
                        {
                            PrestitoId = reader.GetInt32(0),
                            PrestitoCod = reader.GetString(1),
                            IniPrest = reader.GetDateTime(2),
                            FinPrest = reader.GetDateTime(3),
                            
                        };

                        eleP.Add(pre);
                        Console.WriteLine(pre);
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
            return eleP;
        }

        public Prestito? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool insert(Prestito par)
        {
            bool ris = false;

            using (SqlConnection connessione = new SqlConnection(Config.ConnKey))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connessione;

                cmd.CommandText = "INSERT INTO Prestito(ini_prest, fin_prest, utenteRIF, libroRIF) VALUES (@inip, @finp, @urif, @lrif)";
                cmd.Parameters.AddWithValue("@inip", par.IniPrest);
                cmd.Parameters.AddWithValue("@finp", par.FinPrest);
                cmd.Parameters.AddWithValue("@urif", par.UtenteRif);
                cmd.Parameters.AddWithValue("@lrif", par.LibroRif);

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

        public bool update(Prestito par)
        {
            throw new NotImplementedException();
        }
    }
}

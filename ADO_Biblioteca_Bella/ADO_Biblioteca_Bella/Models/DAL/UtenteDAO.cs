using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Biblioteca_Bella.Models.DAL
{
    internal class UtenteDAO : IDao<Utente>
    {

        private static UtenteDAO? istanza;

        public static UtenteDAO GetInstance()
        {
            if (istanza == null)
                istanza = new UtenteDAO();
            return istanza;
        }

        private UtenteDAO() { }
        public bool delete(Utente par)
        {
            bool ris = false;

            using (SqlConnection connessione = new SqlConnection(Config.ConnKey))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connessione;

                cmd.CommandText = "DELETE FROM Utente where utenteCOD = @codi ";
                cmd.Parameters.AddWithValue("@codi", par.UtenteCod);

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

        public List<Utente> GetAll()
        {
            List<Utente> eleU = new List<Utente> ();

            using (SqlConnection connessione = new SqlConnection(Config.ConnKey))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connessione;
                cmd.CommandText = "SELECT utenteID, utenteCOD, nome, cognome, email FROM Utente";

                try
                {
                    connessione.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Utente ute = new Utente()
                        {
                            UtenteId = reader.GetInt32(0),
                            UtenteCod = reader.GetString(1),
                            Nome = reader.GetString(2),
                            Cognome = reader.GetString(3),
                            Email = reader.GetString(4),
                        };

                        eleU.Add(ute);
                        Console.WriteLine(ute);
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

            return eleU;
        }

        public Utente? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool insert(Utente par)
        {
            bool ris = false;

            using (SqlConnection connessione = new SqlConnection(Config.ConnKey))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connessione;

                cmd.CommandText = "INSERT INTO Utente(Nome, Cognome, Email) VALUES (@nome, @cogn, @emai)";
                cmd.Parameters.AddWithValue("@nome", par.Nome);
                cmd.Parameters.AddWithValue("@Cogn", par.Cognome);
                cmd.Parameters.AddWithValue("@emai", par.Email);

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

        public bool update(Utente par)
        {
            throw new NotImplementedException();
        }
    }
}

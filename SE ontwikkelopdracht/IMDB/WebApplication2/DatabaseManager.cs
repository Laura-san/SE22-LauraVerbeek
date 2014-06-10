using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace WebApplication2
{
    public class DatabaseManager
    {
        private static OracleConnection connection = new OracleConnection();

        static string pcn = "dbi276960";
        static string password = "V6goeFUlqv";

        static private string dataSource = " //192.168.15.50:1521/fhictora";

        public string DataSource
        {
            get { return dataSource; }
        }

        //public DatabaseManager()
        //{
        //    conn = new OracleConnection();
        //    dataSource = " //192.168.15.50:1521/fhictora";
        //    pcn = "dbi276960";
        //    password = "V6goeFUlqv";
        //    initialisationDatabase(pcn, password, dataSource);
        //}

        //public DatabaseManager()
        //{
        //    pcn = "dbi276960";
        //    password = "V6goeFUlqv";
        //    connection.ConnectionString = string.Format("User Id={0};Password={1};Data Source=//192.168.15.50:1521/fhictora;", pcn, password, DataSource);
        //}

        public DatabaseManager(string Datasource, string Username, string Password)
        {
            connection = new OracleConnection();
            dataSource = Datasource;
            pcn = Username;
            password = Password;
            initialisationDatabase(pcn, password, dataSource);
        }
        private static void initialisationDatabase(string Pcn, string Password, string DataSource)
        {
            connection.ConnectionString = "User Id=" + Pcn + ";Password=" + Password + ";Data Source=" + DataSource + ";";
        }

        private static void OpeningAConnection()
        {
            if (connection.ConnectionString == null || connection.ConnectionString == "")
            {
                connection.ConnectionString = "User Id=" + pcn + ";Password=" + password + ";Data Source=" + dataSource + ";";
            }
            try
            {
                connection.Open();
            }
            catch
            {
            }
        }

        //private static void OpeningAConnection()
        //{
        //    if (connection.ConnectionString == null || connection.ConnectionString == "")
        //    {
        //        connection.ConnectionString = "User Id=" + pcn + ";Password=" + password + ";Data Source=" + dataSource + ";";
        //    }
        //    try
        //    {
        //        connection.Open();
        //    }
        //    catch
        //    {
        //    }
        //}

        public static Account LogIn(string UserName, string Password)
        {
            try
            {
                OpeningAConnection();
            }
            catch
            {
                throw;
            }
            string query = "SELECT * FROM gebruiker WHERE gebruikersnaam = '" + UserName + "' AND wachtwoord = '" + Password + "'";
            OracleCommand command = new OracleCommand(query, connection);
            command.CommandType = CommandType.Text;
            OracleDataReader dataReader;

            Account acc = null;
            int UserID = -1;
            string soort = "";
            string firstName = "";
            string lastName = "";
            DateTime dateOfBirth = DateTime.Now;
            bool LogIn = false;
            bool admin = false;

            try
            {
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    UserID = Convert.ToInt32(dataReader["gebruikersID"]);
                    soort = Convert.ToString(dataReader["soort"]);
                    firstName = Convert.ToString(dataReader["voornaam"]);
                    lastName = Convert.ToString(dataReader["achternaam"]);
                    dateOfBirth = Convert.ToDateTime(dataReader["geboortedatum"]);
                    if (dataReader["soort"].ToString() == "gast")
                    {
                        admin = false;
                    }
                    else
                    {
                        admin = true;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
            if (admin)
            {
                Employee emp = LogInEmployee(UserID);
                acc = new Employee(UserID, UserName, Password, firstName, lastName, dateOfBirth, emp.HiredSinde, emp.Salaris, emp.Addres, emp.Soort);
            }
            else
            {
                User user = LogInUser(UserID);
                acc = new User(UserID, UserName, Password, firstName, lastName, dateOfBirth, user.Email, user.MemberLetter, user.Soort);
            }
            return acc;
        }

        public static Employee LogInEmployee(int userID)
        {
            try
            {
                OpeningAConnection();
            }
            catch
            {
                throw;
            }
            string queryEmployee = "SELECT * FROM medewerker WHERE gebruikersID = :userID";
            OracleCommand commandEmployee = new OracleCommand(queryEmployee, connection);
            commandEmployee.CommandType = CommandType.Text;
            OracleDataReader dataReaderEmployee;

            commandEmployee.Parameters.Add(new OracleParameter(":userID", userID));

            bool inlog = false;
            DateTime HiredSince = DateTime.Now;
            double salaris = 0;
            string postcode = "";
            string place = "";

            try
            {
                dataReaderEmployee = commandEmployee.ExecuteReader();
                while (dataReaderEmployee.Read())
                {
                    HiredSince = Convert.ToDateTime(dataReaderEmployee["aangenomenOp"]);
                    salaris = Convert.ToDouble(dataReaderEmployee["salaris"]);
                    postcode = Convert.ToString(dataReaderEmployee["postcode"]);
                    place = Convert.ToString(dataReaderEmployee["woonplaats"]);
                    inlog = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
            Addres addres = new Addres(postcode, place);
            return new Employee(HiredSince, salaris, addres, "Employee");
        }

        public static User LogInUser(int userID)
        {
            try
            {
                OpeningAConnection();
            }
            catch
            {
                throw;
            }
            string queryUser = "SELECT * FROM gast WHERE gebruikersID = :userID";
            OracleCommand commandUser = new OracleCommand(queryUser, connection);
            commandUser.CommandType = CommandType.Text;
            OracleDataReader dataReaderUser;

            commandUser.Parameters.Add(new OracleParameter(":userID", userID));

            bool inlog = false ;
            string email = "";
            bool letter = false;

            try
            {
                dataReaderUser = commandUser.ExecuteReader();
                while (dataReaderUser.Read())
                {
                    email = Convert.ToString(dataReaderUser["email"]);
                    if (dataReaderUser["lidnieuwsbrief"] == "y")
                    {
                        letter = true;
                    }
                    else
                    {
                        letter = false;
                    }
                    inlog = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
            return new User(email, letter,"User");
        }

        public static void InsertMovie(Movie movie)
        {
            try
            {
                OpeningAConnection();
            }
            catch
            {
                throw;
            }
            string releasedate = movie.ReleaseDate.Day + "/" + movie.ReleaseDate.Month + "/" + movie.ReleaseDate.Year;
            string query = "INSERT INTO FILM VALUES('" + movie.MovieID + "', ':movieTitl', (TO_DATE('" + releasedate + "', 'dd/mm/yy')), ':description', ':genre', ':prev', ':next', ':age', ':sex', ':violence', ':fear', ':discrimination', ':drugsAlcoholAbuse')";
            OracleCommand command = new OracleCommand(query, connection);
            command.CommandType = CommandType.Text;
            OracleDataReader dataReader;

            command.Parameters.Add(new OracleParameter(":movieTitle", movie.Title));
            command.Parameters.Add(new OracleParameter(":releaseDate", releasedate));
            command.Parameters.Add(new OracleParameter(":description", movie.Description));
            command.Parameters.Add(new OracleParameter(":genre", movie.Genre));
            command.Parameters.Add(new OracleParameter(":prev", movie.PrevMovie));
            command.Parameters.Add(new OracleParameter(":next", movie.NextMovie));
            command.Parameters.Add(new OracleParameter(":age", movie.Age));
            command.Parameters.Add(new OracleParameter(":sex", movie.Sex));
            command.Parameters.Add(new OracleParameter(":violence", movie.Violence));
            command.Parameters.Add(new OracleParameter(":fear", movie.Fear));
            command.Parameters.Add(new OracleParameter(":discrimination", movie.Discrimination));
            command.Parameters.Add(new OracleParameter(":drugsAlcoholAbuse", movie.DrugsAlcoholAbuse));

            try
            {
                dataReader = command.ExecuteReader();
            }
             catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }

        public static void InsertActor(Actor actor)
        {
            try
            {
                OpeningAConnection();
            }
            catch
            {
                throw;
            }
            string dateOfBirth = actor.DateOfBirth.Day + "/" + actor.DateOfBirth.Month + "/" + actor.DateOfBirth.Year;
            string query = "INSERT INTO ACTEUR VALUES('" + actor.ActorID + "', ':Name', ':bio', (TO_DATE('" + dateOfBirth + "', 'dd/mm/yy')))";
            OracleCommand command = new OracleCommand(query, connection);
            command.CommandType = CommandType.Text;
            OracleDataReader dataReader;

            command.Parameters.Add(new OracleParameter(":Name", actor.Name));
            command.Parameters.Add(new OracleParameter(":Bio", actor.Biography));

            try
            {
                dataReader = command.ExecuteReader();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
            //InsertFilmography(actor);
        }

        public static void InsertFilmography(Actor actor)
        {
            //connection must be open...
            try
            {
                OpeningAConnection();
            }
            catch
            {
                throw;
            }
            
            int filmographyID = Convert.ToInt32(GiveHighestID("Filmografie")) + 1;
            string query = "INSERT INTO FILMOGRAPHY VALUES(" + filmographyID + ", " + actor.ActorID + ", 2)";
            OracleCommand command = new OracleCommand(query, connection);
            command.CommandType = CommandType.Text;
            OracleDataReader dataReader;

            try
            {
                dataReader = command.ExecuteReader();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }

        public static int GiveMovieIDFromTitle(string title)
        {
            string query = "SELECT FILMID FROM FILM WHERE TITEL = ':title'";
            OracleCommand command = new OracleCommand(query, connection);
            command.CommandType = CommandType.Text;
            OracleDataReader dataReader;

            command.Parameters.Add(new OracleParameter(":title", title));

            int movieID = 0;

            try
            {
                dataReader = command.ExecuteReader();
                movieID = Convert.ToInt32(dataReader["FilmID"]);
            }
            catch (Exception e)
            {
                throw e;
            }
            
            return movieID;
        }

        public static List<Movie> GiveMovies()
        {
            try
            {
                OpeningAConnection();
            }
            catch
            {
                throw;
            }
            string query = "SELECT * FROM FILM";
            OracleCommand command = new OracleCommand(query, connection);
            command.CommandType = CommandType.Text;
            OracleDataReader dataReader;

            List<Movie> movies = new List<Movie>();
            int movieID = 0;
            string title = "";
            DateTime releasedate = DateTime.Now;
            string description = "";
            EnumGenre genre = EnumGenre.Humor;
            Movie prev = new Movie();
            Movie next = new Movie();
            string age = "";
            bool sex = false;
            bool violence = false;
            bool fear = false;
            bool discrimination = false;
            bool drugsAlcoholAbuse = false;
            
            try
            {
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    movieID = Convert.ToInt32(dataReader["FILMID"]);
                    title = Convert.ToString(dataReader["TITEL"]);
                    //releasedate = Convert.ToDateTime(dataReader["RELEASEDATE"]);
                    description = Convert.ToString(dataReader["OMSCHRIJVING"]);
                    //prev = (Movie)dataReader["VORIGEFILM"];
                    //next = (Movie)dataReader["VOLGENDEFILM"];
                    age = Convert.ToString(dataReader["LEEFTIJDGRENS"]);
                    sex = Convert.ToBoolean(dataReader["SEX"]);
                    violence = Convert.ToBoolean(dataReader["GEWELD"]);
                    fear = Convert.ToBoolean(dataReader["ANGST"]);
                    discrimination = Convert.ToBoolean(dataReader["DISCRIMINATIE"]);
                    drugsAlcoholAbuse = Convert.ToBoolean(dataReader["DRUGALCOHOLGEBRUIK"]);

                    if (Convert.ToString(dataReader["GENRE"]) == "Adventure")
                    {
                        genre = EnumGenre.Adventure;
                    }
                    else if (Convert.ToString(dataReader["GENRE"]) == "Comedy")
                    {
                        genre = EnumGenre.Comedy;
                    }
                    else if (Convert.ToString(dataReader["GENRE"]) == "Drama")
                    {
                        genre = EnumGenre.Drama;
                    }
                    else if (Convert.ToString(dataReader["GENRE"]) == "Humor")
                    {
                        genre = EnumGenre.Humor;
                    }
                    movies.Add(new Movie(movieID, title, releasedate, description, genre, next, prev, age, sex, violence, fear, discrimination, drugsAlcoholAbuse));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
            
            return movies;
        }

        public static List<Actor> GiveActors()
        {
            try
            {
                OpeningAConnection();
            }
            catch
            {
                throw;
            }
            string query = "SELECT * FROM ACTEUR";
            OracleCommand command = new OracleCommand(query, connection);
            command.CommandType = CommandType.Text;
            OracleDataReader dataReader;

            List<Actor> actors = new List<Actor>();
            int actorID = 0;
            string name = "";
            string biography = "";
            DateTime dateOfBirth = DateTime.Now;

            try
            {
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    actorID = Convert.ToInt32(dataReader["ACTEURID"]);
                    name = Convert.ToString(dataReader["NAAM"]);
                    biography = Convert.ToString(dataReader["BIOGRAFIE"]);
                    dateOfBirth = Convert.ToDateTime(dataReader["GEBOORTEDATUM"]);
                    actors.Add(new Actor(actorID, name, biography, dateOfBirth));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
            return actors;
        }

        public static List<string> GiveGenres()
        {
            try
            {
                OpeningAConnection();
            }
            catch
            {
                throw;
            }
            string query = "SELECT GENRECODE FROM GENRE";
            OracleCommand command = new OracleCommand(query, connection);
            command.CommandType = CommandType.Text;
            OracleDataReader dataReader;

            List<string> genres = new List<string>();
            string code = "";

            try
            {
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    code = Convert.ToString(dataReader["GENRECODE"]);
                    genres.Add(code);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
            return genres;
        }

        public static string GiveHighestID(string type)
        {
            string returnValue = "";
            try
            {
                OpeningAConnection();
            }
            catch
            {
                throw;
            }
            string query = "SELECT * FROM " + type;
            OracleCommand command = new OracleCommand(query, connection);
            command.CommandType = CommandType.Text;
            OracleDataReader dataReader;

            try
            {
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    returnValue = dataReader[0].ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return returnValue;
        }
    }
}
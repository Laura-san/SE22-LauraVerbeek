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
        private static OracleConnection conn = new OracleConnection();

        static string pcn = "dbi276960";
        static string password = "V6goeFUlqv";

        static private string dataSource = " //192.168.15.50:1521/fhictora";

        public string DataSource
        {
            get { return dataSource; }
        }

        public DatabaseManager()
        {
            conn = new OracleConnection();
            dataSource = " //192.168.15.50:1521/fhictora";
            pcn = "dbi276960";
            password = "V6goeFUlqv";
            initialisationDatabase(pcn, password, dataSource);
        }

        public DatabaseManager(string Datasource, string Username, string Password)
        {
            conn = new OracleConnection();
            dataSource = Datasource;
            pcn = Username;
            password = Password;
            initialisationDatabase(pcn, password, dataSource);
        }
        private static void initialisationDatabase(string Pcn, string Password, string DataSource)
        {
            conn.ConnectionString = "User Id=" + Pcn + ";Password=" + Password + ";Data Source=" + DataSource + ";";
        }

        private static void OpeningAConnection()
        {
            if (conn.ConnectionString == null || conn.ConnectionString == "")
            {
                conn.ConnectionString = "User Id=" + pcn + ";Password=" + password + ";Data Source=" + dataSource + ";";
            }
            try
            {
                conn.Open();
            }
            catch
            {
            }
        }

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
            OracleCommand command = new OracleCommand(query, conn);
            command.CommandType = CommandType.Text;
            OracleDataReader dataReader;

            Account acc = new User();
            int UserID = 0;
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
                conn.Close();
            }
            if (admin)
            {
                acc = LogInEmployee(UserID);
            }
            else
            {
                acc = LogInUser(UserID);
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
            string queryEmployee = "SELECT * FROM medewerker WHERE gebruikersID = " + userID;
            OracleCommand commandEmployee = new OracleCommand(queryEmployee, conn);
            commandEmployee.CommandType = CommandType.Text;
            OracleDataReader dataReaderEmployee;

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
                conn.Close();
            }
            Addres addres = new Addres(postcode, place);
            return new Employee(HiredSince, salaris, addres);
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
            string queryUser = "SELECT * FROM gast WHERE gebruikersID = " + userID;
            OracleCommand commandUser = new OracleCommand(queryUser, conn);
            commandUser.CommandType = CommandType.Text;
            OracleDataReader dataReaderUser;

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
                conn.Close();
            }
            return new User(email, letter);
        }
    }

}
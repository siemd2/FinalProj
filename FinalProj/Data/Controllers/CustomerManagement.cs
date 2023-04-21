using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProj.Data.Models;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace FinalProj.Data.Controllers
{
    public class CustomerManagement
    {
        public Customer CreateCustomer(int userID, string userName, int phoneNumber, string email, string address)
        {
            Customer newCustomer = new Customer(userID, userName, phoneNumber, email, address);
            return newCustomer;
        } 

        public void SaveCustomerToDB(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                string connectionString = "Data Source=192.168.56.1; Initial Catalog=FinalProjOOP;User ID=FinalProjOOP;Password=tlsdibbd;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                string populateDatabaseScript = "INSERT INTO FinalProj_Customer VALUES (@CustID, @Custname, @CustPhone, @CustEmail, @CustAddress);";
                MySqlCommand command = new MySqlCommand(populateDatabaseScript, connection);                
				MySqlParameter parameter1 = new MySqlParameter("@CustID", customer.UserId);
				command.Parameters.Add(parameter1);
				MySqlParameter parameter2 = new MySqlParameter("@CustName", customer.UserName);
				command.Parameters.Add(parameter2);
				MySqlParameter parameter3 = new MySqlParameter("@CustPhone", customer.PhoneNumber);
				command.Parameters.Add(parameter3);
				MySqlParameter parameter4 = new MySqlParameter("@CustEmail", customer.Email);
				command.Parameters.Add(parameter4);
				MySqlParameter parameter5 = new MySqlParameter("@CustAddress", customer.Address);
				command.Parameters.Add(parameter5);

                MySqlDataReader reader = command.ExecuteReader();
                reader.Close();
                connection.Close();
			}
        }

       
    }
}

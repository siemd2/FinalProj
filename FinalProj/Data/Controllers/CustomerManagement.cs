using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProj.Data.Models;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace FinalProj.Data.Controllers
{
    public class CustomerManagement
    {
        //Create Customer object

        public Customer CreateCustomer(int userID, string userName, int phoneNumber, string email, string address)
        {
            Customer newCustomer = new Customer(userID, userName, phoneNumber, email, address);
            return newCustomer;
        }

        //Receive a Customer object and change it into a sql script and save to the DB
        public void SaveCustomerToDB(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=FinalProjOOP;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                string populateDatabaseScript = "INSERT INTO FP_Customer VALUES (@CustID, @Custname, @CustPhone, @CustEmail, @CustAddress);";
                SqlCommand command = new SqlCommand(populateDatabaseScript, connection);
                SqlParameter parameter1 = new SqlParameter("@CustID", customer.UserId);
                command.Parameters.Add(parameter1);
                SqlParameter parameter2 = new SqlParameter("@CustName", customer.UserName);
                command.Parameters.Add(parameter2);
                SqlParameter parameter3 = new SqlParameter("@CustPhone", customer.PhoneNumber);
                command.Parameters.Add(parameter3);
                SqlParameter parameter4 = new SqlParameter("@CustEmail", customer.Email);
                command.Parameters.Add(parameter4);
                SqlParameter parameter5 = new SqlParameter("@CustAddress", customer.Address);
                command.Parameters.Add(parameter5);

                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}

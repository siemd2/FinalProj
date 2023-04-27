using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using FinalProj.Data.Models;

namespace FinalProj.Data
{
	public class DataAccessLayer
	{
		private readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=FinalProjOOP;Integrated Security=True";

		public List<Customer> GetAllCustomers()
		{
			List<Customer> customers = new List<Customer>();

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				string query = "SELECT CustomerID, CustomerName, PhoneNumber, Email, Address FROM FP_Customer;";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							int customerId = (int)reader.GetDecimal(0);
							string customerName = reader.GetString(1);
							int phoneNumber = reader.IsDBNull(2) ? 0 : (int)reader.GetDecimal(2);
							string email = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
							string address = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);

							customers.Add(new Customer(customerId, customerName, phoneNumber, email, address));
						}
					}
				}
			}

			return customers;
		}

		public List<Staff> GetAllStaff()
		{
			List<Staff> staffList = new List<Staff>();

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				string query = "SELECT StaffID, StaffName, PhoneNumber, Email FROM FP_Staff;";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							int staffId = (int)reader.GetDecimal(0);
							string staffName = reader.GetString(1);
							int phoneNumber = reader.IsDBNull(2) ? 0 : (int)reader.GetDecimal(2);
							string email = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);

							staffList.Add(new Staff(staffId, staffName, phoneNumber, email));
						}
					}
				}
			}

			return staffList;
		}

		public List<Service> lServices()
		{
			List<Service> services = new List<Service>();

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				string query = "SELECT ServiceID, ServiceName, Price, TimeInMinute, Description FROM FP_Service;";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							int serviceId = (int)reader.GetDecimal(0);
							string serviceName = reader.GetString(1);
							double price = reader.IsDBNull(2) ? 0 : reader.GetDouble(2);
							int timeInMinute = reader.IsDBNull(3) ? 0 : (int)reader.GetDecimal(3);
							string description = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);

							services.Add(new Service(serviceId, serviceName, price, timeInMinute, description));
						}
					}
				}
			}
			return services;
		}
	}
}

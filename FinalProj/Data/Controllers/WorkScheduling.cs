using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProj.Data.Models;
using Microsoft.Data.SqlClient;


namespace FinalProj.Data.Controllers
{
	public class WorkScheduling
	{
		//We need to make a query for this before I can finish this
		//Query the database for available workticket

		public List<WorkTicket> QueryAllWorkTicket()
		{
			string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=FinalProjOOP;Integrated Security=True";
			List<WorkTicket> ticketList = new List<WorkTicket>();

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				string query = "SELECT wt.workticketid, wt.staffid, wt.customerid, wt.serviceid, wt.servicedate, c.customername, c.phonenumber, c.email, c.address, s.servicename FROM FP_WORKTICKET WT JOIN FP_CUSTOMER C ON WT.CUSTOMERID = C.CUSTOMERID JOIN FP_Service s ON WT.ServiceID = s.ServiceID;";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							int workticketId = (int)reader.GetDecimal(0);
							int staffId = (int)reader.GetDecimal(1);
							int customerId = (int)reader.GetDecimal(2);
							int serviceId = (int)reader.GetDecimal(3);
							string serviceDate = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
							string customerName = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
							int custPhone = (int)reader.GetDecimal(6);
							string custEmail = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
							string custAddress = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
							string serviceName = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);

							WorkTicket ticket = new WorkTicket(workticketId, staffId, customerId, serviceId, serviceDate, customerName, custPhone, custEmail, custAddress, serviceName);
							ticketList.Add(ticket);

						}
					}
				}
			}
			return ticketList;
		}

		//Update a work ticket with a staffID
		public void UpdateWorkTicket(WorkTicket workTicket, int newStaffId)
		{
			string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=FinalProjOOP;Integrated Security=True";
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				string alterDBScript = "UPDATE FP_WORKTICKET SET STAFFID = @newStaffId WHERE workticketid = @TicketId;";
				using (SqlCommand command = new SqlCommand(alterDBScript, connection))
				{
					SqlParameter parameter1 = new SqlParameter("@newStaffId", newStaffId);
					command.Parameters.Add(parameter1);
					SqlParameter parameter2 = new SqlParameter("@TicketId", workTicket.TicketId);
					command.Parameters.Add(parameter2);
					command.ExecuteNonQuery();
				}
			}
		}
		//Query for All services in DB
		public List<Service> GetAllService()
		{
			string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=FinalProjOOP;Integrated Security=True";
			List<Service> serviceList = new List<Service>();

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				string query = "SELECT serviceid, servicename, price, timeinminute, description FROM FP_SERVICE;";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							int serviceId = (int)reader.GetDecimal(0);
							string serviceName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
							int price = (int)reader.GetDecimal(2);
							int timeinminute = (int)reader.GetDecimal(3);
							string desc = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);

							Service service = new Service(serviceId, serviceName, price, timeinminute, desc);
							serviceList.Add(service);
						}
					}
				}
			}
			return serviceList;
		}
	}
}

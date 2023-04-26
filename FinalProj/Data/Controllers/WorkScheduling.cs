using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProj.Data.Models;

namespace FinalProj.Data.Controllers
{
    public class WorkScheduling
    {
		//We need to make a query for this before I can finish this
		//Query the database for available workticket
		public List<WorkTicket> QueryAllWorkTicket()
		{
			string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=FinalProjOOP;Integrated Security=True";
			SqlConnection connection = new SqlConnection(connectionString);
			connection.Open();

			string query = "SELECT wt.workticketid, wt.staffid, wt.customerid, wt.serviceid, wt.servicedate, wt.vehiclevin, wt.mmm, c.customername, c.phonenumber, c.email, c.address FROM FP_WORKTICKET WT JOIN FP_CUSTOMER C ON WT.CUSTOMERID = C.CUSTOMERID;";
			SqlCommand command = new SqlCommand(query, connection);
			SqlDataReader reader = command.ExecuteReader();

			List<WorkTicket> ticketList = new List<WorkTicket>();
			//Create a ticket for each row return and add to the ticketList
			while (reader.Read())
			{
				int workticketId = reader.GetInt32(0);
				int staffId = reader.GetInt32(1);
				int customerId = reader.GetInt32(2);
				int serviceId = reader.GetInt32(3);
				string serviceDate = reader.GetString(4);
				int vehicleVin = reader.GetInt32(5);
				string mmm = reader.GetString(6);
				string customerName = reader.GetString(7);
				int custPhone = reader.GetInt32(8);
				string custEmail = reader.GetString(9);
				string custAddress = reader.GetString(10);

				WorkTicket ticket = new WorkTicket(workticketId, staffId, customerId, serviceId, serviceDate, vehicleVin, mmm, customerName, custPhone, custEmail, custAddress);

				ticketList.Add(ticket);
			}

			reader.Close();
			connection.Close();

			return ticketList;
		}

		//A method to update the staffid for the work ticket in the DB
		public void UpdateWorkTicket(WorkTicket workTicket, int newStaffId)
		{
			string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=FinalProjOOP;Integrated Security=True";
			SqlConnection connection = new SqlConnection(connectionString);
			connection.Open();

			string alterDBScript = "UPDATE FP_WORKTICKET SET STAFFID = @newStaffId WHERE workticketid = @TicketId;";
			SqlCommand command = new SqlCommand(alterDBScript, connection);
			SqlParameter parameter1 = new SqlParameter("@newStaffId", newStaffId);
			command.Parameters.Add(parameter1);
			SqlParameter parameter2 = new SqlParameter("@TicketId", workTicket.TicketId);
			command.Parameters.Add(parameter2);

			command.ExecuteNonQuery();
			connection.Close();
		}

		//Query To generate available Service in the database
		public List<Service> GetAllService()
		{
			string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=FinalProjOOP;Integrated Security=True";
			SqlConnection connection = new SqlConnection(connectionString);
			connection.Open();

			string query = "SELECT serviceid, servicename, price, timeinminute, description FROM FP_SERVICE;";
			SqlCommand command = new SqlCommand(query, connection);
			SqlDataReader reader = command.ExecuteReader();

			List<Service> serviceList = new List<Service>();
			while (reader.Read())
			{
				int serviceId = reader.GetInt32(0);
				string serviceName = reader.GetString(1);
				int price = reader.GetInt32(2);
				int timeinminute = reader.GetInt32(3);
				string desc = reader.GetString(4);

				Service service = new Service(serviceId, serviceName, price, timeinminute, desc);
				serviceList.Add(service);
			}

			reader.Close();
			connection.Close();

			return serviceList;
		}
	}
}

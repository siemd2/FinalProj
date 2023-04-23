﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProj.Data.Models;

namespace FinalProj.Data.Controllers
{
	public class WorkBooking
	{
		//Create a new work ticket by taking parameter from the front end
		public WorkTicket CreateBookingProfile(int ticketId, int staffID, Service service, Vehicle vehicle, string date, Customer customer, string serviceDate)
		{
			WorkTicket newTask = new WorkTicket(ticketId, vehicle, customer, staffID, service, serviceDate);
			return newTask;
		}

		//Receive a WorkTicket Object and Format it into a sql script to save to the DB
		public void SaveTicketToDatabase(WorkTicket ticket)
		{
			if (ticket == null)
			{
				throw new ArgumentNullException();
			}

			else
			{
				string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=FinalProjOOP;Integrated Security=True";
				SqlConnection connection = new SqlConnection(connectionString);
				connection.Open();

				string populateDatabaseScript = "INSERT INTO FP_Workticket VALUES (@WorkOrderID, @StaffID, @CustomerID, @ServiceID, @ServiceDate);";
				SqlCommand command = new SqlCommand(populateDatabaseScript, connection);
				SqlParameter parameter1 = new SqlParameter("@WorkOrderID", ticket.TicketId);
				command.Parameters.Add(parameter1);
				SqlParameter parameter2 = new SqlParameter("@StaffID", ticket.StaffId);
				command.Parameters.Add(parameter2);
				SqlParameter parameter3 = new SqlParameter("@CustomerID", ticket.Customer.UserId);
				command.Parameters.Add(parameter3);
				SqlParameter parameter4 = new SqlParameter("@ServiceID", ticket.Service.Id);
				command.Parameters.Add(parameter4);
				SqlParameter parameter5 = new SqlParameter("@ServiceDate", ticket.ServiceDate);
				command.Parameters.Add(parameter5);

				command.ExecuteNonQuery();
				connection.Close();
			}
		}

	}
}
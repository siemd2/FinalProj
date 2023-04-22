using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
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
		public WorkTicket QueryWorkTicket()
		{
			string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=FinalProjOOP;Integrated Security=True";
			SqlConnection connection = new SqlConnection(connectionString);
			connection.Open();

			string query = "";
			SqlCommand command = new SqlCommand(query, connection);
			SqlDataReader reader = command.ExecuteReader();

		}

		//A method to update the staffid for the work ticket in the DB
		public void UpdateWorkTicket(WorkTicket workTicket)
		{
			string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=FinalProjOOP;Integrated Security=True";
			SqlConnection connection = new SqlConnection(connectionString);
			connection.Open();

			string alterDBScript = "";
			SqlCommand command = new SqlCommand(alterDBScript, connection);

		}
	}
}

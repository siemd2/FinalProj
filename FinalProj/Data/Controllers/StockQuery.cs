using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProj.Data.Models;

namespace FinalProj.Data.Controllers
{
	public class StockQuery
	{
		//Make sure to make the front end split into checking for vehiclepart or miscitem
		//Not Complete
		public VehiclePart VehiclePartQuery(VehiclePart checkPart)
		{
			string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=FinalProjOOP;Integrated Security=True";
			SqlConnection connection = new SqlConnection(connectionString);
			connection.Open();

			string query = "SELECT itemid, itemname, amountinstock, condition, arrivaldate, makemodelyear FROM FP_VEHICLEPART WHERE itemid = @checkpartid;";
			SqlCommand command = new SqlCommand(query, connection);
			SqlParameter parameter1 = new SqlParameter("@checkpartid", checkPart.PartId);
			command.Parameters.Add(parameter1);
			SqlDataReader reader = command.ExecuteReader();

			VehiclePart part = new VehiclePart();
			while (reader.Read())
			{
				part.PartId = reader.GetInt32(0);
				part.PartName = reader.GetString(1);
				part.AmountInstock = reader.GetInt32(2);
				part.Condition = reader.GetString(3);
				part.ArriveDate = reader.GetString(4);
				part.MakeModelYear = reader.GetString(5);				
			}
			reader.Close();
			connection.Close();

			return part;

		}

		//Not Complete
		public MiscellaneousItem MiscPartQuery(MiscellaneousItem item)
		{
			string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=FinalProjOOP;Integrated Security=True";
			SqlConnection connection = new SqlConnection(connectionString);
			connection.Open();

			string query = "SELECT itemid, itemName, amountinstock, condition FROM FP_MISCITEM WHERE itemid = @checkitemid;";
			SqlCommand command = new SqlCommand(query, connection);
			SqlParameter parameter1 = new SqlParameter("@checkitemid", item.PartId);
			command.Parameters.Add(parameter1);
			SqlDataReader reader = command.ExecuteReader();

			MiscellaneousItem miscItem = new MiscellaneousItem();
			while (reader.Read())
			{
				miscItem.PartId = reader.GetInt32(0);
				miscItem.PartName = reader.GetString(1);
				miscItem.AmountInstock = reader.GetInt32(2);
				miscItem.Condition = reader.GetString(3);
			}
			reader.Close();
			connection.Close();

			return miscItem;
		}

		//Query for all available vehiclePart
		public List<VehiclePart> QueryAllVehiclePart()
		{
			string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=FinalProjOOP;Integrated Security=True";
			SqlConnection connection = new SqlConnection(connectionString);
			connection.Open();

			string query = "SELECT itemid, itemname, amountinstock, condition, arrivaldate, makemodelyear FROM FP_VEHICLEPART;";
			SqlCommand command = new SqlCommand(query, connection);
			SqlDataReader reader = command.ExecuteReader();

			List<VehiclePart> vehiclePartList = new List<VehiclePart>();
			//Create a ticket for each row return and add to the ticketList
			while (reader.Read())
			{
				int itemId = reader.GetInt32(0);
				string itemName = reader.GetString(1);
				int amountinstock = reader.GetInt32(2);
				string condition = reader.GetString(3);
				string arrivalDate = reader.GetString(4);
				string mmm = reader.GetString(5);
				
				VehiclePart ticket = new VehiclePart(itemId, itemName, amountinstock, condition, arrivalDate, mmm);

				vehiclePartList.Add(ticket);
			}

			reader.Close();
			connection.Close();

			return vehiclePartList;
		}

		//Query for all available Miscitem
		public List<MiscellaneousItem> QueryAllMiscIten()
		{
			string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=FinalProjOOP;Integrated Security=True";
			SqlConnection connection = new SqlConnection(connectionString);
			connection.Open();

			string query = "SELECT itemid, itemName, amountinstock, condition FROM FP_MISCITEM;";
			SqlCommand command = new SqlCommand(query, connection);
			SqlDataReader reader = command.ExecuteReader();

			List<MiscellaneousItem> miscItemList = new List<MiscellaneousItem>();
			//Create a ticket for each row return and add to the ticketList
			while (reader.Read())
			{
				int itemId = reader.GetInt32(0);
				string itemName = reader.GetString(1);
				int amountinstock = reader.GetInt32(2);
				string condition = reader.GetString(3);

				MiscellaneousItem miscItem = new MiscellaneousItem(itemId, itemName, amountinstock, condition);

				miscItemList.Add(miscItem);
			}

			reader.Close();
			connection.Close();

			return miscItemList;
		}
	}
}

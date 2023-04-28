using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProj.Data.Models;
using Microsoft.Data.SqlClient;


namespace FinalProj.Data.Controllers
{
	//This controler class is mainly use in InventoryManagement.razor page and
	//contain methods that run sql scripts to the database when call
	//and return items information in the DB to check what is instock
	public class StockQuery
	{
		//Receive Query For one specific chosen vehicle part by it ID
		//and return a VehiclePart object contain all attributes return from the DB
		public VehiclePart VehiclePartQuery(VehiclePart checkPart)
		{
			string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=FinalProjOOP;Integrated Security=True";
			VehiclePart part = new VehiclePart();

			if (checkPart != null)
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query = "SELECT ItemID, ITEMNAME, AMOUNTINSTOCK, CONDITION, ARRIVALDATE, MAKEMODELYEAR FROM FP_VehiclePart;";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						SqlParameter parameter1 = new SqlParameter("@checkitemid", checkPart.PartId);
						command.Parameters.Add(parameter1);
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								part.PartId = (int)reader.GetDecimal(0);
								part.PartName = reader.GetString(1);
								part.AmountInstock = (int)reader.GetDecimal(2);
								part.Condition = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
								part.ArriveDate = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
								part.MakeModelYear = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
							}
						}
					}
				}
				return part;
			}
			else
			{
				throw new ArgumentNullException(nameof(checkPart));
			}
		}

		//Receive Query For one specific chosen Misc Item by it ID
		//and return a MiscellaneousItem object contain all attributes return from the DB
		public MiscellaneousItem MiscPartQuery(MiscellaneousItem item)
		{
			string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=FinalProjOOP;Integrated Security=True";
			MiscellaneousItem miscItem = new MiscellaneousItem();
			if (item != null)
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query = "SELECT itemid, itemName, amountinstock, condition FROM FP_MISCITEM WHERE itemid = @checkitemid;";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						SqlParameter parameter1 = new SqlParameter("@checkitemid", item.PartId);
						command.Parameters.Add(parameter1);
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								miscItem.PartId = (int)reader.GetDecimal(0);
								miscItem.PartName = reader.GetString(1);
								miscItem.AmountInstock = (int)reader.GetDecimal(2);
								miscItem.Condition = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
							}
						}
					}
				}
				return miscItem;
			}
			else
			{
				throw new ArgumentNullException(nameof(item));
			}
		}

		//Query for all available vehiclePart
		//and return them as a list
		public List<VehiclePart> QueryAllVehiclePart()
		{
			string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=FinalProjOOP;Integrated Security=True";
			List<VehiclePart> vehiclePartList = new List<VehiclePart>();

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				string query = "SELECT ItemID, ITEMNAME, AMOUNTINSTOCK, CONDITION, ARRIVALDATE, MAKEMODELYEAR FROM FP_VehiclePart;";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							VehiclePart part = new VehiclePart();
							part.PartId = (int)reader.GetDecimal(0);
							part.PartName = reader.GetString(1);
							part.AmountInstock = (int)reader.GetDecimal(2);
							part.Condition = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
							part.ArriveDate = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
							part.MakeModelYear = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);

							vehiclePartList.Add(part);
						}
						if(vehiclePartList.Count > 0) { }
						else
						{
							throw new Exception();
						}
					}
				}
			}
			return vehiclePartList;
		}
		//Query the DB for all Misc Item
		//and return them as a list
		public List<MiscellaneousItem> QueryAllMiscItem()
		{
			string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=FinalProjOOP;Integrated Security=True";
			List<MiscellaneousItem> miscList = new List<MiscellaneousItem>();

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				string query = "SELECT ItemID, ITEMNAME, AMOUNTINSTOCK, CONDITION FROM FP_MiscItem;";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							MiscellaneousItem miscItem = new MiscellaneousItem();
							miscItem.PartId = (int)reader.GetDecimal(0);
							miscItem.PartName = reader.GetString(1);
							miscItem.AmountInstock = (int)reader.GetDecimal(2);
							miscItem.Condition = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);

							miscList.Add(miscItem);
						}
						if (miscList.Count > 0) { }
						else
						{
							throw new Exception();
						}
					}
				}
			}
			return miscList;
		}
	}
}

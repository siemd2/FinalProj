﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProj.Data.Models;
using Microsoft.Data.SqlClient;


namespace FinalProj.Data.Controllers
{
	public class StockQuery
	{
		//Make sure to make the front end split into checking for vehiclepart or miscitem
		//Not Complete
		public VehiclePart VehiclePartQuery(VehiclePart checkPart)
		{
			string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=FinalProjOOP;Integrated Security=True";
			VehiclePart part = new VehiclePart();

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

		//Query For one specific Misc Item by it ID
		public MiscellaneousItem MiscPartQuery(MiscellaneousItem item)
		{
			string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=FinalProjOOP;Integrated Security=True";
			MiscellaneousItem miscItem = new MiscellaneousItem();

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

		//Query for all available vehiclePart
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
					}
				}
			}
			return vehiclePartList;
		}
		//Query All Misc Item
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
					}
				}
			}
			return miscList;
		}
	}
}

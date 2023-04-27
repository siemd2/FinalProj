using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProj.Data.Interfaces;

namespace FinalProj.Data.Models
{
	public class Customer : IUser
	{
		private int id;
		private string name;
		private int phone;
		private string email;
		private string address;

		public int UserId { get => id; set => id = value; }
		public string UserName { get => name; set => name = value; }
		public int PhoneNumber { get => phone; set => phone = value; }
		public string Email { get => email; set => email = value; }
		public string Address { get => address; set => address = value; }


		public Customer(int userID, string userName, int phoneNumber, string email, string address)
		{
			id = userID;
			name = userName;
			phone = phoneNumber;
			this.email = email;
			this.address = address;
		}
		public Customer(int userID, string userName, int phoneNumber, string email)
		{
			id = userID;
			name = userName;
			phone = phoneNumber;
			this.email = email;
		}
		public Customer() { }
	}
}

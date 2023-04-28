using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProj.Data.Interfaces;

namespace FinalProj.Data.Models
{
	// implements Icomponent Interface 
	public class Staff : IUser
	{
		private int id;
		private string name;
		private int phone;
		private string email;

        public int UserId { get => id; set => id = value; }
        public string UserName { get => name; set => name = value; }
        public int PhoneNumber { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }

        // Default constructor
        public Staff()
        {
            
        }

        // creates staff object
        public Staff(int id, string name, int phone, string email)
        {
            this.id = id;
            this.name = name;
            this.phone = phone;
            this.email = email;
        }
    }
}

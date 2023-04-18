using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProj.Data.Interfaces
{
	public interface IUser
	{
		int UserId { get; set; }
		string UserName { get; set; }
		int PhoneNumber { get; set; }
		string Email { get; set; }
	}
}

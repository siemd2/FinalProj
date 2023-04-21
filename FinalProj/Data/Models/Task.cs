using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProj.Data.Models
{
	public class Task
	{
		private int taskId;
		private Vehicle vehicle;
		private Customer customer;
		private int staffId;
		private string taskName;

		public int TaskId { get => taskId; set => taskId = value; }
		public Vehicle Vehicle { get => vehicle; set => vehicle = value; }
		public Customer Customer { get => customer; set => customer = value; }
		public int StaffId { get => staffId; set => staffId = value; }
		public string TaskName { get => taskName; set => taskName = value; }
	}
}

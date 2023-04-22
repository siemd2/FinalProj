using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProj.Data.Models
{
	public class WorkTicket
	{
		private int taskId;
		private Vehicle vehicle;
		private Customer customer;
		private int staffId;
		private string taskName;
		private Service service;

		public int TicketId { get => taskId; set => taskId = value; }
		public Vehicle Vehicle { get => vehicle; set => vehicle = value; }
		public Customer Customer { get => customer; set => customer = value; }
		public int StaffId { get => staffId; set => staffId = value; }
		public string TaskName { get => taskName; set => taskName = value; }
		public Service Service { get => service; set => service = value; }

		public WorkTicket(int taskId, Vehicle vehicle, Customer customer, int staffID, string taskName, Service service)
		{
			this.taskId = taskId;
			this.vehicle = vehicle;
			this.customer = customer;
			this.staffId = staffID;
			this.taskName = taskName;
			this.Service = service;
		}
	}
}

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
		private string serviceDate;

		public int TicketId { get => taskId; set => taskId = value; }
		public Vehicle Vehicle { get => vehicle; set => vehicle = value; }
		public Customer Customer { get => customer; set => customer = value; }
		public int StaffId { get => staffId; set => staffId = value; }
		public string TaskName { get => taskName; set => taskName = value; }
		public Service Service { get => service; set => service = value; }
		public string ServiceDate { get => serviceDate; set => serviceDate = value; }

		public WorkTicket(int taskId, Vehicle vehicle, Customer customer, int staffID, Service service, string serviceDate)
		{
			this.taskId = taskId;
			this.vehicle = vehicle;
			this.customer = customer;
			this.staffId = staffID;
			this.service = service;
			this.serviceDate = serviceDate;
		}

		public WorkTicket(int taskId, int staffId, int customerId, int serviceId, string serviceDate, int vehicleVin, string mmm, 
			string customerName, int phoneNumber, string email, string address)
		{
			this.taskId = taskId;
			Vehicle = new Vehicle(vehicleVin, mmm);
			Customer = new Customer(customerId, customerName, phoneNumber, email, address);
			this.staffId = staffId;
			Service = new Service(serviceId);
			ServiceDate = serviceDate;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProj.Data.Models
{

// this class creates a work ticket. task ID, customer, staff id, task name and service date are the attributes that make up a work ticket in the context of this program.

	public class WorkTicket
	{
		private int taskId;
		private Customer customer; // associates with customer class
		private int staffId;
		private string taskName;
		private Service service; // associates with Service class 
		private string serviceDate;

		public int TicketId { get => taskId; set => taskId = value; }
		public Customer Customer { get => customer; set => customer = value; }
		public int StaffId { get => staffId; set => staffId = value; }
		public string TaskName { get => taskName; set => taskName = value; }
		public Service Service { get => service; set => service = value; }
		public string ServiceDate { get => serviceDate; set => serviceDate = value; }

		public WorkTicket(int taskId, Customer customer, int staffID, Service service, string serviceDate)
		{
			this.taskId = taskId;
			this.customer = customer;
			this.staffId = staffID;
			this.service = service;
			this.serviceDate = serviceDate;
		}
		
		
		//creates WorkTicket Object
		public WorkTicket(int taskId, int staffId, int customerId, int serviceId, string serviceDate,
			string customerName, int phoneNumber, string email, string address, string serviceName)
		{
			this.taskId = taskId;
			Customer = new Customer(customerId, customerName, phoneNumber, email, address);
			this.staffId = staffId;
			Service = new Service(serviceId, serviceName);
			ServiceDate = serviceDate;
		}

		// empty constructor
		public WorkTicket() { }
	}
}

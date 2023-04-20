using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProj.Data.Models
{
    public class WorkOrder
    {
        private int id;
        private Staff staff;
        private Customer customer;
        private Service services;
        private string serviceDate;

        public int Id { get => id; set => id = value; }
        public Staff Staff { get => staff; set => staff = value; }
        public Customer Customer { get => customer; set => customer = value; }
        //public List<Service> Services { get; set; } = new List<Service>();
        public string ServiceDate { get => serviceDate; set => serviceDate = value; }
		public Service Services1 { get => services; set => services = value; }
	}
}

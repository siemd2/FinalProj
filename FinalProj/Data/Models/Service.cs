using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProj.Data.Models
{
    public class Service
    {
        private int id;
        private string name;
        private VehiclePart part;
        private MiscellaneousItem miscellaneousItem; // associates with MiscellaneousItem class
        private int timeRequire;
        private decimal price;
        private string description;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public VehiclePart Part { get => part; set => part = value; }
        public MiscellaneousItem MiscellaneousItem { get => miscellaneousItem; set => miscellaneousItem = value; }
        public int TimeRequire { get => timeRequire; set => timeRequire = value; }
        public decimal Price { get => price; set => price = value; }
		public string Description { get => description; set => description = value; }

	    // id and name cunstructor 
	    public Service(int serviceId, string name)
        {
            Id = serviceId;
            Name = name;
        }
	
	// creates Service object 
        public Service(int id, string name, decimal price, int time, string desc)
        {
            Id = id;
            Name = name;
            Price = price;
            TimeRequire = time;
            Description = desc;
        }
    }
}

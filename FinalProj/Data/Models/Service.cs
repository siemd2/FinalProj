﻿using System;
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
        private MiscellaneousItem miscellaneousItem;
        //private VehiclePart vehiclePart;
        private int timeRequire;
        private double price;
        private string description;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public VehiclePart Part { get => part; set => part = value; }
        public MiscellaneousItem MiscellaneousItem { get => miscellaneousItem; set => miscellaneousItem = value; }
        //public VehiclePart VehiclePart { get => vehiclePart; set => vehiclePart = value; }
        public int TimeRequire { get => timeRequire; set => timeRequire = value; }
        public double Price { get => price; set => price = value; }
		public string Description { get => description; set => description = value; }

		public Service(int serviceId, string name)
        {
            Id = serviceId;
            Name = name;
        }

        public Service(int id, string name, double price, int time, string desc)
        {
            Id = id;
            Name = name;
            Price = price;
            TimeRequire = time;
            Description = desc;
        }
    }
}

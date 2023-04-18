﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProj.Data.I;
using FinalProj.Data.Interfaces;

namespace FinalProj.Data.Models
{
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
    }
}
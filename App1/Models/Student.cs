﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App1.Models
{
    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }

        public override string ToString() => $"{this.StudentID}\n{this.FirstName}\n{this.MiddleName}\n{this.LastName}\n{this.Group}\n{this.DateOfBirth}";
    }
}

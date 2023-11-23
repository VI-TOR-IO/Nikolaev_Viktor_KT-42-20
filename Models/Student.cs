﻿using System.Text.Json.Serialization;

namespace _3_lab.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public int GroupId { get; set; }

        [JsonIgnore]
        public Group? Group { get; set; }
        //public Group? Group { get; set; }

        public string FIO
        {
            get
            {
                return FirstName + " " + LastName + " " + MiddleName;
            }
        }
    }
}

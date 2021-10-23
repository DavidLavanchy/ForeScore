﻿using ForeScore.Contracts;
using ForeScore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.CourseModels
{
    public class CourseEdit : ContactInformation
    {
        public string Name { get; set; }
        public float Slope { get; set; }
        public float Rating { get; set; }
        public int Par { get; set; }
        public List<Hole> Holes { get; set; }
    }
}

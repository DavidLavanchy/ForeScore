﻿using ForeScore.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Data
{
    public class Course : ContactInformation
    {
        [Key]
        public int CourseId { get; set; }
        public string Name { get; set; }
        public float Slope { get; set; }
        public float Rating { get; set; }
        public int Par { get; set; }
        [MinLength(9)]
        [MaxLength(18)]
        public List<Hole> Holes { get; set; }

    }
}


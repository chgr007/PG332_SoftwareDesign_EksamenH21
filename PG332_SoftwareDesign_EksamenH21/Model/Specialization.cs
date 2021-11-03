﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG332_SoftwareDesign_EksamenH21.Model
{
    class Specialization
    {
        public Semester[] Semesters { get; set; }
        [NotMapped]
        public IProgression Progression { get; set; }
    }
}

using PG332_SoftwareDesign_EksamenH21.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class Task : IFinishable
    {
        public long Id { get; set; }
        public string Name { get; set; }
        [NotMapped] public bool Published { get; set; } = false;
        [NotMapped] public bool Finished { get; set; } = false;
    }
}
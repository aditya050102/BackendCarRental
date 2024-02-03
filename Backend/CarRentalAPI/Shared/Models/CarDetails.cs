using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class CarDetails
    {
        public Guid Id { get; set; }
        public string? Maker { get; set; }
        public int Model { get; set; }
        public int RentalPrice { get; set; }
        public bool Availability { get; set; }
    }
}

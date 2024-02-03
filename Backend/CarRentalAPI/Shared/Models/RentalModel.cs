using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class RentalModel
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public string? Car { get; set; }
        public string? UserEmail { get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; } 
        public decimal Amount { get; set; }
        public string? ReturnRequestStatus { get; set; }


    }
}

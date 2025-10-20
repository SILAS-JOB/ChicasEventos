using System.Collections.Generic;
using ChicasEventos.Models;

namespace ChicasEventos.Models
{
    public class StaffingServiceViewModel
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public List<PricingOptionViewModel> PricingOptions { get; set; }
    }
}
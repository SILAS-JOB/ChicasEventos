using System.Collections.Generic;
using ChicasEventos.Models;

namespace ChicasEventos.Models
{
    public class StaffingServiceViewModel
    {
        public int Id { get; set; }
        public string Category { get; set; } // "RH", "Audiovisual", etc.
        public string Title { get; set; } // Ex: "Garçom (por pessoa)"
        public string Description { get; set; } // Ex: "Atendimento profissional e especializado"
        public List<PricingOptionViewModel> PricingOptions { get; set; }
    }
}
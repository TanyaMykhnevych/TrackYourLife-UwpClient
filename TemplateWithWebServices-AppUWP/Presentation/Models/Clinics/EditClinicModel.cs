using System.ComponentModel.DataAnnotations;

namespace UwpClientApp.Presentation.Models.Clinics
{
    public class EditClinicModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ContactEmail { get; set; }

        public string ContactPhone { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string AddressLine1 { get; set; }

        public string Longitude { get; set; }
        public string Altitude { get; set; }
    }
}

using UwpClientApp.Data.Entities;

namespace UwpClientApp.Presentation.Models.Clinics
{
    public class ClinicListItemModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ContactPhone { get; set; }
        public string AddressLine1 { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
    }
}

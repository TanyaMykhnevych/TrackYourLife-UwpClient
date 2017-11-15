﻿namespace UwpClientApp.Presentation.Models.Clinics
{
    public class ClinicDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ContactEmail { get; set; }

        public string ContactPhone { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
        public string AddressLine1 { get; set; }

        public string Longitude { get; set; }
        public string Altitude { get; set; }
    }
}
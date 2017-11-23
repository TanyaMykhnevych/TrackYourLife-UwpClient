using System;

namespace UwpClientApp.Presentation.Models.UserInfo
{
    public class UserInfoDetailedModel
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Notes { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public string PhoneNumber { get; set; }
    }
}

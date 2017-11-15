using System;
using System.ComponentModel.DataAnnotations;

namespace UwpClientApp.Presentation.Models.OrganInfos
{
    public class EditOrganInfoViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }


        public TimeSpan OutsideHumanPossibleTime { get; set; }
    }
}

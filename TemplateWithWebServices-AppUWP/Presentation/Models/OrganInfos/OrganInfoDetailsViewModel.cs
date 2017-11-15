using System;

namespace UwpClientApp.Presentation.Models.OrganInfos
{
    public class OrganInfoDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public TimeSpan OutsideHumanPossibleTime { get; set; }
    }
}

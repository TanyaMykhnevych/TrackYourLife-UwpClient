using System;
using UwpClientApp.Data.Entities.Base;

namespace UwpClientApp.Data.Entities.Organ
{
    public class OrganInfo : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public TimeSpan OutsideHumanPossibleTime { get; set; }
    }
}

﻿using System;
using UwpClientApp.Data.Entities.Organ;

namespace UwpClientApp.Presentation.Models.OrganInfos
{
    public class OrganInfoDetailsModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public TimeSpan OutsideHumanPossibleTime { get; set; }
    }
}

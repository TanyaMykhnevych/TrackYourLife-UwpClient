﻿using System;

namespace UwpClientApp.Data.Entities.Base
{
    public class BaseEntity : IBaseEntity
    {
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }

        public string UpdatedBy { get; set; }
        public DateTime? Updated { get; set; }
    }
}
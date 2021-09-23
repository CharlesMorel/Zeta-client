﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZetaClient.Entities.Enums;

namespace ZetaClient.Entities
{
    public class FrisbeeModel : AbstractEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string pUHT { get; set; }
        public RangeType Range { get; set; }
    }
}

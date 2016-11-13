﻿using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Model
{
    public class TravelUnit : SetupEntity
    {
        public double Rate { get; set; }

        public Currency Currency { get; set; }
    }
}

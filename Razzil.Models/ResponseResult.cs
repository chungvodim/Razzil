﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Razzil.Models
{
    public class ResponseResult
    {
        public ResponseStatusEnum Status { get; set; }
        public string Data { get; set; }
    }
}

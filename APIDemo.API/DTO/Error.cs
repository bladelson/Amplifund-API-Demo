using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDemo.API.DTO
{
    public class Error(string Detail)
    {
        public string Detail { get; set; } = Detail;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuitarsShop.Models
{
    public class Guitar
    {
        public long GuitarId { get; set; }
        public long SerialNum { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public float Value { get; set; }
    }
}
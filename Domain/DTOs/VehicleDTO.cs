using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public record VehicleDTO //record é uma instancia menor que uma classe
    {
        public string Name { get; set; } = default!;
        public string Vendor { get; set; } = default!;
        
        public int FabricationYear { get; set; } = default!;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Vehicles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = default!;
        [Required]
        [StringLength(150)]
        public string Name { get; set; } = default!;
        [Required]
        [StringLength(100)]
        public string Vendor { get; set; } = default!;
        [Required]
        public int FabricationYear { get; set; } = default!;
    }
}
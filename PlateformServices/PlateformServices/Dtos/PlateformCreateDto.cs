using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlateformServices.Dtos
{
    public class PlateformCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        public string Cost { get; set; }
    }
}

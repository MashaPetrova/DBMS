using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureSkating
{
    class Competition
    {
        public int Id { get; set; }

        [MaxLength(70)]
        [Required]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public string City { get; set; }

        [MaxLength(50)]
        [Required]
        public string Country { get; set; }

        public ICollection<FigureSkater> FigureSkaters { get; set; }

        public Competition()
        {
            FigureSkaters = new List<FigureSkater>();
        }
    }
}

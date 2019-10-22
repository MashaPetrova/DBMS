using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureSkating
{
    class FigureSkater
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }
        
        public int? Age { get; set; }

        [MaxLength(50)]
        [Required]
        public string Country { get; set; }

        public ICollection<Competition> Competitions { get; set; }

        public FigureSkater()
        {
            Competitions = new List<Competition>();
        }

    }
}

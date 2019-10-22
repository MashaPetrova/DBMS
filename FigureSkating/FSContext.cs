using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FigureSkating
{
    class FSContext : DbContext
    {
        public FSContext() : base("Connection") { }
        public DbSet<FigureSkater> FigureSkaters { get; set; }
        public DbSet<Competition> Competitions { get; set; }
    }
}

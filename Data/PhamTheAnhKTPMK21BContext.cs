using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhamTheAnhKTPMK21B.Models;

namespace PhamTheAnhKTPMK21B.Data
{
    public class PhamTheAnhKTPMK21BContext : DbContext
    {
        public PhamTheAnhKTPMK21BContext (DbContextOptions<PhamTheAnhKTPMK21BContext> options)
            : base(options)
        {
        }

        public DbSet<PhamTheAnhKTPMK21B.Models.Habitat> Habitat { get; set; } = default!;
        public DbSet<PhamTheAnhKTPMK21B.Models.Animal> Animal { get; set; } = default!;
    }
}

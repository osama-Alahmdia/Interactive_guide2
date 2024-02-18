using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Interactive_guide2.Models;

namespace Interactive_guide2.Data
{
    public class Interactive_guide2Context : DbContext
    {
        public Interactive_guide2Context (DbContextOptions<Interactive_guide2Context> options)
            : base(options)
        {
        }

        public DbSet<Interactive_guide2.Models.orangs> orangs { get; set; } = default!;
    }
}

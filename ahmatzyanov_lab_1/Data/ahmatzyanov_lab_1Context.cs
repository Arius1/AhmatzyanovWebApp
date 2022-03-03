using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ahmatzyanov_lab_1.Models;

namespace ahmatzyanov_lab_1.Data
{
    public class ahmatzyanov_lab_1Context : DbContext
    {
        public ahmatzyanov_lab_1Context (DbContextOptions<ahmatzyanov_lab_1Context> options)
            : base(options)
        {
        }

        public DbSet<ahmatzyanov_lab_1.Models.EngineOil> EngineOil { get; set; }
    }
}

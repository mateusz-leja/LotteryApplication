using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryAPI.Models
{
    public class DrawHistoryContext:DbContext
    {
        public DrawHistoryContext(DbContextOptions<DrawHistoryContext> options):base(options)
        {

        }

        public DbSet<DrawHistory> DrawHistories { get; set; }
    }
}

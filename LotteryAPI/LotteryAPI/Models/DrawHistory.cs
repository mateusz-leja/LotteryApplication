using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryAPI.Models
{
    public class DrawHistory
    {
        [Key]
        public int Id { get; set; }
        public int DrawId { get; set; }
        public string Date { get; set; }
        public int Draw { get; set; }
    }
}

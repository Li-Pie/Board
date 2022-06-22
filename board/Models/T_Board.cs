using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace board.Models
{
    public class T_Board
    {
        [Key]
        public int No { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime SysRegDT { get; set; }
    }
}

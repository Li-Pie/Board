using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using board.Models;
namespace board.Models
{
    public class BoardDbcontext : DbContext
    {
        public BoardDbcontext(DbContextOptions<BoardDbcontext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {

        }

        public DbSet<T_Board> T_board { get; set; }
    }
}

    


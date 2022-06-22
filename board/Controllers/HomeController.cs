using board.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace board.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BoardDbcontext _context;

        public HomeController(ILogger<HomeController> logger, BoardDbcontext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //리스트
        public IActionResult list()
        {
            var board = _context.T_board.OrderByDescending(x => x.No).ToList();
            ViewBag.board = board;
            return View();
        }

        //글쓰기
        public IActionResult write()
        {
            return View();
        }
        //글쓰기
        [HttpPost]
        public IActionResult write(T_Board model)
        {
            model.SysRegDT = DateTime.Now;
            _context.T_board.Add(model);
            _context.SaveChanges();
            return Redirect("/home/list");
        }

        //상세보기
        public IActionResult detail(int id)
        {
            var board = _context.T_board.Where(x => x.No.Equals(id)).FirstOrDefault();

            ViewBag.board = board;
            return View();
        }

        //삭제
        public IActionResult delete(int id)
        {

            var board = _context.T_board.Where(x => x.No.Equals(id)).FirstOrDefault();
            _context.Entry(board).State = EntityState.Deleted;
            _context.SaveChanges();
            return Redirect("/home/list");
        }

        public IActionResult edit(int id)
        {
            var board = _context.T_board.Where(x => x.No.Equals(id)).FirstOrDefault();
                ViewBag.board = board;

            return View();
        }

        [HttpPost]
        public IActionResult edit(T_Board model)
        {
            var board = _context.T_board.Where(x => x.No.Equals(model.No)).FirstOrDefault();
            board.Content = model.Content;
            board.Subject = model.Subject;
            _context.Entry(board).State = EntityState.Modified;
            _context.SaveChanges();

            return Redirect("/home/list");
        }





        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

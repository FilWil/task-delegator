﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskDelegator.Data;
using TaskDelegator.Models;

namespace TaskDelegator.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskDelegatorContext _context;

        public HomeController(TaskDelegatorContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //var assigmentModels = new HttpGetAttribute("d");

            var model = new TasksDistributorViewModel
            {
                Assignments = _context.Assignments.Include(a => a.User).Where(a => a.User == null),
                Users = _context.Users.Include(u => u.Assignments)
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

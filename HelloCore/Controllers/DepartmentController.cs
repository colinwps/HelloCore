using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelloCore.Services;
using HelloCore.Models;

namespace HelloCore.Controllers
{
    public class DepartmentController:Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "部门首页";
            var departments = _departmentService.GetAll();
            return View(departments);
        }

        public IActionResult Add()
        {
            ViewBag.Title = "添加部门";
            return View(new Department());
        }
        [HttpPost]
        public async Task<IActionResult> Add(Department department)
        {
            if (ModelState.IsValid)
            {
                await _departmentService.Add(department);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}

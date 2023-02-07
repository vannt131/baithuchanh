using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThucHanh.Models;

namespace ThucHanh.Controllers
{
    public class StudentController : Controller
    {
        private readonly ThucHanhDbContext _context;
        public StudentController(ThucHanhDbContext context)
        {
            _context = context;
        }
        // GET: StudentController
        public ActionResult Index()
        {
            return View(_context.Students.ToList());
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View(_context.Students.Find(id));
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Students.Add(model);
                    var result = _context.SaveChanges();
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                        return View(model);
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_context.Students.Find(id));
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Entry(model).State = EntityState.Modified;
                    var result = _context.SaveChanges();
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                        return View(model);
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_context.Students.Find(id));
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            try
            {
                var model = _context.Students.Find(id);
                _context.Students.Remove(model ?? throw new InvalidOperationException());
                var result = _context.SaveChanges();
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    return View(model);
            }
            catch
            {
                return View();
            }
        }
    }
}

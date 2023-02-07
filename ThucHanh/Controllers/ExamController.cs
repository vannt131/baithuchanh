using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThucHanh.Models;

namespace ThucHanh.Controllers
{
    public class ExamController : Controller
    {
        private readonly ThucHanhDbContext _context;
        public ExamController(ThucHanhDbContext context)
        {
            _context = context;
        }
        // GET: ExamController
        public ActionResult Index()
        {
            return View(_context.Exams.ToList());
        }

        // GET: ExamController/Details/5
        public ActionResult Details(int id)
        {
            return View(_context.Exams.Find(id));
        }

        // GET: ExamController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Exam model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Exams.Add(model);
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

        // GET: ExamController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_context.Exams.Find(id));
        }

        // POST: ExamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Exam model)
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

        // GET: ExamController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_context.Exams.Find(id));
        }

        // POST: ExamController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            try
            {
                var model = _context.Exams.Find(id);
                _context.Exams.Remove(model ?? throw new InvalidOperationException());
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

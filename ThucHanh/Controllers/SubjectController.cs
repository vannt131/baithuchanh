using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThucHanh.Models;

namespace ThucHanh.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ThucHanhDbContext _context;
        public SubjectController(ThucHanhDbContext context)
        {
            _context = context;
        }
        // GET: SubjectController
        public ActionResult Index()
        {
            return View(_context.Subjects.ToList());
        }

        // GET: SubjectController/Details/5
        public ActionResult Details(int id)
        {
            return View(_context.Subjects.Find(id));
        }

        // GET: SubjectController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Subject model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Subjects.Add(model);
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

        // GET: SubjectController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_context.Subjects.Find(id));
        }

        // POST: SubjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Subject model)
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

        // GET: SubjectController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_context.Subjects.Find(id));
        }

        // POST: SubjectController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            try
            {
                var model = _context.Subjects.Find(id);
                _context.Subjects.Remove(model ?? throw new InvalidOperationException());
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

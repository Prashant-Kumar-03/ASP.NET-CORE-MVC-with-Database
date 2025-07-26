using ProjectMVCwithDatabase.Data;
using ProjectMVCwithDatabase.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProjectMVCwithDatabase.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Show all students
        public IActionResult Index()
        {
            List<Student> studentList = _dbContext.Students.ToList();
            return View(studentList);
        }

        // Show create form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Save new student
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Students.Add(student);
                _dbContext.SaveChanges();
                TempData["success"] = "Student saved successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }

        // Show edit form
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Student? student = _dbContext.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // Save edited student
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Students.Update(student);
                _dbContext.SaveChanges();
                TempData["success"] = "Student updated successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }

        // Show delete confirmation
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Student? student = _dbContext.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // Delete the student
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Student? student = _dbContext.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            _dbContext.Students.Remove(student);
            _dbContext.SaveChanges();
            TempData["success"] = "Student deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}

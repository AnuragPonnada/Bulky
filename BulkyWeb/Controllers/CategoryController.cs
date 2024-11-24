using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        //working with database to insert values
        private readonly MyContext _context = null;
        //dependency injection
        public CategoryController(MyContext context)
        {
            _context = context;
        }
       
        public IActionResult Index()
        {
            return View();
        }
        //http post request for the student form
        [HttpPost]
        public IActionResult Index(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newStudent = new MyData()
                    {
                        Name = student.Name,
                        Age = student.Age,
                        Standard = student.Standard,
                    };
                    _context.Student.Add(newStudent);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Student has been added!";
                    return RedirectToAction("Display");

                }
                else
                {
                    TempData["errorMessage"] = "Model data is not valid!";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }

        }
        // reading values from database
        [HttpGet]
        public IActionResult Display()
        {
            //Student table in the database
            var students = _context.Student.ToList();
            // Student model used to create form
            List<Student> studentsList = new List<Student>();
            if (students != null)
            {
                foreach (var student in students)
                {
                    // Student model used in form
                    var StudentView = new Student()
                    {
                        Id = student.Id,
                        Name = student.Name,
                        Age = student.Age,
                        Standard = student.Standard
                    };
                    studentsList.Add(StudentView);
                }
                return View(studentsList);
            }
            return View(studentsList);
        }
        // Editing records --> contains get and post
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var student = _context.Student.SingleOrDefault(x => x.Id == Id);
            if(student != null)
            {
                var StudentView = new Student()
                {
                    Id = student.Id,
                    Name = student.Name,
                    Age= student.Age,
                    Standard = student.Standard
                };
                return View(StudentView);
            }
            else
            {
                TempData["errorMessage"] = $"No Student available with the Id: {Id}";
                return RedirectToAction("Display");
            }
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var updateStudent = new MyData()
                    {
                        Id = student.Id,
                        Name = student.Name,
                        Age = student.Age,
                        Standard = student.Standard
                    };
                    // here "Student" is the table name in database
                    _context.Student.Update(updateStudent);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Student updated successfully!";
                    return RedirectToAction("Display");
                }
                else
                {
                    TempData["errorMessage"] = "Model data is not valid!";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = "Model data is not valid!";
                return View();
            }
            
        }

        // delete records --> contains get and post
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var student = _context.Student.SingleOrDefault(x=> x.Id == Id);
            if (student != null)
            {
                var StudentView = new Student()
                {
                    Id = student.Id,
                    Name = student.Name,
                    Age = student.Age,
                    Standard = student.Standard
                };
                return View(StudentView);
            }
            else
            {
                TempData["errorMessage"] = $"No student available with the Id: {Id}";
                return RedirectToAction("Display");
            }
            
        }
        [HttpPost]
        public IActionResult Delete(Student student)
        {
            var studentDelete = _context.Student.SingleOrDefault(x => x.Id == student.Id);
            try
            {
                if (studentDelete != null)
                {
                    _context.Student.Remove(studentDelete);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Student deleted successfully!";
                    return RedirectToAction("Display");
                }
                else
                {
                    TempData["errorMessage"] = $"No student available with the Id: {student.Id}";
                    return RedirectToAction("Display");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
        //[Route("/category/test")]
        //public string Test()
        //{
        //    return "Hello testing custom route";
        //}
        
        
    }
}

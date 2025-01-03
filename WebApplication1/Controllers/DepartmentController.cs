using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IMemoryCache _cache;

        public DepartmentController(IMemoryCache cache)
        {
            _cache = cache;
        }

        public IActionResult Index()
        {
            const string cacheKey = "studentList";
            if (!_cache.TryGetValue(cacheKey, out List<Student> studentList))
            {
                // Assuming "Something" is a service; replace with an actual implementation
                Something service = new Something();
                studentList = service.GetDependent();

                // Cache the data
                _cache.Set(cacheKey, studentList, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30) // Set an appropriate cache expiration
                });
            }

            return View(studentList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new Student();
            return View(model);
        }
        public IActionResult Edit()
        {
            var model = new Student();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Student model)
        {
            const string cacheKey = "studentList";
            if (!_cache.TryGetValue(cacheKey, out List<Student> studentList))
            {
                studentList = new List<Student>();
            }

            studentList.Add(model);

            // Update the cache
            _cache.Set(cacheKey, studentList);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            object obj = _cache.Get("studentList");
            var dList=(List<Student>)obj;
            var model=new Student();
            var department = dList.FirstOrDefault(e => e.Roll == id);
            if (department is not null)
                model = department;
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Student model) {
            object obj = _cache.Get("studentList");
            var dList = (List<Student>)obj;
            foreach(var d in dList)
            {
                if (d.Roll == model.Roll)
                {
                    d.Name = model.Name;
                    break;
                }
            }
            _cache.Set("studentList", dList);
            return RedirectToAction("Index");
        }
    }
}
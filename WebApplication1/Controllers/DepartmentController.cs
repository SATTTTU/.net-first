using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            Something service = new Something();
            var deplist = service.GetDependent();
            return View(deplist);
           
        }
        public IActionResult Department(string model){
        if(not NULL){
        return(model);
        }
        return(model);
    }
}

using _1670_ApplicationDevelopment_Lab.Data;
using _1670_ApplicationDevelopment_Lab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _1670_ApplicationDevelopment_Lab.Controllers
{
    public class TESTController : Controller
    {
        private readonly ApplicationDBContext _dbContext;
        public TESTController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<TEST> categories = _dbContext.TEST.ToList();
            return View(categories);
        }
    }
}

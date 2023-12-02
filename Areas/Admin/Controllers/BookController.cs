using _1670_ApplicationDevelopment_Lab.Data;
using _1670_ApplicationDevelopment_Lab.Models;
using _1670_ApplicationDevelopment_Lab.Models.ViewModels;
using _1670_ApplicationDevelopment_Lab.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace _1670_ApplicationDevelopment_Lab.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BookController : Controller
    {
        
        //private readonly ApplicationDBContext _dbContext;
        // private readonly IBookRepository bookRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IWebHostEnvironment _webhost;
        public BookController(IUnitOfWork unitOfWork, IWebHostEnvironment webhost)
        {
            _unitOfWork = unitOfWork;
            _webhost = webhost;
        }
        public IActionResult Index()
        {
            List<Book> books = _unitOfWork.BookRepository.GetAll("Category").ToList();
            return View(books);
        }

        public IActionResult CreateUpdate(int? id)
        {
            BookVM bookVM = new BookVM()
            {
                MyCategories = _unitOfWork.CategoryRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Book = new Book()
            };
            if (id == null || id == 0)
            {
                //Create new Book
                return View(bookVM);
            }
            else
            {
                // Update a Book
                bookVM.Book = _unitOfWork.BookRepository.Get(b => b.Id == id);
                return View(bookVM);
            }

        }

        [HttpPost]
        public IActionResult CreateUpdate(BookVM bookVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRoothPath = _webhost.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string bookPath = Path.Combine(wwwRoothPath, "img");
                    if (!string.IsNullOrEmpty(bookVM.Book.ImageUrl))
                    {
                        // Delete Old Image
                        var oldImagePath = Path.Combine(wwwRoothPath, bookVM.Book.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }

                    }
                    using (var fileStream = new FileStream(Path.Combine(bookPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    bookVM.Book.ImageUrl = @"\img\" + fileName;
                }
                if (bookVM.Book.Id == 0)
                {
                    _unitOfWork.BookRepository.Add(bookVM.Book);
                    TempData["success"] = "Book created succesfully";
                }
                else
                {
                    _unitOfWork.BookRepository.Update(bookVM.Book);
                    TempData["success"] = "Book updated succesfully";
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                BookVM bookVMNew = new BookVM()
                {
                    MyCategories = _unitOfWork.CategoryRepository.GetAll().Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    }),
                    Book = new Book()
                };
                return View();
            }

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Book book = _unitOfWork.BookRepository.Get(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            _unitOfWork.BookRepository.Remove(book);
            _unitOfWork.Save();
            TempData["success"] = "Book deleted succesfully";
            return RedirectToAction("Index");
        }
    }
}

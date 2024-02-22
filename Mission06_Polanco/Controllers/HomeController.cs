using Microsoft.AspNetCore.Mvc;
using Mission06_Polanco.Models;
using System.Diagnostics;

namespace Mission06_Polanco.Controllers
{
    public class HomeController : Controller
    {
        private FilmCollectionContext _context;

        public HomeController(FilmCollectionContext Films) //Constructor
        {
            _context = Films;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Collection() 
        {
            ViewBag.Categories = _context.Categories
                .ToList();
            return View("Collection", new Collection());
        }

        [HttpPost]
        public IActionResult Collection(Collection response) // We want to receive an instance of the model we created that has all the information of the form 
        {
           // if (ModelState.IsValid)
           // {
                _context.Movies.Add(response); //Adds the records to the database     
                _context.SaveChanges();

                return View("Confirmation", response);
           // }
            // else { ViewBag.Categories = _context.Categories.ToList(); return View(response);}
        }

        public IActionResult CollectionList()
        { //linq
            var collections = _context.Movies
                .OrderBy(x => x.MovieId)
                .ToList();

            return View(collections);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories.ToList();  

            return View("Collection", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Collection UpdatedInfo)
        {
            _context.Update(UpdatedInfo);
            _context.SaveChanges();
            return RedirectToAction("CollectionList");

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var DeleteRecord = _context.Movies
                .Single(x => x.MovieId == id);
            return View(DeleteRecord);  
        }

        [HttpPost]
        public IActionResult Delete(Collection DeleteRecord)
        {
            _context.Movies.Remove(DeleteRecord);
            _context.SaveChanges();

            return RedirectToAction("CollectionList");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

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
            return View();
        }

        [HttpPost]
        public IActionResult Collection(Collection response) // We want to receive an instance of the model we created that has all the information of the form 
        {
            _context.Films.Add(response); //Adds the records to the database     
            _context.SaveChanges();     

            return View("Confirmation", response);
        }

        public IActionResult CollectionList()
        {
            var collections = _context.Films
                .OrderBy(x => x.FilmID).ToList();
            return View(collections);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Films
                .Single(x => x.FilmID == id);
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
            var DeleteRecord = _context.Films
                .Single(x => x.FilmID == id);
            return View(DeleteRecord);  
        }

        [HttpPost]
        public IActionResult Delete(Collection DeleteRecord)
        {
            _context.Films.Remove(DeleteRecord);
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

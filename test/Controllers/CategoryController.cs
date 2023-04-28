using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using test.Models;
using test.Repository.Base;
using TestCoreApp.Repository.Base;

namespace test.Controllers
{
    public class CategoryController : Controller
    {
        //public CategoryController(IRepository<Category> repository) 
        //{
        //    _repository = repository;
        //}
        public CategoryController(IUnitOfWork _myUnit)
        {
            myUnit = _myUnit;
        }
        //private IRepository<Category> _repository;
        private readonly IUnitOfWork myUnit;
        //public IActionResult Index()
        //{
        //    return View(_repository.FindAll());
        //}
        public async Task <IActionResult> Index()
        {
            //var oneCat = _repository.SelectOne(x => x.Name == "Laptop");
            var allCat = await myUnit.categories.FindAllAsync("Items");

            return View(allCat);
        }
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Category category)
        {
            if (ModelState.IsValid)
            {
                myUnit.categories.AddOne(category);
                TempData["SuccessData"] = "Category has been added Successfully";
                return RedirectToAction("Index");
            }
            else
            {

            return View(category);
            }
        }
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var category = myUnit.categories.FindById(Id.Value);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                myUnit.categories.UpdateOne(category);
                TempData["EditData"] = "Category has been updated Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                    
            return View(category);
            }
        }
        public IActionResult Delete(int? Id)
        {

            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var category = myUnit.categories.FindById(Id.Value);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category category)
        {

           
            myUnit.categories.DeleteOne(category);
            TempData["DeleteData"] = "Category has been deleted Successfully";

            return RedirectToAction("Index", "Category");
          
        }
    }
}

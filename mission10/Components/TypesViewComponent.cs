using System;
using System.Linq;
using mission10.Models;
using Microsoft.AspNetCore.Mvc;

//Essentially the controller for the view component and filtering the book category

namespace mission10.Components
{
	public class TypesViewComponent : ViewComponent
    {
        private IBookstoreRepository repo { get; set; }

        public TypesViewComponent(IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["bookType"];

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}


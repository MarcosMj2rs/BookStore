using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
	public class CataloguesController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

using Microsoft.AspNetCore.Mvc;
using MVCLearn1.Models;

namespace MVCLearn1.Controllers
{
	public class LoginController : Controller
	{
        ApplicationDBContext1 db;
        User obj;
        public LoginController(ApplicationDBContext1 _db)
        {
            obj= new User();
            db = _db;
        }
        public IActionResult Index()
		{
			return View();
		}
        public IActionResult Register(User ObjUser)
        {
            db.Users.Add(ObjUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

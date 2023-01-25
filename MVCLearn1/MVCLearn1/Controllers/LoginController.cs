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
            var lst = db.Users.ToList();
            List<User> lstUser = new List<User>();
            //User user= new User();
            //user.Name = "Anil";
            //user.Email = "anil39@gmail.com";
            //user.Password = "9867";
            //lstUser.Add(user);
			return View(lst);
		}
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User ObjUser)
        {
            db.Users.Add(ObjUser);
            db.SaveChanges();
            return RedirectToAction("Index");
            //return View();
        }
        public IActionResult Edit(int Id)
        {
            var obj = db.Users.FirstOrDefault(x => x.Id == Id);
            if (Id == null)
            {
                
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        public IActionResult Edit(User Objuser)
        {
            if(ModelState.IsValid )
            { 
           
            var founduser = db.Users.Find(Objuser.Id);
            if (founduser != null)
            {
                founduser.Name = Objuser.Name;
                founduser.Email = Objuser.Email;
                founduser.Password = Objuser.Password;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            }
            return View();           
        }


        public IActionResult Delete(int Id)
        {
            var founduser = db.Users.Find(Id);
            db.Users.Remove(founduser);
            db.SaveChanges();
            return RedirectToAction("Index");
            
            //if (Id == null)
            //{

            //    return NotFound();
            //}
            //var founduser = db.Users.FirstOrDefault(x => x.Id == Id);
            //return View(founduser);
        }
        //[HttpPost]
        //public IActionResult Delete(int Id)
        //{
        //    var founduser = db.Users.Find(Id);
        //    if (founduser == null)
        //    {
        //        return NotFound();
        //    }
        //    db.Users.Remove(founduser);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");

        //}
        [HttpPost]
        public IActionResult Deletepost(int Id)
        {
            //if (ModelState.IsValid)
            //{
            var founduser = db.Users.Find(Id);
            db.Users.Remove(founduser);
            db.SaveChanges();
            return RedirectToAction("Index");
            //}

            //return RedirectToAction("Register");

        }


    }
}

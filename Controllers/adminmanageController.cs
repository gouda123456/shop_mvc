using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using shop_mvc.Models;


namespace shop_mvc.Controllers
{
    public class adminmanageController1 : Controller
    {
        private context db;
        public adminmanageController1(context context)
        {
            db = context;
        }


        public IActionResult Index()
        {
            var user = db.Users.ToList();
            return View(user);
        }
        public IActionResult update(string id) 
        {
            //var userid = db.Users.FirstOrDefault(x => x.Id == id);
            //var roleid = db.Roles.FirstOrDefault(x => x.Id == "1");
            ////var userrole = new IdentityUserRole<shop_mvc.Models.iuser>() { UserId = userid, RoleId = "1" };

            db.UserRoles.Add(new IdentityUserRole<string> { UserId = id, RoleId = "1" });
            return RedirectToAction("Index");
        }
        public IActionResult down(int id)
        {
            db.UserRoles.Add(new IdentityUserRole<string> { UserId = id.ToString(), RoleId = "2" });
            return RedirectToAction("Index");
        }
    }
}

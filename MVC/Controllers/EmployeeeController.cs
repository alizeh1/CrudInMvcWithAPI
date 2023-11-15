using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class EmployeeeController : Controller
    {
        // GET: Employeee
        public ActionResult Index()
        {
            IEnumerable<MVCEmployeeModel> emplist;
            HttpResponseMessage response=GlobalVariables.webapi.GetAsync("tblUsers").Result;
            emplist = response.Content.ReadAsAsync<IEnumerable<MVCEmployeeModel>>().Result;
            return View(emplist);
        }

        [HttpGet]
        public ActionResult AddOrEditUser(int id=0)
        {
            if(id==0)
            return View(new MVCEmployeeModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.webapi.GetAsync("tblUsers/"+id).Result;
                return View(response.Content.ReadAsAsync<MVCEmployeeModel>().Result);
            }
        }

        public ActionResult AddOrEditUser(MVCEmployeeModel user)
        {
            if (user.UserId == 0) { 
            HttpResponseMessage response = GlobalVariables.webapi.PostAsJsonAsync("tblUsers",user).Result;
            TempData["Success"] = "Saved Successfully";
           
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapi.PutAsJsonAsync("tblUsers/"+user.UserId, user).Result;
                TempData["Success"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteUser(int id) {
            HttpResponseMessage response = GlobalVariables.webapi.DeleteAsync("tblUsers/" + id).Result;
            TempData["Success"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }

        
    }
}
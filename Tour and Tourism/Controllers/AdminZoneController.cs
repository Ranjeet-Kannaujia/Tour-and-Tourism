using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_and_Tourism.Models;

namespace Tour_and_Tourism.Controllers
{
    public class AdminZoneController : Controller
    {
        //
        // GET: /AdminZone/
        tourismEntities db = new tourismEntities();



        public ActionResult Index()
        {
            if (Session["aid"] != null)
            {

            }
            else
            {
                Response.Write("<script>alert('Login First Then Go To Next Zone');window.location.href='/home/login'</script>");
            }
            return View();
        }
        public ActionResult ContactMgmt()
        {
            if (Session["aid"] != null)
            {

            }
            else
            {
                Response.Write("<script>alert('Login First Then Go To Next Zone');window.location.href='/home/login'</script>");
            }
            List<Contact> lst = null;
            lst = db.Contacts.ToList();
            return View(lst);
        }
        public ActionResult RegistrationMgmt()
        {
            if (Session["aid"] != null)
            {


            }
            else
            {
                Response.Write("<script>alert('Login First Then Go To Next Zone');window.location.href='/home/login'</script>");
            }
            List<TBL_registration> lst = null;
            lst = db.TBL_registration.ToList();

            return View(lst);
        }
        public ActionResult FeedbackMgmt()
        {
            if (Session["aid"] != null)
            {

            }
            else
            {
                Response.Write("<script>alert('Login First Then Go To Next Zone');window.location.href='/home/login'</script>");
            }
            List<TBL_feedback> lst = null;
            lst = db.TBL_feedback.ToList();
            return View(lst);
        }
        public ActionResult BookingMgmt()
        {
            if (Session["aid"] != null)
            {

            }
            else
            {
                Response.Write("<script>alert('Login First Then Go To Next Zone');window.location.href='/home/login'</script>");
            }
            List<TBL_Booking> lst = null;
            lst = db.TBL_Booking.ToList();
            return View(lst);
        }
        public ActionResult Changepass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Changepass(string NewPass, string OldPass, string ConfirmPass)
        {
            if (NewPass == ConfirmPass)
            {
                string email = Session["aid"].ToString();
                TBL_Login con = db.TBL_Login.Where(x => x.password == OldPass && x.email == x.email).SingleOrDefault();
                con.password = NewPass;
                db.SaveChanges();
                Response.Write("<script>alert('Password Changed Successfully');window.location.href='/home/login'</script>");
            }
            {
                return View();
            }
        }
        public void Logout()
        {
            Session.Abandon();
            Response.Write("<script>alert('Logout Successfully');window.location.href='/home/login'</script>");
        }

        public void delete()
        {
            try
            {
                string m = Request.QueryString["m"];
                TBL_registration TBL = db.TBL_registration.SingleOrDefault(x => x.Email == m);
                db.TBL_registration.Remove(TBL);
                db.SaveChanges();
                Response.Write("<script>alert('Record Delete Sucessfully');window.location.href='/adminzone/registrationmgmt'</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Record Not Deleted');window.location.href='/adminzone/registrationmgmt'</script>");
            }
        }
        [HttpGet]
        public ActionResult updaterecord()
        {
            string aid = Request.QueryString["U"];
            TBL_registration lst = db.TBL_registration.SingleOrDefault(a => a.Email == aid);
            return View(lst);
        }
        [HttpPost]
        public void updaterecord(TBL_registration lst, string Email)
        {
            TBL_registration rg = db.TBL_registration.SingleOrDefault(a => a.Email == Email);
            try
            {
                HttpPostedFileBase file = Request.Files["Profile"];
                if (file.FileName != " ")
                {
                    rg.Name = lst.Name;
                    rg.Mobile = lst.Mobile;
                    rg.Profile = file.FileName;
                    rg.Qualification = lst.Qualification;
                    rg.Gender = lst.Gender;
                    rg.DOB = lst.DOB;
                    rg.District = lst.District;
                    rg.RegDate = DateTime.Now.ToString();
                    rg.Address = lst.Address;
                    db.SaveChanges();
                    file.SaveAs(Server.MapPath("../content/photo/" + file.FileName));
                    Response.Write("<script>alert('Record Updated Sucessfully');window.location.href='/AdminZone/RegistrationMgmt'</script>");

                }

                else
                {
                    TBL_registration dd = db.TBL_registration.SingleOrDefault(x => x.Email == Email);
                    dd.Name = lst.Name;
                    dd.Mobile = lst.Mobile;
                    //  rg.Profile = file.FileName;
                    dd.Qualification = lst.Qualification;
                    dd.Gender = lst.Gender;
                    dd.DOB = lst.DOB;
                    dd.District = lst.District;
                    dd.RegDate = DateTime.Now.ToString();
                    dd.Address = lst.Address;
                    db.SaveChanges();
                    // file.SaveAs(Server.MapPath("../content/photo/" + file.FileName));
                    Response.Write("<script>alert('Record Updated Sucessfully')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Record Not Updated')</script>");
            }
        }
    }
}
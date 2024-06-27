using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_and_Tourism.Models;

namespace Tour_and_Tourism.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        tourismEntities db = new tourismEntities();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult feedback()//get action run of view page
        {
            return View();
        }
        [HttpPost]
        public ActionResult feedback(TBL_feedback con)//for post message
        {
            try
            {
                con.Feddate = DateTime.Now.ToString();
                db.TBL_feedback.Add(con);
                db.SaveChanges();
                Response.Write("<script>alert('Thanks For Giving Us Your Valuable Feedback.')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Feedback Not Saved.')</script>");
            }

            {
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TBL_Login lg)

        {
            try
            {
                TBL_Login t1 = db.TBL_Login.Where(x => x.email == lg.email && x.password == lg.password).SingleOrDefault();
                if (t1 != null)
                {
                    Session["aid"] = lg.email; //Set Of Session
                    Response.Write("<script>alert('Welcome To Admin Zone');window.location.href='/Adminzone/index'</script>");
                }
                else
                {
                    Response.Write("<script>alert('Invalid UserId or Password')</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Invalid')</script>");
            }
            return View();
        }
        public ActionResult Gallery()
        {
            return View();
        }
        public ActionResult Explore()
        {
            return View();
        }
        public ActionResult VisaPolicy()
        {
            return View();
        }
        public ActionResult Byroad()
        {
            return View();
        }
        public ActionResult Contact() //get action run of view page
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(Contact con) //For post msg
        {
            try
            {
                con.ContactDate = DateTime.Now.ToString();
                db.Contacts.Add(con);
                db.SaveChanges();
                Response.Write("<script>alert('Record Save Successfully')</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Record  Not Save')</script>");
            }
            {
                return View();
            }


        }
        public ActionResult Bytrain()
        {
            return View();
        }
        public ActionResult Byflight()
        {
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(TBL_registration reg, string hdn1, string ct1)
        {
            try
            {
                if (hdn1 == ct1)
                {
                    //start code of file
                    HttpPostedFileBase file = Request.Files["Profile"];
                    reg.Profile = file.FileName;
                    //End code of file
                    reg.RegDate = DateTime.Now.ToString(); //Use Of Date and Time
                    file.SaveAs(Server.MapPath("~/Content/photo/" + file.FileName));
                    db.TBL_registration.Add(reg);
                    //record insert
                    db.SaveChanges(); //save values as permanently 
                    Response.Write("<script>alert('Record Saved Successfully')</script>");

                }
                else
                {
                    Response.Write("<script>alert('Invalid Captcha Code')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Record Not Saved')</script>");
            }
            {
                return View();
            }


        }
        public ActionResult Booking_form()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Booking_form(TBL_Booking bok, string hdn1, string ct1)
        {
            try
            {
                if (hdn1 == ct1)
                {
                    // bok.checkin = DateTime.Now.ToString();
                    db.TBL_Booking.Add(bok);
                    db.SaveChanges();
                    Response.Write("<script>alert('Booking Record Saved Successfully')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Invalid Captcha Code')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Booking Data Not Saved')</script>");
            }
            {
                return View();
            }

        }

    }
}
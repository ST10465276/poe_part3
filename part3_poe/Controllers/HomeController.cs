using Microsoft.AspNetCore.Mvc;
using part_2API;
using part_2API.backend;
using part_2API.Controllers;
using part_2API.Models;
using part3_poe.Api_backendRequestor;
using part3_poe.Models;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;


namespace part3_poe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //creating an instance for the class auto_createDatabase
            //{} class with a constructor
            new auto_createDatabase() { };

            return View();
        }
        public IActionResult events()
        {
            //creating an isntance for the class FindMarathon with an object name data
            FindMarathon data = new FindMarathon();



            //pass the data
            return View(data);

        }





        [HttpGet]
        public IActionResult BrowseEvents()
        {
            var role = HttpContext.Session.GetString("user_role");
            var userId = HttpContext.Session.GetString("user_id");

            if (string.IsNullOrEmpty(role) || string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult JoinEvent(int eventId)
        {
            var userId = HttpContext.Session.GetString("user_id");
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login");
            }

            manage_join_events manager = new manage_join_events();
            string result = manager.store_enrolment(eventId, HttpContext);

            if (result.StartsWith("Successfully enrolled"))
            {
                TempData["JoinSuccess"] = result;
            }
            else
            {
                TempData["JoinError"] = result;
            }

            return RedirectToAction("BrowseEvents");
        }



        [HttpGet]
        public IActionResult MyJoinedEvents()
        {
            var role = HttpContext.Session.GetString("user_role");
            var userId = HttpContext.Session.GetString("user_id");

            if (string.IsNullOrEmpty(role) || string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CancelEnrolment(int enrolmentId)
        {
            var userId = HttpContext.Session.GetString("user_id");
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login");
            }

            manage_join_events manager = new manage_join_events();
            string result = manager.cancel_enrolment(enrolmentId, HttpContext);

            if (result.StartsWith("Enrolment with id"))
            {
                TempData["CancelSuccess"] = result;
            }
            else
            {
                TempData["CancelError"] = result;
            }

            return RedirectToAction("MyJoinedEvents");
        }





        [HttpGet]
        public IActionResult Participants(int eventId)
        {
            var role = HttpContext.Session.GetString("user_role");
            var userId = HttpContext.Session.GetString("user_id");

            if (string.IsNullOrEmpty(role) || role != "Organizer" || string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login");
            }

            return View(eventId);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult StoreResult(int enrolmentId, TimeSpan? finishTime, int? finishPosition)
        {
            var userId = HttpContext.Session.GetString("user_id");
            if (string.IsNullOrEmpty(userId)) return RedirectToAction("Login");

            manage_results manager = new manage_results();
            string result = manager.store_result(enrolmentId, finishTime, finishPosition, userId, HttpContext);

            if (result == "Result is successfully recorded..")
            {
                TempData["ResultSuccess"] = result;
            }
            else
            {
                TempData["ResultError"] = result;
            }

            return RedirectToAction("Participants", new { eventId = Request.Form["eventId"] });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateResult(int resultId, TimeSpan? finishTime, int? finishPosition)
        {
            var userId = HttpContext.Session.GetString("user_id");
            if (string.IsNullOrEmpty(userId)) return RedirectToAction("Login");

            manage_results manager = new manage_results();
            string result = manager.updating_results(resultId, finishTime, finishPosition, userId, HttpContext);

            if (result.StartsWith("Result with id"))
            {
                TempData["ResultSuccess"] = result;
            }
            else
            {
                TempData["ResultError"] = result;
            }

            return RedirectToAction("Participants", new { eventId = Request.Form["eventId"] });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteResult(int resultId, int eventId)
        {
            var userId = HttpContext.Session.GetString("user_id");
            if (string.IsNullOrEmpty(userId)) return RedirectToAction("Login");

            manage_results manager = new manage_results();
            string result = manager.deleting_results(resultId, userId, HttpContext);

            if (result.StartsWith("Result with id"))
            {
                TempData["ResultSuccess"] = result;
            }
            else
            {
                TempData["ResultError"] = result;
            }

            return RedirectToAction("Participants", new { eventId });
        }













        //login with HttpGet and Post

        [Route("login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserLogin model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            //creating an instance for the class loginApi with an object name send_request
            loginApi send_request = new loginApi();

            //get the results returned
            string results = send_request.userLogin(model.Email , model.Password);

            //check if the login failed or not
            if (!results.Equals("Login successfully...") )
            {
                //assign the error message
                TempData["LoginSuccess"] =results;

                //and return the view with data
                return View(model);

            }

            //get the data
            string[] data = send_request.found_data().Split(',');

            //SETTING UP SESSION
            HttpContext.Session.SetString("user_name", data[0]);
            HttpContext.Session.SetString("user_role", data[1]);
            HttpContext.Session.SetString("user_id", data[2]);
            HttpContext.Session.SetString("user_email", data[3]);

            //if successfully then auto-direct or open the dasboard
            return RedirectToAction("dashboard");
        }







        //login with HttpGet and Post
        [Route("register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [Route("register")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserRegister model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            //creating an instance for the class RegisterApi with an object name send_request
            RegisterApi send_request = new RegisterApi();
            //get the returned message after request
            string results = send_request.registerUser(model.FullName, model.Email , model.Role , model.Password);

            //check the returned message if successfully or not
            if (!results.Equals("User registered successfully.."))
            {
                //assign the error message to show the user if email already have an account or not
                //or any error
                TempData["RegisterSuccess"] = results;

                //then return the view [ reload the page
                return View(model);
            }

            TempData["RegisterSuccess"] = results;
            return RedirectToAction("register");
        
        
        }




        //contact us page with HttpGet and Post
        [Route("contact")]
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }



        [Route("contact")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(ContactMessage model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            TempData["ContactSuccess"] = "Thank you, " + model.Name + ". Your message has been sent.";

            return RedirectToAction("Contact");
      
        
        }





        [Route("dashboard")]
        public IActionResult Dashboard()
        {
            var role = HttpContext.Session.GetString("user_role");
            if (string.IsNullOrEmpty(role))
            {
                return RedirectToAction("Login");
            }

            return View();
        }






        [HttpGet]
        public IActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEvent(EventCreate model)
        {
            var role = HttpContext.Session.GetString("user_role");
            var userId = HttpContext.Session.GetString("user_id");

            if (string.IsNullOrEmpty(role) || role != "Organizer" || string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string imagePath = "";

            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "events");
                Directory.CreateDirectory(uploadsFolder);

                string uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(model.ImageFile.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageFile.CopyTo(stream);
                }

                imagePath = "/images/events/" + uniqueName;
            }

            int organizer_id = Int32.Parse(userId);
            createEvents manager = new createEvents();

            string result = manager.add_event(model.EventName.Trim(), model.Description?.Trim() ?? "", model.Date.Value, model.Location.Trim(), model.Distance.Value, model.EventType.Trim(), model.Age.Value, model.StartTime.Value, organizer_id, model.CategoryId.Value, imagePath);

            if (result == "Event is successfully created..")
            {
                TempData["EventSuccess"] = result;
                return RedirectToAction("CreateEvent");
            }

            TempData["EventError"] = result;
            return View(model);
        }






        [HttpGet]
        public IActionResult Profile()
        {
            var role = HttpContext.Session.GetString("user_role");
            if (string.IsNullOrEmpty(role))
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateProfileDetails(ProfileUpdate model)
        {
            var userId = HttpContext.Session.GetString("user_id");
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login");
            }

            if (!ModelState.IsValid)
            {
                TempData["ProfileError"] = "Please check the form and try again.";
                return RedirectToAction("Profile");
            }

            string currentName = HttpContext.Session.GetString("user_name") ?? "";
            string currentEmail = HttpContext.Session.GetString("user_email") ?? "";

            string choice = "both";
            if (model.FullName != currentName && model.Email == currentEmail) choice = "fullname";
            else if (model.FullName == currentName && model.Email != currentEmail) choice = "email";

            profile_info users_manager = new profile_info();
            string result = users_manager.update_info(model.FullName.Trim(), model.Email.Trim(), choice, HttpContext);

            if (result == "Profile details successfully updated.....")
            {
                TempData["ProfileSuccess"] = result;
            }
            else
            {
                TempData["ProfileError"] = result;
            }

            return RedirectToAction("Profile");
        }





        [HttpGet]
        public IActionResult MyEvents()
        {
            
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEvent(int id)
        {
            var role = HttpContext.Session.GetString("user_role");
            var userId = HttpContext.Session.GetString("user_id");

            if (string.IsNullOrEmpty(role) || role != "Organizer" || string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login");
            }

            int organizer_id = Int32.Parse(userId);
            manage_events manager = new manage_events();
            string result = manager.delete_event(id, organizer_id);

            if (result == "Event is successfully deleted..")
            {
                TempData["EventSuccess"] = result;
            }
            else
            {
                TempData["EventError"] = result;
            }

            return RedirectToAction("MyEvents");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditEvent(Update model)
        {
            var role = HttpContext.Session.GetString("user_role");
            var userId = HttpContext.Session.GetString("user_id");

            if (string.IsNullOrEmpty(role) || role != "Organizer" || string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login");
            }

         

            string imagePath = model.ExistingImage ?? "";

            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "events");
                Directory.CreateDirectory(uploadsFolder);

                string uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(model.ImageFile.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageFile.CopyTo(stream);
                }

                imagePath = "/images/events/" + uniqueName;
            }

            int organizer_id = Int32.Parse(userId);
            manage_events manager = new manage_events();

            string result = manager.update_event(model.EventID.Value, model.EventName.Trim(), model.Description?.Trim() ?? "", model.Date.Value, model.Location.Trim(), model.Distance.Value, model.EventType.Trim(), model.Age.Value, model.StartTime.Value, model.CategoryId.Value, organizer_id, imagePath);

            if (result == "Event is successfully updated..")
            {
                TempData["EventSuccess"] = result;
            }
            else
            {
                TempData["EventError"] = result;
            }

            return RedirectToAction("MyEvents");
        }









        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }





        [HttpGet]
        public IActionResult Categories()
        {
            

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Categories(CategoryCreate model)
        {
            var role = HttpContext.Session.GetString("user_role");
            var userId = HttpContext.Session.GetString("user_id");

            if (string.IsNullOrEmpty(role) || role != "Organizer" || string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            int organizer_id = Int32.Parse(userId);
            add_category manager = new add_category();
            string result = manager.add_categories(model.Name.Trim(), model.Description?.Trim() ?? "", organizer_id);

            if (result == "Category successfully created.....")
            {
                TempData["CategorySuccess"] = result;
            }
            else
            {
                TempData["CategoryError"] = result;
            }

            return RedirectToAction("Categories");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCategory(CategoryEdit model)
        {
            var role = HttpContext.Session.GetString("user_role");
            var userId = HttpContext.Session.GetString("user_id");

            if (string.IsNullOrEmpty(role) || role != "Organizer" || string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login");
            }

            if (!ModelState.IsValid)
            {
                TempData["CategoryError"] = "Please fix the form and try again.";
                return RedirectToAction("Categories");
            }

            int organizer_id = Int32.Parse(userId);
            add_category manager = new add_category();
            string result = manager.update_categories(model.Id, model.Name.Trim(), model.Description?.Trim() ?? "", organizer_id);

            if (result == "Category successfully updated.....")
            {
                TempData["CategorySuccess"] = result;
            }
            else
            {
                TempData["CategoryError"] = result;
            }

            return RedirectToAction("Categories");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(int id)
        {
            var role = HttpContext.Session.GetString("user_role");
            var userId = HttpContext.Session.GetString("user_id");

            if (string.IsNullOrEmpty(role) || role != "Organizer" || string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login");
            }

            int organizer_id = Int32.Parse(userId);
            add_category manager = new add_category();
            string result = manager.delete_categories(id, organizer_id);

            if (result == "Category is successfully deleted..")
            {
                TempData["CategorySuccess"] = result;
            }
            else
            {
                TempData["CategoryError"] = result;
            }

            return RedirectToAction("Categories");
        }



        public IActionResult overview()
        {
            return View();
        }



        public IActionResult about()
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

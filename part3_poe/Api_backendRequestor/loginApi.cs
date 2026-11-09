using part_2API.backend;
using part_2API.Controllers;
namespace part3_poe.Api_backendRequestor
{
    public class loginApi
    {

        //global variable declaration
        private string return_data;

        //mehtod to allow user's to login and assign their details to session
        public string userLogin(string email , string password)
        {

            //creating an instance for the class [controller ] register and login with an object name
            //loginUser
            //due to context lets use controller

            register_and_login loginUser = new register_and_login();

            //get the returned message results
            string results = loginUser.login_users(email,password);
            //get the data of the user
            return_data = loginUser.returned_data();

            //then return the results
            return results;
        }


        //return the data of the user to the controll to assign to the session
        public string found_data()
        {
            //return the data
            return return_data;
        }




    }
}

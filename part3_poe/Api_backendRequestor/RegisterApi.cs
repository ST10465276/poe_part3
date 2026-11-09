using part_2API.backend;
using part_2API.Controllers;

namespace part3_poe.Api_backendRequestor
{
    public class RegisterApi
    {

        //method to send request to the API project
        public string registerUser(string FullName, string Email, string Role, string Password )
        {

            //creating an instance for the class (controller register and login
            //with an object name register_user
            register_and_login register_user = new register_and_login();

            //get the respond message returned or results
            string results = register_user.register_user(FullName, Email, Role, Password);


            //then return the results
            return results;


        }


    }
}

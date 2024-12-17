//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Web;
//using System.Web.Security;

//namespace FoodMVC
//{
//    public class WebRoleProvider : RoleProvider
//    {
//        HttpClient client = new HttpClient();
//        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

//        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
//        {
//            throw new NotImplementedException();
//        }

//        public override void CreateRole(string roleName)
//        {
//            throw new NotImplementedException();
//        }

//        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
//        {
//            throw new NotImplementedException();
//        }

//        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
//        {
//            throw new NotImplementedException();
//        }

//        public override string[] GetAllRoles()
//        {
//            throw new NotImplementedException();
//        }

//        public override string[] GetRolesForUser(string username)
//        {
//            string apiurl = "https://localhost:44321/api/UserRole";

//            var content = new StringContent($"{{\"username\": \"{username}\"}}", Encoding.UTF8, "application/json");

//            // Make the HTTP request to the API
//            var response = client.PostAsync(apiurl, content).Result;

//            if (response.IsSuccessStatusCode)
//            {
//                // Parse the JSON response (assuming the API returns a list of roles as a JSON array)
//                var roles = response.Content.ReadAsStringAsync().Result;

//                // Here, you can parse roles from JSON response (you can use a library like Json.NET)
//                var roleList = JsonConvert.DeserializeObject<string[]>(roles);

//                return roleList;
//            }
//            throw new NotImplementedException();
//        }

//        public override string[] GetUsersInRole(string roleName)
//        {
//            throw new NotImplementedException();
//        }

//        public override bool IsUserInRole(string username, string roleName)
//        {
//            throw new NotImplementedException();
//        }

//        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
//        {
//            throw new NotImplementedException();
//        }

//        public override bool RoleExists(string roleName)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
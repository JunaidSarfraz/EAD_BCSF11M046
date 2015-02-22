using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialChart.Models
{
    public class Account_Implementation : IAccount
    {
        public int Authenticate(User u)
        {
            MoneyManagementEntities2 db = new MoneyManagementEntities2();
            User Authentic_user = null;
            foreach (User user in db.Users)
            {
                if ((user.Email == u.Email) && (user.password == u.password))
                {
                    Authentic_user = user;
                }
            }
            if (Authentic_user == null)
            {
                return -1;
            }
            else
            {
                return Authentic_user.UID;
            }
        }
        bool IsAlreadyExist(String Email)
        {
            MoneyManagementEntities2 db = new MoneyManagementEntities2();
            foreach (User user in db.Users)
            {
                if (user.Email == Email)
                {
                    //User already exists... we Don't have to add it again
                    return true;
                }
            }
            return false;
        }
        public bool SaveUser(User u)
        {
            MoneyManagementEntities2 db = new MoneyManagementEntities2();
            User Authentic_user = null;
            bool isExist = IsAlreadyExist(u.Email);
            //This means user not already exist in database
            if (isExist == false)
            {
                Authentic_user = u;
            }
            if (Authentic_user != null && u != null)
            {
                db.Users.Add(u);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public void Delete(int id)
        {
            MoneyManagementEntities2 db = new MoneyManagementEntities2();
            User u = db.Users.Find(id);
            db.Users.Add(u);
            db.SaveChanges();
        }
        public void SaveEditProfile(User u,int loggedInUserId)
        {
            MoneyManagementEntities2 db = new MoneyManagementEntities2();
            User loggedInUser = db.Users.Find(loggedInUserId);
            if (u.Name != null)
                loggedInUser.Name = u.Name;
            if (u.Email != null)
                loggedInUser.Email = u.Email;
            if (u.password != null)
                loggedInUser.password = u.password;
            db.SaveChanges();
        }
        public User getUser(int id)
        {
            MoneyManagementEntities2 db = new MoneyManagementEntities2();
            User loggedInUser = db.Users.Find(id);
            return loggedInUser;
        }
        public bool checkAvailability(String email)
        {
            MoneyManagementEntities2 db = new MoneyManagementEntities2();
            foreach (User u in db.Users)
            {
                if (u.Email == email)
                    return true;
            }
            return false;
        }
    }
}
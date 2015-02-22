using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialChart.Models
{
    public interface IAccount
    {
        int Authenticate(User u);
        bool SaveUser(User u);
        void Delete(int id);
        void SaveEditProfile(User u, int loggedInUserId);
        User getUser(int id);
        bool checkAvailability(String email);
    }
}

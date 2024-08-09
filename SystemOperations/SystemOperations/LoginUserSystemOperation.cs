using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations.BaseSO;

namespace SystemOperations.SystemOperations
{
    public class LoginUserSystemOperation : BaseSystemOperations
    {
        public User User { get; set; }
        public static List<User> userList = new List<User>();
        protected override void ExecuteConcreteOperation()
        {
            if (User == null)
                throw new Exception("User is null");

            List<User> userFromDtb = repository.Select(User,
                 $" Username = '{User.Username}' and " +
                    $" Password = '{User.Password}' ").Cast<User>().ToList();

            if (userFromDtb == null)
            {
                throw new Exception("User doesn't exist in database :( ");
            }
            else
            {
                User = userFromDtb[0];
            }
            foreach (User user in userList)
            {
                if (user.Username == userFromDtb[0].Username)
                {
                    throw new Exception("User has already logged in");
                }
            }
            userList.Add(User);
        }
    }
}

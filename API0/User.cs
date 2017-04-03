using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API0
{
    class User
    {
        public static string signup(string mail, string password)
        {
            string res="";
            password = Utilities.encrypt(password);



            return res;
        }
    }
}

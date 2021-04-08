using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfLKMT.Models
{
    public class UserLogin
    {
        public static CNhanVien loginUser;

        public static CNhanVien getLoginUser()
        {          
            return loginUser;
        }
        public UserLogin(CNhanVien nv)
        {
            loginUser = nv;
        }
        public UserLogin()
        {
          
        }

    }
}

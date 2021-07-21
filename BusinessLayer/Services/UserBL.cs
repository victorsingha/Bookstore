using BusinessLayer.Interfaces;
using CommonLayer;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UserBL : IUserBL
    {
        private IUserRL _userRl;
        public UserBL(IUserRL userRl)
        {
            _userRl = userRl;
        }
        public int Authenticate(LoginModel model)
        {
            try
            {
            return _userRl.Authenticate(model);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool Register(RegisterModel model)
        {
            try
            {
                return _userRl.Register(model);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}

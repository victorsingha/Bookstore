using CommonLayer;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        public bool Authenticate(LoginModel model)
        {
            try
            {
                if (model != null) return true;
                else return false;
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
                if (model != null) return true;
                else return false;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}

﻿using CommonLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IUserBL
    {
        bool Authenticate(LoginModel model);
        bool Register(RegisterModel model);
    }
}

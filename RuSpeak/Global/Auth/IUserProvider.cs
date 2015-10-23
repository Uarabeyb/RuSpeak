using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RuSpeak.Models.Auth;

namespace RuSpeak.Global.Auth
{
    public interface IUserProvider
    {
        User User { get; set; }
    }
}
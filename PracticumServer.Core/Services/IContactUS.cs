using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumServer.Core.Services
{
    public interface IContactUS
    {
        void SendEmail(string To, string Subject, string Body);
        string GetEmailFrom();
    }
}

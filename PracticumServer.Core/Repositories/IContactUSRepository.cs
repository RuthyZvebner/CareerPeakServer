using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumServer.Core.Repositories
{
    public interface IContactUSRepository
    {
        void SendEmail(string To, string Subject, string Body);
        string GetEmailFrom();
    }
}

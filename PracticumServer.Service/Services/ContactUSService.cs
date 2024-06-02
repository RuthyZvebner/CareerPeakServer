using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PracticumServer.Core.Repositories;
using PracticumServer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumServer.Service
{
    public class ContactUSService : IContactUS
    {

        private readonly IContactUSRepository _contactUSRepository;
        public ContactUSService(IContactUSRepository contactUSRepository)
        {
            _contactUSRepository = contactUSRepository;
        }

        public string GetEmailFrom()
        {
            return _contactUSRepository.GetEmailFrom();
        }

        public void SendEmail(string To, string Subject, string Body)
        {
           _contactUSRepository.SendEmail(To, Subject, Body);
        }
    }
}

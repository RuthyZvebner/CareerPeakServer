using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Manage.Internal;
using Microsoft.AspNetCore.Mvc;
using PracticumServer.Core.Entities;
using PracticumServer.Core.Services;
using PracticumServer.Service;
public class ContactUsController : ControllerBase
{
    private readonly IContactUS _contactUSService;

    public ContactUsController(IContactUS contactUSService)
    {
        _contactUSService = contactUSService;
    }

    [HttpGet("emailfrom")]
        public IActionResult GetEmailFrom()
        {
            string emailFrom = _contactUSService.GetEmailFrom();
            return Ok(emailFrom);
        }


        [HttpPost("sendemail/{To}/{Subject}/{Body}")]
        public void SendEmail(string To, string Subject, string Body)
        {
            try
            {
                _contactUSService.SendEmail(To, Subject, Body);
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(StatusCode(500, $"Failed to send email: {ex.Message}"));
            }
        }
    }


//public class EmailDetails
//{
//    public string To { get; set; }
//    public string Subject { get; set; }
//    public string Body { get; set; }
//}
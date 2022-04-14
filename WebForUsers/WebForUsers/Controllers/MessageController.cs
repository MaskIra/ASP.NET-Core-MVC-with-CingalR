using Microsoft.AspNetCore.Mvc;
using WebForUsers.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace WebForUsers.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        ApplicationContext context;
        public MessageController(ApplicationContext context)
        {
            this.context = context;
        }

        public ActionResult Index()
        {
            return View(context.Messages.Include(u=>u.SenderUser).Where(m=>m.ReceiverUserId.ToString() == User.FindFirst(ClaimTypes.NameIdentifier).Value).OrderByDescending(m=>m.Received).ToList());
        }

        public ActionResult Create()
        {
            ViewBag.message = context.Users.ToList();
            return View();
        }
    }
}

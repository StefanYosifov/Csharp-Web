namespace ChatApp.Controllers
{
    using ChatApp.Models;
    using Microsoft.AspNetCore.Mvc;

    public class ChatController : Controller
    {
        private static List<KeyValuePair<string, string>> messages 
            = new List<KeyValuePair<string, string>>();


        [HttpGet]
        public IActionResult Show()
        {
            if (messages.Count < 1)
            {
                return View(new ChatViewModel());
            }

            ChatViewModel viewModel = new ChatViewModel()
            {
                Messages = messages.Select(m => new MessageViewModels()
                {
                    Sender = m.Key,
                    Message = m.Value
                }).ToList()
            };

            return View(viewModel);
        }

        public IActionResult Send(ChatViewModel chat)
        {
            var message = chat.CurrentMessage;
            messages.Add(new KeyValuePair<string, string>(message.Sender,message.Message));


            return RedirectToAction("Show");
        }
    }
}

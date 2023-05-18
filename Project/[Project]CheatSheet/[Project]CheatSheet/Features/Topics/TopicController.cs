using _Project_CheatSheet.Features.Topics.Interfaces;
using _Project_CheatSheet.Infrastructure.Data.GlobalConstants.Topic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _Project_CheatSheet.Features.Topics
{
    [Authorize]
    [Route("/course/topic")]
    public class TopicController:ApiController
    {

        private readonly ITopicService service;

        public TopicController(
            ITopicService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTopic(string id)
        {
            var topicResult = await service.GetTopic(id);
            if (topicResult == null)
            {
                return BadRequest(TopicMessages.OnUnsuccessful);
            }
            return Ok(topicResult);
        }
    }
}

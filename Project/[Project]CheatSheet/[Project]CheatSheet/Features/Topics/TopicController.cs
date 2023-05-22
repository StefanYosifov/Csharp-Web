namespace _Project_CheatSheet.Features.Topics
{
    using Infrastructure.Data.GlobalConstants.Topic;
    using Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Route("/course/topic")]
    public class TopicController : ApiController
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

        [HttpGet("all/{id}")]
        public async Task<IActionResult> GetAllTopics(string id)
        {
            var topicResult = await service.GetAllTopics(id);
            return Ok(topicResult);
        }
    }
}
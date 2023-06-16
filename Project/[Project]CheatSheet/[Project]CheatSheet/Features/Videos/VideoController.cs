namespace _Project_CheatSheet.Features.Videos
{
    using Common.GlobalConstants.Videos;
    using Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Route("/videos")]
    public class VideoController:ApiController
    {
        private readonly IVideoService service;

        public VideoController(IVideoService service)
        {
            this.service = service;
        }

        [HttpGet("id/{videoId}")]
        public async Task<IActionResult> GetVideoId(string videoId)
        {
            var videoResult = await service.GetVideoId(videoId.ToLower());
            if (videoResult == null)
            {
                return BadRequest(VideoMessages.OnUnsuccessfulGetVideoId);
            }
            return Ok(videoResult);
        }

    }
}

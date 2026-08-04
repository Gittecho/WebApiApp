using Microsoft.AspNetCore.Mvc;
using SwagApiApp.Contracts.v1;
using SwagApiApp.Contracts.v1.Requests;
using SwagApiApp.Contracts.v1.Responses;
using SwagApiApp.Domain;
using SwagApiApp.Services;

namespace SwagApiApp.Controllers.v1
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class PostController : ControllerBase
    {

        private readonly IPostServices _postservices;   

        public PostController(IPostServices postServices) {
            _postservices = postServices;
        }

        [HttpGet(ApiRoute.Posts.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _postservices.GetPostsAsync());
        }

        [HttpGet(ApiRoute.Posts.Get)]
        public async Task<IActionResult>  Get([FromRoute] Guid postId) 
        {
            var post = await _postservices.GetPostByIdAsync(postId);    
            if (post == null)
                return NotFound();

            return Ok(post);
        }

        [HttpPut(ApiRoute.Posts.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid postId, [FromBody] UpdatePostRequest postRequest)
        {
            var post = new Post {Id = postId, Name = postRequest.Name};
            var status = await _postservices.UpdateToPostAsync(post);
            if (!status)
                return NotFound();

            return Ok(post);
        }

        [HttpDelete(ApiRoute.Posts.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid postId)
        {
            var status = await _postservices.DeletePostByIdAsync(postId);
            if (!status)
                return NotFound();

            return NoContent();
        }

        [HttpPost(ApiRoute.Posts.Create)]
        public async Task<IActionResult> Create([FromBody] CreatePostRequest postRequest) 
        {
            var post = new Post { Name = postRequest.Name }; // Function Level

            await _postservices.CreatePostAsync(post);
            
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoute.Posts.Get.Replace("postId", post.Id.ToString());    

            var response = new CreatePostResponse { Id = post.Id };  

            return Created(locationUri, post);
        }

    }
}

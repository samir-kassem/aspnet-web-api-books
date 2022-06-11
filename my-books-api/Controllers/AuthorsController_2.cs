using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books_api.Data.Services;
using my_books_api.Data.ViewModels;

namespace my_books_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController_2 : ControllerBase
    {
        private AuthorsService_2 _authorsService;

        public AuthorsController_2(AuthorsService_2 authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody]AuthorVM_2 author)
        {
            try
            {
                _authorsService.AddAuthor(author);
                return Ok();
            }
            catch (System.Exception e)
            {

                return BadRequest(e.ToString());
            }
        }

        [HttpGet("get-author-data/{id}")]
        public IActionResult GetAuthorData(int id)
        {
            try
            {
                var _author = _authorsService.GetAuthorData(id);
                return Ok(_author);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-author-with-publishers/{id}")]
        public IActionResult GetAuthorWithPublishers(int id)
        {
            try
            {
                var response = _authorsService.GetAuthorWithPublishers(id);
                return Ok(response);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPost("update-author-by-id/{id}")]
        public IActionResult UpdateAuthorById(int id, [FromBody]AuthorVM_2 author)
        {
            try
            {
                var _author = _authorsService.UpdateAuthor(id, author);
                return Ok(_author);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("delete-author-by-id/{id}")]
        public IActionResult  DeletAuthorById(int id)
        {
            try
            {
                _authorsService.DeleteAuthorById(id);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}

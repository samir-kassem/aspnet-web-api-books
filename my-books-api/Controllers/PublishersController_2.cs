using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books_api.Data.Services;
using my_books_api.Data.ViewModels;

namespace my_books_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController_2 : ControllerBase
    {
        private PublishersService_2 _publisherService;
        public PublishersController_2(PublishersService_2 publishersService_2)
        {
            _publisherService = publishersService_2;
        }


        [HttpPost("add-publihser")]
        public IActionResult AddPublisher([FromBody]PublisherVM_2 publisher)
        {
            try
            {
                _publisherService.AddPublisher(publisher);
                return Ok();
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublishers(string sortBy, string searchString, int pageNumber)
        {
            try
            {
                var _publishers = _publisherService.GetAllPublishers(sortBy, searchString, pageNumber);
                return Ok(_publishers);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            try
            {
                var _publisher = _publisherService.GetPublisherById(id);
                return Ok(_publisher);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            try
            {
                var response = _publisherService.GetPublisherData(id);
                return Ok(response);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-publisher-by-id/{id}")]
        public IActionResult UpdatePublisherById(int id, [FromBody]PublisherVM_2 publisher)
        {
            try
            {
                var _publisher = _publisherService.UpdatePublisher(id, publisher);
                return Ok(_publisher);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            try
            {
                _publisherService.DeletePublisher(id);
                return Ok();
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


    }
}

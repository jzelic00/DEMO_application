using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SMS_Application.DTO_s;
using SMS_Application.Model;
using SMS_Application.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IService _service;
        private readonly IFileHandler _textFileService;      
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,
            IService service,
            IFileHandler textFileService)
        {
            _logger = logger;
            _service = service;
            _textFileService = textFileService;
        }       
       
        [HttpPost]
        [Route("/AddNewContact")]
        public async Task<ActionResult> AddNewContact([FromBody]Contact NewContact)
        {
            try
            {
                await _service.AddNewContactAsync(NewContact);                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(NewContact);
        }

        [HttpGet]
        [Route("/GetAllContacts")]
        public ActionResult GetAllContacts()
        {
            try
            {
                return Ok(_service.GetAllContacts());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/SendMessage")]
        public async Task<IActionResult> SendMessage([FromBody]MessageDTO _messageDTO)
        {
            try
            {               
                await _textFileService.CreateFile(_messageDTO);              
                await _service.AddNewMessageAsync(_messageDTO.Contacts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}

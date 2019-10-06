using Api.ViewModels;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        private readonly IPicturesService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<PictureController> _logger;

        public PictureController(IPicturesService service, IMapper mapper, ILogger<PictureController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> Index()
        {
            var pictures = await _service.GetAllAsync();
            if (pictures.IsValid)
            {
                return Ok(_mapper.Map<IEnumerable<PictureViewModel>>(pictures.Result));
            }
            return BadRequest(pictures.ErrorsList);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([Required] IFormFile file)
        {
            var picture =  await _service.CreateAsync(_mapper.Map<PicturesDTO>(file));
            if (picture.IsValid)
            {
                return Ok();
            }
            return BadRequest(picture.ErrorsList);
        }
    }
}
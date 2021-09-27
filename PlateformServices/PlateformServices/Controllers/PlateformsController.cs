using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Plain.RabbitMQ;
using PlateformServices.Data;
using PlateformServices.Dtos;
using PlateformServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlateformServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlateformsController : ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;
        private readonly IPublisher _publisher;

        public PlateformsController(IPlatformRepo repository, IMapper mapper, IPublisher publisher)
        {
            _repository = repository;
            _mapper = mapper;
           _publisher = publisher;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlateformReadDto>> GetPlatforms()
        {
            Console.WriteLine("--> Getting Plateforms....");

            var plateformItem = _repository.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlateformReadDto>>(plateformItem));
            
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlateformReadDto> GetPlatformById(int id)
        {
            var platformItem = _repository.GetPlateformId(id);
            if (platformItem != null)
            {
                return Ok(_mapper.Map<PlateformReadDto>(platformItem));
            }

            return NotFound();
        }

        [HttpPost]
        public  ActionResult<PlateformReadDto> CreatePlatform(PlateformCreateDto platformCreateDto)
        {
            var platformModel = _mapper.Map<Plateform>(platformCreateDto);
            _repository.CreatePlateform(platformModel);
            _repository.SaveChanges();

            var platformReadDto = _mapper.Map<PlateformReadDto>(platformModel);
            _publisher.Publish(JsonConvert.SerializeObject(platformModel), "report.plateform", null);

            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDto.Id }, platformReadDto);
        }

    }
}

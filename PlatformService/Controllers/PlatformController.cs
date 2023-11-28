using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTOs;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepo _platfromRepo ;
        private readonly IMapper _mapper ;
        public PlatformController(IPlatformRepo platformRepo,IMapper mapper)
        {
            _platfromRepo = platformRepo ;
            _mapper = mapper ;
        }
        [HttpGet("{id}",Name = "GetPlatformById")]
        public ActionResult<PlaformReadDto> GetPlatformById(int id)
        {
            try
            {
                Platform platform = _platfromRepo.GetPlatformById(id);
                if(platform is not null){
                    return Ok(_mapper.Map<PlaformReadDto>(platform));
                }
                return NotFound();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("list")]
        public ActionResult<List<Platform>> GetAllPlatform()
        {
            try
            {
                List<Platform> platforms = _platfromRepo.GetAllPlatforms();
                if(platforms is not null)
                {
                    return Ok(_mapper.Map<List<PlaformReadDto>>(platforms));
                }
                return NotFound();
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("create")]
        public ActionResult CreatePlatform(PlaformCreateDto plaformCreateDto)
        {
            try{
                Platform platform = _mapper.Map<Platform>(plaformCreateDto);
                _platfromRepo.CreatePlafrom(platform);
                _platfromRepo.SaveChange();
                PlaformReadDto platformReadDto = _mapper.Map<PlaformReadDto>(platform);
                return Ok(platformReadDto);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
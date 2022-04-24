using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamuraiApp.Api.DTO;
using SamuraiApp.Data.Interface;
using SamuraiApp.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamuraiApp.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SwordsController : ControllerBase
    {
        private readonly ISword _swords;
        private readonly IMapper _mapper;
        private readonly IGeneralFunction _generalFunction;

        public SwordsController(ISword sword, IGeneralFunction generalFunction, IMapper mapper)
        {
            _swords = sword;
            _mapper = mapper;
            _generalFunction = generalFunction;
        }
        // GET: api/<SwordsController>
        [HttpGet]
        public async Task<IEnumerable<SwordDTO>> Get()
        {
            var result = await _swords.GetAll();
            var output = _mapper.Map<IEnumerable<SwordDTO>>(result);
            return output;
        }

        // GET api/<SwordsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SwordDTO>> GetById(int id)
        {
            var result = await _swords.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(_mapper.Map<SwordDTO>(result));
        }

        // POST api/<SwordsController>
        [HttpPost]
        public async Task<ActionResult> Post(SwordCreateDTO swordCreateDTO)
        {
            try
            {
                var sword = _mapper.Map<Sword>(swordCreateDTO);
                var result = await _swords.Insert(sword);
                var swordDTO = _mapper.Map<SwordDTO>(result);
                return CreatedAtAction("GetById", new { id = sword.Id }, swordDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // POST api/<SwordsController>
        [HttpPost("Element")]
        public async Task<ActionResult> PostWithElement(SwordCreateWithElementDTO swordCreateWithElement)
        {
            try
            {
                var sword = _mapper.Map<Sword>(swordCreateWithElement);
                var result = await _generalFunction.InsertSwordWithElement(sword);
                var swordDTO = _mapper.Map<SwordDTO>(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<SwordsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<SwordDTO>> Put(int id,  SwordCreateDTO swordCreateDTO)
        {
            try
            {
                var updateSword = _mapper.Map<Sword>(swordCreateDTO);
                var result = await _swords.Update(id, updateSword);
                var swordDTO = _mapper.Map<SwordDTO>(result);
                return Ok(swordDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // DELETE api/<SwordsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sword>> Delete(int id)
        {
            try
            {
                await _swords.DeleteById(id);
                return Ok($"Data dengan ID : {id} Telah Dihapus");
                    
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

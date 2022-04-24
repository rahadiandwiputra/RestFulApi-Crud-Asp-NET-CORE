using Microsoft.AspNetCore.Mvc;
using SamuraiApp.Data.Interface;
using SamuraiApp.Domain;
using AutoMapper;
using SamuraiApp.Api.DTO;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamuraiApp.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SamuraisController : ControllerBase
    {
        private readonly ISamurai _samurai;
        private readonly IMapper _mapper;
        private readonly IGeneralFunction _generalFunction;

        public SamuraisController(ISamurai samurais,IGeneralFunction generalFunction,IMapper mapper)
        {
            _samurai = samurais;
            _mapper = mapper;
            _generalFunction = generalFunction;
        }
        // GET: api/<SamuraisController>
        [HttpGet]
        public async Task<IEnumerable<SamuraiDTO>> Get()
        {
            /*var results = await _samurai.GetAll();
            return results;*/
            var result = await _samurai.GetAll();
            var output = _mapper.Map<IEnumerable<SamuraiDTO>>(result);
            return output;
        }

        // GET api/<SamuraisController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SamuraiDTO>> GetById(int id)
        {
            var result = await _samurai.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(_mapper.Map<SamuraiDTO>(result)); 
        }
        // GET api/<SamuraisController>/5
        [HttpGet("name/{name}")]
        public async Task<IEnumerable<SamuraiDTO>> GetByName(string name)
        {
            var result = await _samurai.GetByName(name);
            var result2 = _mapper.Map<IEnumerable<SamuraiDTO>>(result);
            return result2;
        }
        [HttpGet("GetSamuraiSwordElement/{id}")]
        public async Task<SamuraiReadSEDTO> GetSamuraiSwordElement(int id)
        {
            var result = await _generalFunction.GetSamuraiSwordElement(id);
            var Dto = _mapper.Map<SamuraiReadSEDTO>(result);
            return Dto;
        }
        [HttpGet("GetSamuraiWithSword/{id}")]
        public async Task<SamuraiReadWithSword> GetSamuraiWithSword(int id)
        {
            var result = await _generalFunction.GetSamuraiWithSword(id);
            var SAmuraiSWordDTO =_mapper.Map<SamuraiReadWithSword>(result);
            return SAmuraiSWordDTO;
        }

        // POST api/<SamuraisController>
        [HttpPost]
        public async Task<ActionResult> Post(SamuraiCreateDTO samuraiCreateDTO)
        {
            /*try
            {
                var result = await _samurai.Insert(samurai);
                return CreatedAtAction("GetById", new { id = samurai.Id }, samurai);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }*/
            try
            {
                var samurai = _mapper.Map<Samurai>(samuraiCreateDTO);
                var result = await _samurai.Insert(samurai);
                var samuraiDTO=_mapper.Map<SamuraiDTO>(result);
                return CreatedAtAction("GetById", new { id = samurai.Id }, samuraiDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<SamuraisController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<SamuraiDTO>> Put(int id, SamuraiCreateDTO samuraiCreateDTO)
        {
            /*try
            {
                var result = _samurai.Update(id , samurai);
                return Ok(result);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }*/
            try
            {
                var updateSamurai = _mapper.Map<Samurai>(samuraiCreateDTO);
                var result = await _samurai.Update(id, updateSamurai);
                var samuraiDTO = _mapper.Map<SamuraiDTO>(result);
                return Ok(samuraiDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<SamuraisController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Samurai>> Delete(int id)
        {
            try
            {
               await _samurai.DeleteById(id);
               return Ok($"Hapus data {id} sukses");
            }
            catch(Exception ex)
            {
               return BadRequest(ex.Message);
            }
        }
        [HttpPost("SamuraiSword")]
        public async Task<ActionResult> PostWithSword(SamuraiCreateWithSwordDTO samuraiCreateWithSwordDTO)
        {
            try
            {
                var samuraiSword = _mapper.Map<Samurai>(samuraiCreateWithSwordDTO);
                var result = await _generalFunction.InsertSamuraiWithSword(samuraiSword);
                var DTO = _mapper.Map<SamuraiReadWithSword>(result);
                return Ok(DTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

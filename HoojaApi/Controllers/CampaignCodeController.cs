using HoojaApi.Data;
using HoojaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HoojaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignCodeController : Controller
    {
        private readonly HoojaApiDbContext _context;

        public CampaignCodeController(HoojaApiDbContext context)
        {
            _context = context;
        }

        // GET: api/<CampaignCodeController>
        [HttpGet("GetAllCampaignCode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CampaignCode>>> GetAllCampaignCode()
        {
            var campaignCodes = await _context.CampaignCodes.ToListAsync();
            return Ok(campaignCodes);
        }

        // GET api/<CampaignCodeController>/5
        [HttpGet("CampaignCode-By{id}")]
        public async Task<ActionResult<IEnumerable<CampaignCode>>> GetAllCampaignCode(int id)
        {
            var campaignCodes = await _context.CampaignCodes.FindAsync(id);

            if (campaignCodes == null)
            {
                return NotFound($"No campaignCode with id: {id} found.");
            }
            return Ok(campaignCodes);
        }

        // POST api/<CampaignCodeController>
        [HttpPost]
        public async Task<ActionResult> AddCampaignCode([FromBody] CampaignCode campaignCode)
        {
            _context.CampaignCodes.Add(campaignCode);
            await _context.SaveChangesAsync();

            return Ok(campaignCode);
        }

        // PUT api/<CampaignCodeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CampaignCode>> UpdateCampaignCode(int id, [FromBody] CampaignCode campaignCode)
        {
            if (id != campaignCode.CampaignCodeId)
            {
                return BadRequest();
            }

            _context.Entry(campaignCode).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(campaignCode);
        }

        // DELETE api/<CampaignCodeController>/5
        [HttpDelete("Delete-CampaignCode{id}")]
        public async Task<ActionResult> DeleteCampaignCode(int id)
        {
            var campaignCode = await _context.CampaignCodes.FindAsync(id);
            if (campaignCode == null)
            {
                return NotFound();
            }

            _context.CampaignCodes.Remove(campaignCode);
            await _context.SaveChangesAsync();

            return Ok($"CampaignCode with {id} deleted successfully");
        }
    }
}

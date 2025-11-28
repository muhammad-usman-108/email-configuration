using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmailConfigApi.Data;
using EmailConfigApi.Models;
using EmailConfigApi.DTOs;

namespace EmailConfigApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailConfigurationsController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly ILogger<EmailConfigurationsController> _logger;

        public EmailConfigurationsController(AppDbContext db, ILogger<EmailConfigurationsController> logger)
        {
            _db = db;
            _logger = logger;
        }

        // GET api/emailconfigurations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmailConfigurationReadDto>>> GetAll()
        {
            var list = await _db.EmailConfigurations
                .AsNoTracking()
                .Select(ec => new EmailConfigurationReadDto {
                    Id = ec.Id,
                    Name = ec.Name,
                    WatchedFolder = ec.WatchedFolder,
                    Provider = ec.Provider,
                    StoreAttachments = ec.StoreAttachments
                }).ToListAsync();

            return Ok(list);
        }

        // GET api/emailconfigurations/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<EmailConfigurationReadDto>> GetById(int id)
        {
            var ec = await _db.EmailConfigurations.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (ec == null) return NotFound();
            return Ok(new EmailConfigurationReadDto {
                Id = ec.Id,
                Name = ec.Name,
                WatchedFolder = ec.WatchedFolder,
                Provider = ec.Provider,
                StoreAttachments = ec.StoreAttachments
            });
        }

        // POST api/emailconfigurations
        [HttpPost]
        public async Task<ActionResult<EmailConfigurationReadDto>> Create([FromBody] EmailConfigurationCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = new EmailConfiguration
            {
                Name = dto.Name,
                WatchedFolder = dto.WatchedFolder,
                Provider = dto.Provider,
                StoreAttachments = dto.StoreAttachments
            };

            _db.EmailConfigurations.Add(entity);
            await _db.SaveChangesAsync();

            var readDto = new EmailConfigurationReadDto
            {
                Id = entity.Id,
                Name = entity.Name,
                WatchedFolder = entity.WatchedFolder,
                Provider = entity.Provider,
                StoreAttachments = entity.StoreAttachments
            };

            return CreatedAtAction(nameof(GetById), new { id = readDto.Id }, readDto);
        }
    }
}

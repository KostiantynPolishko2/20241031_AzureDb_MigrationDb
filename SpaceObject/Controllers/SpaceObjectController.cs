using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SpaceObject.DTO;
using SpaceObject.EF;
using SpaceObject.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SpaceObject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpaceObjectController : ControllerBase
    {
        private readonly ILogger<SpaceObjectController> logger;
        private readonly SpaceObjectContext context;

        public SpaceObjectController(ILogger<SpaceObjectController> logger, SpaceObjectContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        [HttpGet("asteroiditems", Name = "GetAsteroidItems")]
        public ActionResult<IEnumerable<AsteroidItem>> GetAsteroidItems() 
        {
            try
            {
                var data = context.asteroidItems;
                if (data == null)
                {
                    throw new Exception("AsteroidItems no records in db");
                }

                return Ok(data);
            }
            catch (Exception ex) 
            { 
                return NotFound(ex.Message);
            }
        }

        [HttpGet("asteroidsinfo", Name = "GetAsteroidsInfo")]
        public ActionResult<IEnumerable<AsteroidInfoDto>> GetAsteroidsInfo()
        {         
            try
            {
                IEnumerable<AsteroidInfoDto> asteroids_dto = context.asteroidItems.Join
                    (
                        context.asteroidProperties,
                        ai => ai.id,
                        ap => ap.idAsteroidItem,
                        (ai, ap) => new AsteroidInfoDto(ap){ name = ai.name, category = ai.type }
                    );

                if (asteroids_dto == null)
                {
                    throw new Exception("AsteroidItems no records in db");
                }

                return Ok(asteroids_dto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}

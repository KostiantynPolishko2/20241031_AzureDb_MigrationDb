using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceObject.DTO;
using SpaceObject.EF;
using SpaceObject.Entities;
using System.ComponentModel.DataAnnotations;

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
        public ActionResult<IEnumerable<AsteroidItemDto>> GetAsteroidItems() 
        {
            try
            {
                var data = context.asteroidItems;
                if (data == null)
                {
                    throw new Exception("AsteroidItems no records in db");
                }

                IMapper mapper = new MapperConfiguration( c => c.CreateMap<AsteroidItem, AsteroidItemDto>()).CreateMapper();
                var asteroidItemsDto = mapper.Map<IEnumerable<AsteroidItem>, IEnumerable<AsteroidItemDto>>(data);

                return Ok(asteroidItemsDto);
            }
            catch (Exception ex) 
            { 
                return NotFound(ex.Message);
            }
        }

        [HttpGet("asteroid/{name}", Name = "GetAsteroidsInfo")]
        public ActionResult<AsteroidInfoDto> GetAsteroidsInfo([FromRoute] string name)
        {         
            try
            {
                var item = context.asteroidItems.Include(ai => ai.asteroidProperty).FirstOrDefault(c => c.Name.Equals(name.ToLower()));

                if (item == null)
                {
                    throw new Exception($"AsteroidInfo of {name}  no records in db");
                }

                var asteroidItemDto = new AsteroidInfoDto(item.asteroidProperty) { Name = item.Name, Category = item.Type };

                return Ok(asteroidItemDto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet("asteroids/{type}", Name = "GetAsteroidsInfoByType")]
        public ActionResult<IEnumerable<AsteroidInfoDto>> GetAsteroidsInfoByType([FromRoute][Required] string type)
        {
            try
            {
                IEnumerable<AsteroidInfoDto>? asteroids_dto = context.asteroidItems.Where(c => c.Type.Equals(type.ToLower()) ).Join
                    (
                        context.asteroidProperties,
                        ai => ai.id,
                        ap => ap.idAsteroidItem,
                        (ai, ap) => new AsteroidInfoDto(ap) { Name = ai.Name, Category = ai.Type }
                    );

                if (asteroids_dto.Count() == 0)
                {
                    throw new Exception($"Asteroids with class {type} no records in db");
                }

                return Ok(asteroids_dto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("asteroid", Name = "PostAsteroid")]
        public IActionResult PostAsteroid([FromQuery] [Required] string name, string type, [FromBody] AsteroidProperty asteroidProperty)
        {
            try
            {
                context.asteroidItems.Add(new AsteroidItem { Name = name, Type = type });
                context.SaveChanges();

                int asteroidItemId = context.asteroidItems.FirstOrDefault(ai => ai.Name.Equals(name.ToLower()))!.id;
                if (asteroidItemId == -1)
                {
                    throw new Exception($"Asteroids {name} no records in db");
                }

                asteroidProperty.idAsteroidItem = asteroidItemId;
                context.asteroidProperties.Add(asteroidProperty);
                context.SaveChanges();

                return Ok($"asteroid {name}, class {type}, recorded to db");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPatch("asteroid/{name}", Name = "PatchAsteroid")]
        public IActionResult PatchAsteroid([FromRoute][Required] string name, [FromBody] JsonPatchDocument<AsteroidProperty> patchDoc)
        {
            try
            {
                var asteroidItem = context.asteroidItems.Include(ai => ai.asteroidProperty).FirstOrDefault(c => c.Name.Equals(name.ToLower()));
                if (asteroidItem == null)
                {
                    return NotFound($"asteroid {name} no record in db");
                }

                var asteroidProperty = asteroidItem!.asteroidProperty;
                if (asteroidProperty == null)
                {
                    return NotFound($"asteroids' properties {name} no record in db");
                }

                // Apply the patch document to the asteroid
                patchDoc.ApplyTo(asteroidProperty, ModelState);

                // Validate the model after applying the patch
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                context.asteroidProperties.Update(asteroidProperty);
                context.SaveChanges();

                return Ok($"asteroid {name} properties record updated in db");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("asteroid/{name}", Name = "DeleteAsteroidByName")]
        public IActionResult DeleteAsteroidByName([FromRoute] string name)
        {
            try
            {
                var item = context.asteroidItems.FirstOrDefault(c => c.Name.Equals(name.ToLower()));
                if (item == null)
                {
                    throw new Exception($"{name} no record in db");
                }

                context.asteroidItems.Remove(item);
                context.SaveChanges();

                return Ok($"{name} deleted from db");
            }
            catch (Exception ex)
            {
                return BadRequest($"internal server exception: \"{ex.Message}\"");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ShoeStore.Models;
using ShoeStore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ShoeStore.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ShoeController : ControllerBase
  {
    private readonly ShoeRepository _shoeRepo;
    public ShoeController(ShoeRepository shoeRepo)
    {
      _shoeRepo = shoeRepo;
    }

    // GET api/Shoes
    [HttpGet]

    [HttpGet("{id}")]
    public ActionResult<Shoe> Get(int id)
    {
      Shoe result = _shoeRepo.GetShoeById(id);
      if (result != null)
      {
        return Ok(result);
      }
      return NotFound();
    }

    // POST api/Shoes
    [HttpPost]
    public ActionResult<Shoe> Post([FromBody] Shoe shoe)
    {
      return Created("/api/shoes/", _shoeRepo.AddShoe(shoe));
    }

    // PUT api/Shoes/5
    [HttpPut("{id}")]
    public ActionResult<Shoe> Put(int id, [FromBody] Shoe shoe)
    {
      Shoe result = _shoeRepo.EditShoe(id, shoe);
      if (result != null)
      {
        return result;
      }
      return NotFound();
    }

    // DELETE api/Shoes/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      if (_shoeRepo.DeleteShoe(id))
      {
        return Ok("success");
      }
      return NotFound("No Shoe to delete");
    }
  }
}

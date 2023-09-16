using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API;

public class BuggyController : BaseApiController
{
    private readonly StoreContext _storeContext;

    public BuggyController(StoreContext storeContext)
    {
        _storeContext = storeContext;
    }

    [HttpGet("notfound")]
    public ActionResult GetNotFound()
    {
        var product = _storeContext.Products.Find(56);
        if(product is null)
        {
            return NotFound(new ApiResponse(404));
        }
        return Ok();
    }

    
    [HttpGet("servererror")]
    public ActionResult GetServerError()
    {
        
        var product = _storeContext.Products.Find(56);

        var productString = product.ToString();
        return Ok();
    }

    
    [HttpGet("badrequest")]
    public ActionResult GetBadRequest()
    {
        return BadRequest(new ApiResponse(400));
    }

      [HttpGet("badrequest/{id}")]
    public ActionResult GetBadRequest(int id)
    {
        return Ok();
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Customer.Api;

[ApiController]
public class Endpoint : ControllerBase
{
    [HttpGet("api/customers")]
    public ActionResult<Guid> ExecuteAsync()
    {
        return Ok(Guid.NewGuid());
    }

}

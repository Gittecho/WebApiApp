using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


public class CheckController : Controller
{
    [HttpGet("/api/v1/user")]
    public IActionResult Get()
    {
        return Ok(new { name = "Ahmed" });
    }
}


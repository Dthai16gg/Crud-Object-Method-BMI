using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BmiController : Controller
{
    [HttpGet("{weight}/{height}")]
    public double CalculateBMI(double weight, double height)
    {
        //check
        if (weight <= 0 || height <= 0) return 0;
        //check height is meter high 0,1 and less than 2,5
        if (height < 0.1 || height > 3.0) return 0;
        //check weight is less than 200kg and more than 10kg
        if (weight > 200 || weight < 10) return 0;
        //calculate
        return weight / (height * height);
    }
}
namespace Swashbuckle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status500InternalServerError)]
    public ActionResult<IList<Customer>> GetCustomers()
    {
        // Simulate fetching a customer from a database
        return new Customer[]
        {
            new() { Id = 1, Name = "John Doe" },
            new() { Id = 2, Name = "Margaret Carty" }
        };
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status500InternalServerError)]
    public ActionResult<Customer> GetCustomer(int id)
    {
        // Simulate fetching a customer from a database
        return new Customer { Id = id, Name = "John Doe" };
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status500InternalServerError)]
    public IActionResult CreateCustomer([FromBody] Customer customer)
    {
        // Simulate creating a customer in a database
        return CreatedAtAction(nameof(GetCustomer), new { id = 5 }, customer with { Id = 5 });
    }

    [HttpGet("error")]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status500InternalServerError)]
    public IActionResult GetError()
    {
        // Simulate an error
        throw new Exception("An unexpected error occurred.");
    }
}

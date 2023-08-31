using app.Data;
using app.Dto;
using app.Interfaces;
using app.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;
    private readonly IMapper _mapper;


    public PersonController(ILogger<PersonController> logger, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<IEnumerable<PersonDto>>> Get(int id, [FromServices] IPersonRepository personRepository)
    {
        var personDb = await personRepository.GetAsync(id);
        if (personDb == null)
            return NotFound();

        var personDto = _mapper.Map<PersonDto>(personDb);
        return Ok(personDto);
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult> Post([FromServices] IPersonRepository personRepository, [FromBody] PersonInsertModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var newLogin = new Login()
        {
            Email = model.Email,
            Password = model.Password
        };

        var newPerson = new Person()
        {
            Login = newLogin,
            FirstName = model.FirstName,
            LastName = model.LastName
        };

        await personRepository.AddAsync(newPerson);

        await personRepository.SaveChangesAsync();

        return Created("", newPerson.Id);
    }
}

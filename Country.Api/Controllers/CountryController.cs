using Country.Domain.Interfaces.Services;
using Country.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Country.Api.Controllers;

[Route("api/[controller]")]
public class CountryController : ControllerBase
{
    private readonly ICountryService countryService;

    public CountryController(ICountryService countryService)
    {
        this.countryService = countryService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CountryEntity>>> GetAllCountries(CancellationToken cancellationToken = default)
    {
        var result = await countryService.GetAllAsync(cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CountryEntity>> GetCountryById(int id, CancellationToken cancellationToken = default)
    {
        var result = await countryService.GetByIdAsync(id, cancellationToken);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCountry([FromBody] CountryEntity country, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdCountry = await countryService.CreateAsync(country, cancellationToken);
        return CreatedAtAction(nameof(GetCountryById), new { id = createdCountry.Id }, createdCountry);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCountry(int id, [FromBody] CountryEntity updatedCountry, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await countryService.UpdateAsync(id, updatedCountry, cancellationToken);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCountry(int id, CancellationToken cancellationToken = default)
    {
        var result = await countryService.DeleteAsync(id, cancellationToken);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}
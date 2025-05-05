using Country.Domain.Interfaces.Services;
using Country.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Country.Api.Models.Responses;
using Mapster;
using Country.Api.Models.Requests;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
    public async Task<ActionResult<List<CountryResponse>>> GetAllCountries(CancellationToken cancellationToken = default)
    {
        var result = await countryService.GetAllAsync(cancellationToken);

        var countryResponse = result.Adapt<List<CountryResponse>>();

        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CountryResponse>> GetCountryById(int id, CancellationToken cancellationToken = default)
    {
        var result = await countryService.GetByIdAsync(id, cancellationToken);
        if (result == null)
        {
            return NotFound();
        }
        var countryResponse = result.Adapt<CountryResponse>();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCountry([FromBody] CountryRequest req, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var request = req.Adapt<CountryEntity>();

        var createdCountry = await countryService.CreateAsync(request, cancellationToken);

        return CreatedAtAction(nameof(GetCountryById), new { id = createdCountry.Id }, createdCountry);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCountry(int id, [FromBody] CountryRequest req, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var request = req.Adapt<CountryEntity>();
        request.Id = id;

        var result = await countryService.UpdateAsync(id, request, cancellationToken);

        if (result == null)
        {
            return NotFound();
        }
        var resp = result.Adapt<CountryResponse>();

        return Ok(resp);
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
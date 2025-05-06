using Country.Application.Interfaces.Services;
using Country.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Country.Api.Models.Responses;
using Mapster;
using Country.Api.Models.Requests;
using Country.Application.Models;

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
        var dtos = await countryService.GetAllAsync(cancellationToken);

        var responses = dtos.Adapt<List<CountryResponse>>();

        return Ok(responses);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CountryResponse>> GetCountryById(int id, CancellationToken cancellationToken = default)
    {
        var dto = await countryService.GetByIdAsync(id, cancellationToken);
      
        if (dto == null)
        {
            return NotFound();
        }

        var response = dto.Adapt<CountryResponse>();

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCountry([FromBody] CountryRequest req, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var dto = req.Adapt<CountryDto>();

        var createdDto = await countryService.CreateAsync(dto, cancellationToken);

        var response = createdDto.Adapt<CountryResponse>();

        return CreatedAtAction(nameof(GetCountryById), new { id = response.Id }, response);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCountry(int id, [FromBody] CountryRequest req, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var dto = req.Adapt<CountryDto>();
        dto.Id = id;

        var updatedDto = await countryService.UpdateAsync(id, dto, cancellationToken);

        if (updatedDto == null)
        {
            return NotFound();
        }
        var response = updatedDto.Adapt<CountryResponse>();

        return Ok(response);
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
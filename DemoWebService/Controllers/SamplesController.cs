using DemoWebService.Entities;
using DemoWebService.Repositories;

using Microsoft.AspNetCore.Mvc;

namespace DemoWebService.Controllers;

[ApiController]
[Route("/samples")]
public class SamplesController : ControllerBase
{
    private readonly SampleRepository _sampleRepository;

    public SamplesController(SampleRepository sampleRepository)
    {
        _sampleRepository = sampleRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var samples = await _sampleRepository.GetSamples();
            return Ok(samples);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id}", Name = "GetSampleById")]
    public async Task<IActionResult> GetSampleById(int id)
    {
        try
        {
            return Ok(await _sampleRepository.GetSampleById(id));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Sample sample)
    {
        try
        {
            var storedSample = await _sampleRepository.CreateSample(sample);
            return CreatedAtRoute("GetSampleById", new { id = storedSample.Id }, storedSample);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
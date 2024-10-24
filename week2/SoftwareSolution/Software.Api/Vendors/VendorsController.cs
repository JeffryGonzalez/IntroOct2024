using Marten;
using Microsoft.AspNetCore.Mvc;

namespace Software.Api.Vendors;

public class VendorsController(IDocumentSession session) : ControllerBase
{
    [HttpPost("/vendors")]

    public async Task<ActionResult<VendorResponseModel>> AddVendorAsync([FromBody] CreateVendorRequestModel request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var entity = new VendorEntity
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        };

        session.Store(entity);
        await session.SaveChangesAsync();

        var response = new VendorResponseModel
        {
            Id = entity.Id,
            Name = request.Name
        };
        return Ok(response);
    }

    [HttpGet("/vendors")]
    public async Task<ActionResult<IList<VendorResponseModel>>> GetAllVendors()
    {
        var response = await session.Query<VendorEntity>()
            .Select(x => new VendorResponseModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();

        return Ok(response);

    }

}


public record CreateVendorRequestModel
{
    public string Name { get; set; } = string.Empty;
}


public record VendorResponseModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class VendorEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
using Microsoft.AspNetCore.Mvc;

namespace Software.Api.Catalog;

public class CatalogController(CatalogManager catalogManager) : ControllerBase
{

    [HttpGet("/catalog/{id:guid}")]
    public async Task<ActionResult> GetCatalogItemById(
        [FromRoute]
        Guid id)
    {
        CatalogResponseModel? item = await catalogManager.GetByIdAsync(id);

        if (item is null)
        {
            return NotFound();
        }
        else
        {
            return Ok(item);
        }
    }


    [HttpGet("/catalog")]
    public async Task<ActionResult> GetFullCatalog(CancellationToken token)
    {

        IReadOnlyList<CatalogResponseModel> response = await catalogManager.GetCatalogAsync(token);
        return Ok(response);
    }

    [HttpPost("/catalog")]
    public async Task<ActionResult> AddSoftwareToCatalogAsync(
        [FromBody] CatalogCreateModel request)
    {
        // make sure that the vendor doesn't already exist

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); // 400
        }


        CatalogResponseModel response = await catalogManager.AddSoftwareToCatalogAsync(request);


        return Ok(response);
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Software.Api.Catalog;

public class CatalogController(CatalogManager catalogManager) : ControllerBase
{

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
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); // 400
        }


        CatalogResponseModel response = await catalogManager.AddSoftwareToCatalogAsync(request);


        return Ok(response);
    }
}

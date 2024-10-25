using Marten;
using Microsoft.AspNetCore.Mvc;
using Software.Api.Vendors;

namespace Software.Api.Catalog;

public class CatalogController(CatalogManager catalogManager, IDocumentSession session) : ControllerBase
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

    [HttpPost("/vendors/{vendorId:guid}/catalog")]
    public async Task<ActionResult> AddSoftwareToCatalogAsync(
        [FromRoute] Guid vendorId,
        [FromBody] CatalogCreateModel request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); // 400
        }
        // lookup to make sure that that id for the vendor is still in the database.
        //  - if it doesn't, 404.
        // use a transaction to make 100% "ACID" (serialiable, whatever)
        var vendorIsThere = await session.Query<VendorEntity>().AnyAsync(v => v.Id == vendorId);
        if (!vendorIsThere)
        {
            return NotFound();
        }



        CatalogResponseModel response = await catalogManager.AddSoftwareToCatalogAsync(request, vendorId);


        return Ok(response);
    }
}

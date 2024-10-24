using Microsoft.AspNetCore.Mvc;

namespace Software.Api.Catalog;

public class CatalogController(CatalogManager catalogManager) : ControllerBase
{



    [HttpPost("/catalog")]
    public async Task<ActionResult> AddSoftwareToCatalogAsync(
        [FromBody] CatalogCreateModel request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); // 400
        }
        // Controllers - validate the input.

        // - decide what valid means, what should happen, not HOW it happens
        // - decide what kind of response to return.
        // Fake for a minute

        // if the request is valid
        // - save this thing into the database - return a 200 with the response model.
        // if it is invalid
        // - I'm going to return a 400 (optionally with some details)

        CatalogResponseModel response = await catalogManager.AddSoftwareToCatalogAsync(request);



        return Ok(response);
    }
}

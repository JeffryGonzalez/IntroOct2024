
using Marten;

namespace Software.Api.Catalog;

public class CatalogManager(IDocumentSession session)
{
    public async Task<CatalogResponseModel> AddSoftwareToCatalogAsync(CatalogCreateModel request)
    {

        var response = new CatalogResponseModel()
        {
            Id = Guid.NewGuid(),
            IsOpenSource = request.IsOpenSource,
            Title = request.Title,
            Vendor = request.Vendor,
        };

        var thingToSave = new CatalogEntity()
        {
            Id = response.Id,
            IsOpenSource = response.IsOpenSource,
            Title = response.Title,
            Vendor = response.Vendor,

        };
        session.Store(thingToSave);
        await session.SaveChangesAsync();

        return response;
    }
}

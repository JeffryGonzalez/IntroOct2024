
using Marten;
using Software.Api.Vendors;

namespace Software.Api.Catalog;

public class CatalogManager(IDocumentSession session, ILogger<CatalogManager> logger)
{
    public async Task<CatalogResponseModel> AddSoftwareToCatalogAsync(CatalogCreateModel request, Guid vendorId)
    {

        var vendor = await session.Query<VendorEntity>()
            .Where(v => v.Id == vendorId)
            .Select(v => new VendorResponseModel { Id = v.Id, Name = v.Name })
            .SingleAsync(); // talk about this in a second poor person's transaction

        var response = new CatalogResponseModel()
        {
            Id = Guid.NewGuid(),
            IsOpenSource = request.IsOpenSource,
            Title = request.Title,
            VendorId = vendorId,
            EmbeddedVendor = vendor,
        };

        var thingToSave = new CatalogEntity()
        {
            Id = response.Id,
            IsOpenSource = response.IsOpenSource,
            Title = response.Title,
            Vendor = vendorId,

        };
        session.Store(thingToSave);
        await session.SaveChangesAsync();

        return response;
    }

    public async Task<IReadOnlyList<CatalogResponseModel>> GetCatalogAsync(CancellationToken token)
    {
        logger.LogInformation("Starting a request to get the data from the database");
        // Don't do this in production code.
        await Task.Delay(2000, token);
        var data = await session.Query<CatalogEntity>()
            .Select(i => new CatalogResponseModel
            {
                Id = i.Id,
                IsOpenSource = i.IsOpenSource,
                Title = i.Title,
                VendorId = i.Vendor,
            })
            .ToListAsync(token);

        logger.LogInformation("Ending  the request to get the data from the database");
        return data;
    }

    public async Task<CatalogResponseModel?> GetByIdAsync(Guid id)
    {
        var data = await session.Query<CatalogEntity>()
            .Where(i => i.Id == id)
            .Select(i => new CatalogResponseModel
            {
                Id = i.Id,
                IsOpenSource = i.IsOpenSource,
                Title = i.Title,
                VendorId = i.Vendor,
            }).SingleOrDefaultAsync();

        return data;
    }
}

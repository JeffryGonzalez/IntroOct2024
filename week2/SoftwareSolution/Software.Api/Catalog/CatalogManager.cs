
using Marten;

namespace Software.Api.Catalog;

public class CatalogManager(IDocumentSession session, ILogger<CatalogManager> logger)
{
    public async Task<CatalogResponseModel> AddSoftwareToCatalogAsync(CatalogCreateModel request)
    {
        await Task.Delay(new Random().Next(1000, 3000));

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
                Vendor = i.Vendor,
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
                Vendor = i.Vendor,
            }).SingleOrDefaultAsync();

        return data;
    }
}

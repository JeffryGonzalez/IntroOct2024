using Software.Api.Vendors;

namespace Software.Api.Catalog;

public record CatalogResponseModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public Guid VendorId { get; set; }
    public bool IsOpenSource { get; set; }

    public VendorResponseModel EmbeddedVendor { get; set; } = new();
}

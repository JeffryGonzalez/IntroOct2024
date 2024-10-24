namespace Software.Api.Catalog;

public class CatalogEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public Guid Vendor { get; set; }
    public bool IsOpenSource { get; set; }
}
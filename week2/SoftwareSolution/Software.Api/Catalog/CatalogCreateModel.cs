using System.ComponentModel.DataAnnotations;

namespace Software.Api.Catalog;

/*{
    "title": "Visual Studio Code",
    "vendor": "Microsoft",
    "isOpenSource": true
}
*/
public record CatalogCreateModel
{
    [Required, MinLength(3), MaxLength(30)]
    public string Title { get; set; } = string.Empty;
    [Required, MinLength(5), MaxLength(30)]
    public string Vendor { get; set; } = string.Empty;
    [Required]
    public bool IsOpenSource { get; set; }
}

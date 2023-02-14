using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace ModelValidation.Models
{
    internal class Models
    {
        public readonly record struct ProductId(Guid Value)
        {
            public static ProductId From(Guid? productId) =>
                new(productId.AssertNotEmpty());
        }

        public readonly record struct SKU(string Value)
        {
           public static SKU From(string? value) =>
                new(value.AssertMatchesRegex("[A-Z]{2,4}[0-9]{4,18}"));
        }

        public record RegisterProduct(
            ProductId Product,
            SKU SKU,
            string Name,
            string? Description
        )
        {
            public static RegisterProduct From(Guid? id, string? sku, string? name, string? description) =>
                new(
                    ProductId.From(id),
                    SKU.From(sku),
                    name.AssertNotEmpty(),
                    description.AssertNullOrNotEmpty()
                    );
        }
    }
    
}

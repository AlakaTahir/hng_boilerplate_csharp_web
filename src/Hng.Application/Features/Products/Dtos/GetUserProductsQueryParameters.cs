using System.Text.Json.Serialization;

namespace Hng.Application.Features.Products.Dtos
{
    public class GetUserProductsQueryParameters: GetProductsQueryParameters
	{
        [JsonPropertyName("user_id")]
        public Guid UserId { get; set; }
    }
}

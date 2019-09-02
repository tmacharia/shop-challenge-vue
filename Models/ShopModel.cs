using System.ComponentModel.DataAnnotations;

namespace Shop.Web.Models
{
    /// <summary>
    /// Represents a shop object. This model will be used to generate database
    /// table for shops.
    /// </summary>
    public class ShopModel : BaseModel
    {
        /// <summary>
        /// The name of the shop.
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// Short description for the shop. Maybe describing the type of merchandise
        /// they sell on their shop/store.
        /// </summary>
        public string Description { get; set; }
        [DataType(DataType.ImageUrl)]
        [MaxLength(150)]
        public string ImageUrl { get; set; }
        public double Distance { get; set; }
        /// <summary>
        /// Metric unit to use for shops. The default is Km(Kilometers)
        /// </summary>
        [MaxLength(10)]
        public string MetricUnit { get; set; } = "Km";
    }
}
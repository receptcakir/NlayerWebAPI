namespace NLayer.Core.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public IList<Product> Products { get; set; }
    }
}

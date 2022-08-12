namespace CQRSMediatR
{
    public class FakeDataStore
    {
        private static List<Product> _products;

        public FakeDataStore()
        {
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "Iphone 13"},
                new Product { Id = 2, Name = "Iphone 14"},
                new Product { Id = 3, Name = "Iphone 12"},
                new Product { Id = 4, Name = "Iphone X"},
            };

        }
        public async Task AddProductAsync(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync() =>
            await Task.FromResult(_products);

        public async Task<Product> GetProductByIdAsync(int id) =>
            await Task.FromResult(_products.Single(p => p.Id == id));
    }
}

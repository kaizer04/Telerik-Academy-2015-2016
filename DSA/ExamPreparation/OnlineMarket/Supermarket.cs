namespace OnlineMarket
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Supermarket
    {
        private IDictionary<string, SortedSet<Product>> productsByType;
        private IDictionary<double, SortedSet<Product>> productsByPrice;
        private ISet<string> productNames;
        private SortedSet<double> allPrices;

        public Supermarket()
        {
            this.productsByType = new Dictionary<string, SortedSet<Product>>();
            this.productNames = new HashSet<string>();
            this.productsByPrice = new SortedDictionary<double, SortedSet<Product>>();
            this.allPrices = new SortedSet<double>();
        }

        public string Add(Product product)
        {
            // check unique names
            if (productNames.Contains(product.Name))
            {
                return string.Format("Error: Product {0} already exists", product.Name);
            }

            productNames.Add(product.Name);

            // add by type
            if (!productsByType.ContainsKey(product.Type))
            {
                productsByType[product.Type] = new SortedSet<Product>();
            }

            this.productsByType[product.Type].Add(product);

            // add by price
            this.allPrices.Add(product.Price);

            if (!this.productsByPrice.ContainsKey(product.Price))
            {
                this.productsByPrice[product.Price] = new SortedSet<Product>();
            }

            this.productsByPrice[product.Price].Add(product);

            return string.Format("Ok: Product {0} added successfully", product.Name);
        }

        public IEnumerable<Product> FilterByType(string type)
        {
            if (!this.productsByType.ContainsKey(type))
            {
                return Enumerable.Empty<Product>();
            }

            return this.productsByType[type].Take(10);
        }

        public IEnumerable<Product> FilterByPrice(double minPrice, double maxPrice)
        {
            var prices = this.allPrices.GetViewBetween(minPrice, maxPrice);

            var filteredProducts = new SortedSet<Product>();

            int taken = 0;

            foreach (var price in prices)
            {
                foreach (var product in this.productsByPrice[price])
                {
                    if (taken == 10)
                    {
                        return filteredProducts;
                    }

                    filteredProducts.Add(product);
                    taken++;
                }
            }

            return filteredProducts;
        }
    }
}

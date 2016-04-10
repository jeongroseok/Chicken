namespace Chicken
{
    public class OrderDetail
    {
        private Customer customer;
        private Product product;

        public Customer Customer { get { return customer; } }
        public Product Product { get { return product; } }

        public OrderDetail(Customer customer, Product product)
        {
            this.customer = customer;
            this.product = product;
        }
    }
}


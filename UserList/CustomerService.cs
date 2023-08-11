public class CustomerService
{
        public bool CreateCustomer(CustomerDbContext dbContext, string _name, string _phoneNumber)
        {
            try
            {
                Customer customer = new Customer
                {
                    Id = 0,
                    Name = _name,
                    PhoneNumber = _phoneNumber
                };

                dbContext.Customers.Add(customer); // Use the correct DbSet name
                dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving customer: " + ex.Message);
                return false;
            }
        }



    public List<Customer> ListAllCustomers(CustomerDbContext dbContext)
{
    return dbContext.Customers.ToList(); // Use the correct DbSet name
}


}

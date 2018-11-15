using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using model;
using System.Threading.Tasks;


namespace tests
{
    [TestClass]
    public class UnitTest1
    {
        CompanyContext _context;
        [TestInitialize]
        public void addACustomer()
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();

            DbContextOptions options = builder.UseSqlServer(@"Data source=MSI; Initial Catalog=laboPostToussaint; User Id=test; Password=test1").Options;
        
            _context = new CompanyContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _context.Customers.Add(new Customer(){
                AddressLine1="Rue J. Calozet, 19",
                PostCode="5000",
                City="Namur",
                AccountBalance=12,
                Name="Doe",
                Country="Belgique",
                EMail="info@doe.com",
                Remark="Client suspect"
            });
            _context.SaveChanges();
        }

        [TestMethod]
        public async Task TestMethod()
        {
            Customer client=await _context.Customers.FirstAsync();
            Assert.AreEqual("5000", client.PostCode);
        }
    }
}

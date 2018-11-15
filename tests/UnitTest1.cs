using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;

namespace tests
{
    [TestClass]
    public class UnitTest1
    {
        CompanyContext _context;
        [TestInitialize]
        public void TestMethod1()
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();

            DbContextOptions options = builder.UseSqlServer(@"Data source=ADRESSE_SERVEUR; Initial Catalog=VOTRE_DB; User Id=VOTRE_USER; Password=VOTRE_PASSWORD").Options;
        
            _context = new CompanyContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _context.Customers.Add(new Customer(){
                AddressLine1="Rue J. Calozet, 19",
                PostCode="5000",
                City="Namur",
                AccountBalance=12,
                nameof="Doe",
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

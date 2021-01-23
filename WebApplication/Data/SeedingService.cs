using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Models.Enums;


namespace WebApplication.Data
{
    public class SeedingService
    {
        private WebApplicationContext _context;

        public SeedingService(WebApplicationContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecords.Any())
            {
                return; //BD já foi populado
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "Vendedor01", "vendedor01@gmail.com", new DateTime(1993, 11, 8), 10000.00, d1);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2021, 01, 22), 11000.0, SaleStatus.Billed, s1);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1);
            _context.SalesRecords.AddRange(r1);
            _context.SaveChanges();
        }
           
    }
}

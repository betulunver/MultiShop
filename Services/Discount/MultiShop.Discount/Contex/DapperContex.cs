using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultiShop.Discount.Entities;
using System.Data;
using System.Diagnostics.Metrics;

namespace MultiShop.Discount.Contex
{
    public class DapperContex : DbContext
    {
        private readonly   IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContex(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection"); //appsettingsteki isim

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = LAPTOP-D5489TA1; Initial Catalog=MultiShopDiscountDb; Integrated Security = True;");

        }
        public DbSet<Coupon> Coupons { get; set; }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}

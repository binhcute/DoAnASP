using DoAnGiay.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnGiay.Areas.Admin.Data
{
    public class DPContext:DbContext
    {
        public DPContext(DbContextOptions<DPContext> options)
            :base(options)
        {

        }
        public DbSet<AccountModel> Account { get; set; }
        public DbSet<AdminModel> Admin { get; set; }
        public DbSet<UserModel> User { get; set; }
        public DbSet<RolesModel> Roles { get; set; }
        public DbSet<ShoeModel> Shoe { get; set; }
        public DbSet<TypeShoeModel> TypeShoe { get; set; }
        public DbSet<ColorModel> Color { get; set; }
        public DbSet<SizeModel> Size { get; set; }
        public DbSet<ProducerModel> Producer { get; set; }
        public DbSet<OrderDetailsModel> OrderDetail { get; set; }
        public DbSet<OrderModel> Order { get; set; }
        public DbSet<CommentModel> Comment { get; set; }
        public DbSet<DoAnGiay.Areas.Admin.Models.MaterialModel> MaterialModel { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using FactoryFurnitureDataBase.Models;

namespace FactoryFurnitureDataBase
{
    public class FactoryFurnitureDataBase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-GDNE8QD\MYSQLDATABASE;Initial Catalog=FactoryFurnitureDataBase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Client> Clients { set; get; }
        public virtual DbSet<Furniture> Furnitures { set; get; }
        public virtual DbSet<Material> Materials { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<FurnitureMaterial> FurnitureMaterials { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<RequestMaterial> RequestMaterials { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
    }
}

using KursovayaMAIN.Model;
using Microsoft.EntityFrameworkCore;

namespace KursovayaMAIN.Helper
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Users> Users { get; set; } = null!;
        public DbSet<Weapons> Weapons { get; set; } = null!;
        public DbSet<Equipments> Equipments { get; set; } = null!;
        public DbSet<Consumables> Consumables { get; set; } = null!;
        public DbSet<Orders> Orders { get; set; } = null!;

        public DbSet<Weapons_Equipments_Consumable_OrdersDPO> Weapons_Equipments_Consumables_Orders { get; set; } = null!;

        //public DbSet<Weapons_Equipments_Consumables_Orders> Weapons_Equipments_Consumables_Orders_Norm {  get; set; } = null!;
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=KursovayaBD.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>()
                .HasOne(o => o.Users)
                .WithMany(u => u.Order)
                .HasForeignKey(o => o.userID);
            modelBuilder.Entity<Orders>()
                .HasKey(o => o.orderId);
            modelBuilder.Entity<Users>()
                .HasKey(u => u.userId);
            modelBuilder.Entity<Weapons>()
                .HasKey(w => w.weaponId);
            modelBuilder.Entity<Weapons_Equipments_Consumable_OrdersDPO>()
                .HasKey(weco => weco.weaponsEquipmentsConsumablesOrdersId);
            modelBuilder.Entity<Weapons_Equipments_Consumable_OrdersDPO>()
                .HasOne(weco => weco.Order)
                .WithMany(o => o.Wpn_Eqmt_Cnle_Ord)
                .HasForeignKey(weco => weco.OrderId);

            modelBuilder.Entity<Weapons_Equipments_Consumable_OrdersDPO>()
                .HasOne(weco => weco.Equipment)
                .WithMany(e => e.Wpn_Eqmt_Cnle_Ord)
                .HasForeignKey(weco => weco.EquipmentId);
            modelBuilder.Entity<Weapons_Equipments_Consumable_OrdersDPO>()
                .HasOne(weco => weco.Consumable)
                .WithMany(c => c.Wpn_Eqmt_Cnle_Ord)
                .HasForeignKey(weco => weco.ConsumableId);
            modelBuilder.Entity<Weapons_Equipments_Consumable_OrdersDPO>()
                .HasOne(weco => weco.Weapon)
                .WithMany(w => w.Wpn_Eqmt_Cnle_Ord)
                .HasForeignKey(weco => weco.WeaponId);
            modelBuilder.Entity<Consumables>()
                .HasKey(c => c.consumableId) ;
            modelBuilder.Entity<Equipments>()
                .HasKey(c => c.equipmentId);
        }
    }
}

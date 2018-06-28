using Microsoft.EntityFrameworkCore;
using Oxxo2.Models;

namespace Oxxo2.DataAccess
{
    public class OxxoContext: DbContext
    {
        public OxxoContext()
        {
        }

        public OxxoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuarios> Usuario { get; set; }

        public DbSet<Proveedores> Proveedor { get; set; }

        public DbSet<Productos> Producto { get; set; }

        public DbSet<Inventarios> Inventario { get; set; }

        public DbSet<InvProdModel> InventarioProducto { get; set; }

        public DbSet<Schedulers> Scheduler { get; set; }

        public DbSet<Enable> Enabled { get; set; }

        public DbSet<Monitoreo> Monitor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=VORTIZ\\SQLSERVER2012;Initial Catalog=OXXO;Integrated Security=True");
            optionsBuilder.UseSqlServer("Data Source=192.168.1.187;Initial Catalog=OXXO;Persist Security Info=True;User ID=UserOXXO;Password=Passw0rd");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>(Usuario => {
                Usuario.ToTable("Usuarios");
                Usuario.HasKey("UsuarioId");
        });
            modelBuilder.Entity<Proveedores>(Proveedor => {
                Proveedor.ToTable("Proveedores");
                Proveedor.HasKey("ProveedorId");
            });

            modelBuilder.Entity<Productos>(Producto => {
                Producto.ToTable("Productos");
                Producto.HasKey("ProductoId");
            });

            modelBuilder.Entity<Inventarios>(Inventario => {
                Inventario.ToTable("Inventarios");
                Inventario.HasKey("InventarioId");
            });

            modelBuilder.Entity<InvProdModel>(InventarioProducto => {
                InventarioProducto.ToTable("ProductosInventario");
                InventarioProducto.HasKey("ProdInventId");
            });

            modelBuilder.Entity<Schedulers>(Scheduler => {
                Scheduler.ToTable("btScheduler");
                Scheduler.HasKey("SchedulerId");
            });

            modelBuilder.Entity<Enable>(Enabled => {
                Enabled.ToTable("btEnabler");
                Enabled.HasKey("EnablerId");
            });

            modelBuilder.Entity<Monitoreo>(Monitor => {
                Monitor.ToTable("btMonitoreo");
                Monitor.HasKey("MonitorId");
            });

            base.OnModelCreating(modelBuilder); 
        }   

    }
}

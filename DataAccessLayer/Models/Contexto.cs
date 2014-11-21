using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Contexto : DbContext
    {
        //
        public Contexto()
            : base("BD3SoftBL")
        {
            System.Diagnostics.Debug.Print(Database.Connection.ConnectionString);
        }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {          
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }

        public override int SaveChanges()
        {

            var creados = this.ChangeTracker.Entries()
                            .Where(e => e.State == System.Data.Entity.EntityState.Added)
                            .Select(e => e.Entity).OfType<Generica>().ToList();

            foreach (var item in creados)
            {
                item.CreatedAt = DateTime.Now;
                item.CreatedBy = null;
            }

            var modificados = this.ChangeTracker.Entries()
                            .Where(e => e.State == System.Data.Entity.EntityState.Modified)
                            .Select(e => e.Entity).OfType<Generica>().ToList();

            foreach (var item in modificados)
            {
                item.EditedAt = DateTime.Now;
                item.EditedBy = null;
            }

            
            
            return base.SaveChanges();
            

        }


        public virtual DbSet<tmp> tmps { get; set; }
        public virtual DbSet<Usuario> DBSusuarios { get; set; }

        public virtual DbSet<UnidadesPresupuestales> DBSUnidadesPresupuestales { get; set; }

        public virtual DbSet<PartidasContables> DBSPartidasContables { get; set; }

        public virtual DbSet<Empleados> DBSEmpleados { get; set; }
        public virtual DbSet<Ejercicios> DBSEjercicios { get; set; }

        public virtual DbSet<Proveedores> DBSProveedores { get; set; }

        public virtual DbSet<GruposPS> DBSGruposPS { get; set; }

        public virtual DbSet<Articulos> DBSArticulos { get; set; }
        public virtual DbSet<UnidadesDeMedida> DBSUnidadesDeMedida { get; set; }

        public virtual DbSet<Servicios> DBSServicios { get; set; }

        public virtual DbSet<TiempoDeEntrega> DBSTiempoDeEntrega { get; set; }
        public virtual DbSet<FormaDePago> DBSFormaDePago { get; set; }


        public virtual DbSet<Solicitudes> DBSSolicitudes { get; set; }
        public virtual DbSet<SolicitudesArticulos> DBSSolicitudesArticulos { get; set; }
        public virtual DbSet<SolicitudesServicios> DBSSolicitudesServicios { get; set; }
        public virtual DbSet<Cotizaciones> DBSCotizaciones { get; set; }
        public virtual DbSet<CotizacionesArticulos> DBSCotizacionesArticulos { get; set; }
        public virtual DbSet<CotizacionesServicios> DBSCotizacionesServicios { get; set; }

        public virtual DbSet<AsignacionesArticulos> DBSAsignacionesArticulos { get; set; }
        public virtual DbSet<AsignacionesServicios> DBSAsignacionesServicios { get; set; }


        public virtual DbSet<Pedidos> DBSPedidos { get; set; }
        public virtual DbSet<PedidosArticulos> DBSPedidosArticulos { get; set; }
        public virtual DbSet<PedidosServicios> DBSPedidosServicios { get; set; }


        public virtual DbSet<ComprasMenores> DBSComprasMenores { get; set; }
        public virtual DbSet<ComprasMenoresArticulos> DBSComprasMenoresArticulos { get; set; }
        public virtual DbSet<ComprasMenoresServicios> DBSComprasMenoresServicios { get; set; }


        public virtual DbSet<Clientes> DBSClientes { get; set; }
        public virtual DbSet<Ventas> DBSVentas { get; set; }
        public virtual DbSet<VentasArticulos> DBSVentasArticulos { get; set; }
        public virtual DbSet<FacturasVentas> DBSFacturas { get; set; }
        public virtual DbSet<FacturasVentasArticulos> DBSFacturasVentasArticulos { get; set; }



        public virtual DbSet<InventarioInicial> DBSInventarioInicial { get; set; }
        public virtual DbSet<InventarioInicialArticulos> DBSInventarioInicialArticulos { get; set; }
        public virtual DbSet<InventarioInicialArticulosCostos> DBSInventarioInicialArticulosCostos { get; set; }
        public virtual DbSet<InventarioInicialArticulosMigrate> DBSInventarioInicialArticulosMigrate { get; set; }

        public virtual DbSet<AlmacenEntradasGenericas> DBSAlmacenEntradasGenericas { get; set; }
        public virtual DbSet<AlmacenEntradasGenericasArticulos> DBSAlmacenEntradasGenericasArticulos { get; set; }
        public virtual DbSet<AlmacenSalidasGenericas> DBSAlmacenSalidasGenericas { get; set; }
        public virtual DbSet<AlmacenSalidasGenericasArticulos> DBSAlmacenSalidasGenericasArticulos { get; set; }
        public virtual DbSet<AlmacenValeSalida> DBSAlmacenValeSalida { get; set; }
        public virtual DbSet<AlmacenValeSalidaArticulos> DBSAlmacenValeSalidaArticulos { get; set; }


        public virtual DbSet<FacturasAlmacen> DBSFacturaAlmacen { get; set; }
        public virtual DbSet<FacturasAlmacenArticulos> DBSFacturaAlmacenArticulos { get; set; }
        
        public virtual DbSet<ArticulosMovimientos> DBSArticulosMovimientos { get; set; }
        public virtual DbSet<ArticulosMovimientosEntradas> DBSArticulosMovimientosEntradas { get; set; }
        public virtual DbSet<ArticulosMovimientosSalidas> DBSArticulosMovimientosSalidas { get; set; }


    }
}

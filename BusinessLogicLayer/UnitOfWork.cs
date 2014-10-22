using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;

namespace BusinessLogicLayer
{
    public class UnitOfWork : IDisposable
    {       
        internal Contexto contexto;
        private List<String> errors = new List<String>();

        private IBusinessLogic<tmp> tmpBL;
        private IBusinessLogic<Usuario> usuarioBL;
        private IBusinessLogic<UnidadesPresupuestales> unidadespresupuestalesBL;
        private IBusinessLogic<PartidasContables> partidascontablesBL;
        private IBusinessLogic<Empleados> empleadosBL;
        private IBusinessLogic<Ejercicios> ejerciciosBL;
        private IBusinessLogic<Proveedores> proveedoresBL;
        private IBusinessLogic<GruposPS> grupospsBL;
        private IBusinessLogic<Articulos> artiulosBL;
        private IBusinessLogic<UnidadesDeMedida> unidadesdemedidaBL;
        private IBusinessLogic<Servicios> serviciosBL;

        private IBusinessLogic<TiempoDeEntrega> tiempodeentregaBL;
        private IBusinessLogic<FormaDePago> formadepagoBL;

        private IBusinessLogic<Solicitudes> solicitudesBL;
        private IBusinessLogic<SolicitudesArticulos> solicitudesarticulosBL;
        private IBusinessLogic<SolicitudesServicios> solicitudesserviciosBL;
        private IBusinessLogic<Cotizaciones> cotizacionesBL;
        private IBusinessLogic<CotizacionesArticulos> cotizacionesarticulosBL;
        private IBusinessLogic<CotizacionesServicios> cotizacionesserviciosBL;
        private IBusinessLogic<AsignacionesArticulos> asignacionesarticulosBL;
        private IBusinessLogic<AsignacionesServicios> asignacionesserviciosBL;

        private IBusinessLogic<Pedidos> pedidosBL;
        private IBusinessLogic<PedidosArticulos> pedidosarticulosBL;
        private IBusinessLogic<PedidosServicios> pedidosserviciosBL;

        private IBusinessLogic<ComprasMenores> comprasmenoresBL;
        private IBusinessLogic<ComprasMenoresArticulos> comprasmenoresarticulosBL;
        private IBusinessLogic<ComprasMenoresServicios> comprasmenoresserviciosBL;


        private IBusinessLogic<Clientes> clientesBL;
        private IBusinessLogic<Ventas> ventasBL;
        private IBusinessLogic<VentasArticulos> ventasarticulosBL;
        private IBusinessLogic<FacturasVentas> facturasventasBL;
        private IBusinessLogic<FacturasVentasArticulos> facturasventasarticulosBL;


        private IBusinessLogic<InventarioInicial> inventarioinicialBL;
        private IBusinessLogic<InventarioInicialArticulos> inventarioinicialarticulosBL;
        private IBusinessLogic<InventarioInicialArticulosCostos> inventarioinicialarticuloscostosBL;

        private IBusinessLogic<AlmacenEntradasGenericas> almacenentradasgenericasBL;
        private IBusinessLogic<AlmacenEntradasGenericasArticulos> almacenentradasgenericasarticulosBL;
        private IBusinessLogic<AlmacenSalidasGenericas> almacensalidasgenericasBL;
        private IBusinessLogic<AlmacenSalidasGenericasArticulos> almacensalidasgenericasarticulosBL;
        private IBusinessLogic<AlmacenValeSalida> almacenvalesalidaBL;
        private IBusinessLogic<AlmacenValeSalidaArticulos> almacenvalesalidaarticulosBL;

        private IBusinessLogic<FacturasAlmacen> facturasalmacenBL;
        private IBusinessLogic<FacturasAlmacenArticulos> facturasalmacenarticulosBL;

        private IBusinessLogic<ArticulosMovimientos> articulosmovimientosBL;
        private IBusinessLogic<ArticulosMovimientosEntradas> articulosmovimientosentradasBL;
        private IBusinessLogic<ArticulosMovimientosSalidas> articulosmovimientossalidasBL;



        public UnitOfWork()
        {
            this.contexto = new Contexto();
        }

        //
        public IBusinessLogic<tmp> TmpBL
        {
            get {

                if (this.tmpBL == null)
                {
                    this.tmpBL = new GenericBusinessLogic<tmp>(contexto);
                }
                return this.tmpBL;
            }        
        }

        public IBusinessLogic<Usuario> UsuarioBL
        {
            get
            {

                if (this.usuarioBL == null)
                {
                    this.usuarioBL = new GenericBusinessLogic<Usuario>(contexto);
                }
                return this.usuarioBL;
            }
        }
        public IBusinessLogic<UnidadesPresupuestales> UnidadesPresupuestalesBL
        {
            get
            {

                if (this.unidadespresupuestalesBL == null)
                {
                    this.unidadespresupuestalesBL = new GenericBusinessLogic<UnidadesPresupuestales>(contexto);
                }
                return this.unidadespresupuestalesBL;
            }
        }

        public IBusinessLogic<PartidasContables> PartidasContablesBL
        {
            get
            {

                if (this.partidascontablesBL == null)
                {
                    this.partidascontablesBL  = new GenericBusinessLogic<PartidasContables>(contexto);
                }
                return this.partidascontablesBL;
            }
        }

        public IBusinessLogic<Empleados> EmpleadosBL
        {
            get
            {

                if (this.empleadosBL == null)
                {
                    this.empleadosBL = new GenericBusinessLogic<Empleados>(contexto);
                }
                return this.empleadosBL;
            }
        }

        public IBusinessLogic<Ejercicios> EjerciciosBL
        {
            get
            {

                if (this.ejerciciosBL == null)
                {
                    this.ejerciciosBL = new GenericBusinessLogic<Ejercicios>(contexto);
                }
                return this.ejerciciosBL;
            }
        }

        public IBusinessLogic<Proveedores> ProveedoresBL
        {
            get
            {
                if (this.proveedoresBL == null)
                {
                    this.proveedoresBL = new GenericBusinessLogic<Proveedores>(contexto);
                }
                return this.proveedoresBL;
            }
        }

        public IBusinessLogic<GruposPS> GruposPSBL
        {
            get
            {
                if (this.grupospsBL == null)
                {
                    this.grupospsBL = new GenericBusinessLogic<GruposPS>(contexto);
                }
                return this.grupospsBL;
            }
        }

        public IBusinessLogic<Articulos> ArticulosBL
        {
            get
            {
                if (this.artiulosBL == null)
                {
                    this.artiulosBL = new GenericBusinessLogic<Articulos>(contexto);
                }
                return this.artiulosBL;
            }
        }

        public IBusinessLogic<UnidadesDeMedida> UnidadesDeMedidaBL
        {
            get
            {
                if (this.unidadesdemedidaBL == null)
                {
                    this.unidadesdemedidaBL = new GenericBusinessLogic<UnidadesDeMedida>(contexto);
                }
                return this.unidadesdemedidaBL;
            }
        }

        public IBusinessLogic<Servicios> ServiciosBL
        {
            get
            {
                if (this.serviciosBL == null)
                {
                    this.serviciosBL = new GenericBusinessLogic<Servicios>(contexto);
                }
                return this.serviciosBL;
            }
        }

        public IBusinessLogic<TiempoDeEntrega> TiempoDeEntregaBL
        {
            get
            {
                if (this.tiempodeentregaBL == null)
                {
                    this.tiempodeentregaBL = new GenericBusinessLogic<TiempoDeEntrega>(contexto);
                }
                return this.tiempodeentregaBL;
            }
        }

        public IBusinessLogic<FormaDePago> FormaDePagoBL
        {
            get
            {
                if (this.formadepagoBL == null)
                {
                    this.formadepagoBL = new GenericBusinessLogic<FormaDePago>(contexto);
                }
                return this.formadepagoBL;
            }
        }

        public IBusinessLogic<Solicitudes> SolicitudesBL
        {
            get
            {
                if (this.solicitudesBL == null)
                {
                    this.solicitudesBL = new GenericBusinessLogic<Solicitudes>(contexto);
                }
                return this.solicitudesBL;
            }
        }

        public IBusinessLogic<SolicitudesArticulos> SolicitudesArticulosBL
        {
            get
            {
                if (this.solicitudesarticulosBL == null)
                {
                    this.solicitudesarticulosBL = new GenericBusinessLogic<SolicitudesArticulos>(contexto);
                }
                return this.solicitudesarticulosBL;
            }
        }

        public IBusinessLogic<SolicitudesServicios> SolicitudesServiciosBL
        {
            get
            {
                if (this.solicitudesserviciosBL == null)
                {
                    this.solicitudesserviciosBL = new GenericBusinessLogic<SolicitudesServicios>(contexto);
                }
                return this.solicitudesserviciosBL;
            }
        }

        public IBusinessLogic<Cotizaciones> CotizacionesBL
        {
            get
            {
                if (this.cotizacionesBL == null)
                {
                    this.cotizacionesBL = new GenericBusinessLogic<Cotizaciones>(contexto);
                }
                return this.cotizacionesBL;
            }
        }

        public IBusinessLogic<CotizacionesArticulos> CotizacionesArticulosBL
        {
            get
            {
                if (this.cotizacionesarticulosBL == null)
                {
                    this.cotizacionesarticulosBL = new GenericBusinessLogic<CotizacionesArticulos>(contexto);
                }
                return this.cotizacionesarticulosBL;
            }
        }

        public IBusinessLogic<CotizacionesServicios> CotizacionesServiciosBL
        {
            get
            {
                if (this.cotizacionesserviciosBL == null)
                {
                    this.cotizacionesserviciosBL = new GenericBusinessLogic<CotizacionesServicios>(contexto);
                }
                return this.cotizacionesserviciosBL;
            }
        }

        public IBusinessLogic<AsignacionesArticulos> AsignacionesArticulosBL
        {
            get
            {
                if (this.asignacionesarticulosBL == null)
                {
                    this.asignacionesarticulosBL = new GenericBusinessLogic<AsignacionesArticulos>(contexto);
                }
                return this.asignacionesarticulosBL;
            }
        }

        public IBusinessLogic<AsignacionesServicios> AsignacionesServiciosBL
        {
            get
            {
                if (this.asignacionesserviciosBL == null)
                {
                    this.asignacionesserviciosBL = new GenericBusinessLogic<AsignacionesServicios>(contexto);
                }
                return this.asignacionesserviciosBL;
            }
        }


        
        public IBusinessLogic<Pedidos> PedidosBL
        {
            get
            {
                if (this.pedidosBL == null)
                {
                    this.pedidosBL = new GenericBusinessLogic<Pedidos>(contexto);
                }
                return this.pedidosBL;
            }
        }


        public IBusinessLogic<PedidosArticulos> PedidosArticulosBL
        {
            get
            {
                if (this.pedidosarticulosBL == null)
                {
                    this.pedidosarticulosBL = new GenericBusinessLogic<PedidosArticulos>(contexto);
                }
                return this.pedidosarticulosBL;
            }
        }


        public IBusinessLogic<PedidosServicios> PedidosServiciosBL
        {
            get
            {
                if (this.pedidosserviciosBL == null)
                {
                    this.pedidosserviciosBL= new GenericBusinessLogic<PedidosServicios>(contexto);
                }
                return this.pedidosserviciosBL;
            }
        }


        public IBusinessLogic<ComprasMenores> ComprasMenoresBL
        {
            get
            {
                if (this.comprasmenoresBL == null)
                {
                    this.comprasmenoresBL = new GenericBusinessLogic<ComprasMenores>(contexto);
                }
                return this.comprasmenoresBL;
            }
        }


        public IBusinessLogic<ComprasMenoresArticulos> ComprasMenoresArticulosBL
        {
            get
            {
                if (this.comprasmenoresarticulosBL == null)
                {
                    this.comprasmenoresarticulosBL = new GenericBusinessLogic<ComprasMenoresArticulos>(contexto);
                }
                return this.comprasmenoresarticulosBL;
            }
        }


        public IBusinessLogic<ComprasMenoresServicios> ComprasMenoresServiciosBL
        {
            get
            {
                if (this.comprasmenoresserviciosBL == null)
                {
                    this.comprasmenoresserviciosBL = new GenericBusinessLogic<ComprasMenoresServicios>(contexto);
                }
                return this.comprasmenoresserviciosBL;
            }
        }


        public IBusinessLogic<Clientes> ClientesBL
        {
            get
            {
                if (this.clientesBL == null)
                {
                    this.clientesBL = new GenericBusinessLogic<Clientes>(contexto);
                }
                return this.clientesBL;
            }
        }



        public IBusinessLogic<Ventas> VentasBL
        {
            get
            {
                if (this.ventasBL == null)
                {
                    this.ventasBL = new GenericBusinessLogic<Ventas>(contexto);
                }
                return this.ventasBL;
            }
        }
        
        public IBusinessLogic<VentasArticulos> VentasArticulosBL
        {
            get
            {
                if (this.ventasarticulosBL == null)
                {
                    this.ventasarticulosBL = new GenericBusinessLogic<VentasArticulos>(contexto);
                }
                return this.ventasarticulosBL;
            }
        }

        public IBusinessLogic<FacturasVentas> FacturasVentasBL
        {
            get
            {
                if (this.facturasventasBL == null)
                {
                    this.facturasventasBL = new GenericBusinessLogic<FacturasVentas>(contexto);
                }
                return this.facturasventasBL;
            }
        }
        
        public IBusinessLogic<FacturasVentasArticulos> FacturasVentasArticulosBL
        {
            get
            {
                if (this.facturasventasarticulosBL == null)
                {
                    this.facturasventasarticulosBL = new GenericBusinessLogic<FacturasVentasArticulos>(contexto);
                }
                return this.facturasventasarticulosBL;
            }
        }




        public IBusinessLogic<InventarioInicial> InventarioInicialBL
        {
            get
            {
                if (this.inventarioinicialBL == null)
                {
                    this.inventarioinicialBL = new GenericBusinessLogic<InventarioInicial>(contexto);
                }
                return this.inventarioinicialBL;
            }
        }

        public IBusinessLogic<InventarioInicialArticulos> InventarioInicialArticulosBL
        {
            get
            {
                if (this.inventarioinicialarticulosBL == null)
                {
                    this.inventarioinicialarticulosBL = new GenericBusinessLogic<InventarioInicialArticulos>(contexto);
                }
                return this.inventarioinicialarticulosBL;
            }
        }

        public IBusinessLogic<InventarioInicialArticulosCostos> InventarioInicialArticulosCostosBL
        {
            get
            {
                if (this.inventarioinicialarticuloscostosBL == null)
                {
                    this.inventarioinicialarticuloscostosBL = new GenericBusinessLogic<InventarioInicialArticulosCostos>(contexto);
                }
                return this.inventarioinicialarticuloscostosBL;
            }
        }



        public IBusinessLogic<AlmacenEntradasGenericas> AlmacenEntradasGenericasBL
        {
            get
            {
                if (this.almacenentradasgenericasBL == null)
                {
                    this.almacenentradasgenericasBL = new GenericBusinessLogic<AlmacenEntradasGenericas>(contexto);
                }
                return this.almacenentradasgenericasBL;
            }
        }
        public IBusinessLogic<AlmacenEntradasGenericasArticulos> AlmacenEntradasGenericasArticulosBL
        {
            get
            {
                if (this.almacenentradasgenericasarticulosBL == null)
                {
                    this.almacenentradasgenericasarticulosBL = new GenericBusinessLogic<AlmacenEntradasGenericasArticulos>(contexto);
                }
                return this.almacenentradasgenericasarticulosBL;
            }
        }



        public IBusinessLogic<AlmacenSalidasGenericas> AlmacenSalidasGenericasBL
        {
            get
            {
                if (this.almacensalidasgenericasBL == null)
                {
                    this.almacensalidasgenericasBL= new GenericBusinessLogic<AlmacenSalidasGenericas>(contexto);
                }
                return this.almacensalidasgenericasBL;
            }
        }
        public IBusinessLogic<AlmacenSalidasGenericasArticulos> AlmacenSalidasGenericasArticulos
        {
            get
            {
                if (this.almacensalidasgenericasarticulosBL == null)
                {
                    this.almacensalidasgenericasarticulosBL = new GenericBusinessLogic<AlmacenSalidasGenericasArticulos>(contexto);
                }
                return this.almacensalidasgenericasarticulosBL;
            }
        }


        public IBusinessLogic<AlmacenValeSalida> AlmacenValeSalidaBL
        {
            get
            {
                if (this.almacenvalesalidaBL == null)
                {
                    this.almacenvalesalidaBL = new GenericBusinessLogic<AlmacenValeSalida>(contexto);
                }
                return this.almacenvalesalidaBL;
            }
        }
        public IBusinessLogic<AlmacenValeSalidaArticulos> AlmacenValeSalidaArticulosBL
        {
            get
            {
                if (this.almacenvalesalidaarticulosBL == null)
                {
                    this.almacenvalesalidaarticulosBL = new GenericBusinessLogic<AlmacenValeSalidaArticulos>(contexto);
                }
                return this.almacenvalesalidaarticulosBL;
            }
        }


        public IBusinessLogic<FacturasAlmacen> FacturasAlmacenBL
        {
            get
            {
                if (this.facturasalmacenBL == null)
                {
                    this.facturasalmacenBL = new GenericBusinessLogic<FacturasAlmacen>(contexto);
                }
                return this.facturasalmacenBL;
            }
        }
        public IBusinessLogic<FacturasAlmacenArticulos> FacturasAlmacenArticulosBL
        {
            get
            {
                if (this.facturasalmacenarticulosBL == null)
                {
                    this.facturasalmacenarticulosBL = new GenericBusinessLogic<FacturasAlmacenArticulos>(contexto);
                }
                return this.facturasalmacenarticulosBL;
            }
        }


        public IBusinessLogic<ArticulosMovimientos> ArticulosMovimientosBL
        {
            get
            {
                if (this.articulosmovimientosBL == null)
                {
                    this.articulosmovimientosBL = new GenericBusinessLogic<ArticulosMovimientos>(contexto);
                }
                return this.articulosmovimientosBL;
            }
        }
        public IBusinessLogic<ArticulosMovimientosEntradas> ArticulosMovimientosEntradasBL
        {
            get
            {
                if (this.articulosmovimientosentradasBL == null)
                {
                    this.articulosmovimientosentradasBL = new GenericBusinessLogic<ArticulosMovimientosEntradas>(contexto);
                }
                return this.articulosmovimientosentradasBL;
            }
        }
        public IBusinessLogic<ArticulosMovimientosSalidas> ArticulosMovimientosSalidasBL
        {
            get
            {
                if (this.articulosmovimientossalidasBL == null)
                {
                    this.articulosmovimientossalidasBL = new GenericBusinessLogic<ArticulosMovimientosSalidas>(contexto);
                }
                return this.articulosmovimientossalidasBL;
            }
        }










        public void SaveChanges()
        {
            try
            {
                errors.Clear();
                contexto.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {

                this.RollBack();

                foreach (var item in ex.EntityValidationErrors)
                {

                    errors.Add(String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors", item.Entry.Entity.GetType().Name, item.Entry.State));

                    foreach (var error in item.ValidationErrors)
                    {
                        errors.Add(String.Format("Propiedad: \"{0}\", Error: \"{1}\"", error.PropertyName, error.ErrorMessage));
                    }


                }

            }
            catch (DbUpdateException ex)
            {
                this.RollBack();
                errors.Add(String.Format("{0}", ex.InnerException.InnerException.Message));
            }
            catch (System.InvalidOperationException ex)
            {
                this.RollBack();
                errors.Add(String.Format("{0}", ex.Message));
            }
            catch (Exception ex)
            {
                this.RollBack();
                errors.Add(String.Format("{0}\n{1}", ex.Message, ex.InnerException.Message));
            }
            
        }

        public List<String> Errors 
        {
            get 
            {
                return errors;
            }
        }


        public void RollBack()
        {
           
            var changedEntries = contexto.ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged);

            #region < Pendiente revisar, esto podria cancelar toda una sesión de trabajo >

            //foreach (var entry in changedEntries.Where(x => x.State == EntityState.Modified))
            //{
            //    entry.CurrentValues.SetValues(entry.OriginalValues);
            //    entry.State = EntityState.Unchanged;
            //}

            //foreach (var entry in changedEntries.Where(x => x.State == EntityState.Added))
            //{
            //    entry.State = EntityState.Detached;
            //} 

            #endregion

            foreach (var entry in changedEntries.Where(x => x.State == EntityState.Deleted))
            {
                entry.State = EntityState.Unchanged;
            }
            
        }
        
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    contexto.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OcasaPabloInsua.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Test1Entities : DbContext
    {
        public Test1Entities()
            : base("name=Test1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cliente> Cliente { get; set; }
    
        public virtual int sp_ActualizarCliente(Nullable<int> idCliente, string razonSocial, string direccion)
        {
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("idCliente", idCliente) :
                new ObjectParameter("idCliente", typeof(int));
    
            var razonSocialParameter = razonSocial != null ?
                new ObjectParameter("RazonSocial", razonSocial) :
                new ObjectParameter("RazonSocial", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("Direccion", direccion) :
                new ObjectParameter("Direccion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ActualizarCliente", idClienteParameter, razonSocialParameter, direccionParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_ConsultarCliente(Nullable<int> idCliente)
        {
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_ConsultarCliente", idClienteParameter);
        }
    
        public virtual int sp_InsertarCliente(Nullable<int> idCliente, string razonSocial, string direccion)
        {
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(int));
    
            var razonSocialParameter = razonSocial != null ?
                new ObjectParameter("RazonSocial", razonSocial) :
                new ObjectParameter("RazonSocial", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("Direccion", direccion) :
                new ObjectParameter("Direccion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertarCliente", idClienteParameter, razonSocialParameter, direccionParameter);
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;

namespace PROYECTO_APP_BusCar.DOMAIN.Infrastructure.Data
{
    public partial class DB_BUSContext : DbContext
    {
        public DB_BUSContext()
        {
        }

        public DB_BUSContext(DbContextOptions<DB_BUSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asiento> Asiento { get; set; } = null!;
        public virtual DbSet<AsientoProgramacion> AsientoProgramacion { get; set; } = null!;
        public virtual DbSet<Boleto> Boleto { get; set; } = null!;
        public virtual DbSet<Bus> Bus { get; set; } = null!;
        public virtual DbSet<Cargo> Cargo { get; set; } = null!;
        public virtual DbSet<Cliente> Cliente { get; set; } = null!;
        public virtual DbSet<Comprobante> Comprobante { get; set; } = null!;
        public virtual DbSet<Destino> Destino { get; set; } = null!;
        public virtual DbSet<DetalleReserva> DetalleReserva { get; set; } = null!;
        public virtual DbSet<Documento> Documento { get; set; } = null!;
        public virtual DbSet<Marca> Marca { get; set; } = null!;
        public virtual DbSet<Modelo> Modelo { get; set; } = null!;
        public virtual DbSet<Nivel> Nivel { get; set; } = null!;
        public virtual DbSet<Origen> Origen { get; set; } = null!;
        public virtual DbSet<PagosPaypal> PagosPaypal { get; set; } = null!;
        public virtual DbSet<Personal> Personal { get; set; } = null!;
        public virtual DbSet<Precio> Precio { get; set; } = null!;
        public virtual DbSet<Programacion> Programacion { get; set; } = null!;
        public virtual DbSet<Reserva> Reserva { get; set; } = null!;
        public virtual DbSet<Tripulacion> Tripulacion { get; set; } = null!;
        public virtual DbSet<Usuario> Usuario { get; set; } = null!;
        public virtual DbSet<Output> Output { get; set; } = null!;
        public virtual DbSet<Input> Input { get; set; } = null!;

        public virtual DbSet<OutProgramacionViaje> OutProgramacionViaje { get; set; } = null!;
        public virtual DbSet<InProgramacionViaje> InProgramacionViaje { get; set; } = null!;

        public virtual DbSet<OutProgramacionAsiento> OutProgramacionAsiento { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-0QQ6P4G\\SQLEXPRESS;Database=DB_BUS;Integrated Security = true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asiento>(entity =>
            {
                
                entity.HasKey(e => e.IdAsiento)
                .HasName("PK_ASIENTO");


                entity.ToTable("ASIENTO");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();

                entity.Property(e => e.IdAsiento).HasColumnName("id_asiento");

                entity.Property(e => e.IdBus).HasColumnName("id_bus");

                entity.Property(e => e.IdNivel).HasColumnName("id_nivel");

                entity.Property(e => e.NumeroAsiento).HasColumnName("numero_asiento");

                entity.Property(e => e.CostoAsiento).HasColumnType("decimal(10, 2)").HasColumnName("COSTO_asiento");

                entity.HasOne(d => d.IdBusNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdBus)
                    .HasConstraintName("FK_ASIENTO_BUS");

                entity.HasOne(d => d.IdNivelNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdNivel)
                    .HasConstraintName("FK_ASIENTO_NIVEL");
            });

            modelBuilder.Entity<AsientoProgramacion>(entity =>
            {
                entity.HasKey(e => e.IdAsientoProg)
                .HasName("PK_ASIENTO_PROGRAMACION");

                entity.ToTable("ASIENTO_PROGRAMACION");

                entity.Property(e => e.IdAsientoProg).HasColumnName("id_asiento_prog");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();

                entity.Property(e => e.CostoAsiento).HasColumnType("decimal(10, 2)").HasColumnName("costo_asiento");

               entity.Property(e => e.IdAsiento).HasColumnName("id_asiento");

                entity.Property(e => e.IdProgramacion).HasColumnName("id_programacion");

                entity.HasOne(d => d.IdProgramacionNavigation)
                    .WithMany(p => p.AsientoProgramacion)
                    .HasForeignKey(d => d.IdProgramacion)
                    .HasConstraintName("FK_ASIENTO_PROGRAMACION_PROGRAMACION");


                entity.HasOne(d => d.IdAsientoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdAsiento)
                    .HasConstraintName("FK_ASIENTO_PROGRAMACION_ASIENTO");

            });

            modelBuilder.Entity<Boleto>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BOLETO");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Correlativo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correlativo");

                entity.Property(e => e.DocumentoReferencia)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("documento_referencia");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();

                entity.Property(e => e.FechaExpedicion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_expedicion");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_registro");

                entity.Property(e => e.FechaViaje)
                    .HasColumnType("date")
                    .HasColumnName("fecha_viaje");

                entity.Property(e => e.HoraPartida).HasColumnName("hora_partida");

                entity.Property(e => e.IdAsientoProg).HasColumnName("id_asiento_prog");

                entity.Property(e => e.IdBoleto).HasColumnName("id_boleto");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdComprobante).HasColumnName("id_comprobante");

                entity.Property(e => e.IdDestino).HasColumnName("id_destino");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Importe)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("importe");

                entity.Property(e => e.Moneda)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("moneda");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("precio");

                entity.Property(e => e.Serie)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("serie");

                entity.HasOne(d => d.IdAsientoProgNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdAsientoProg)
                    .HasConstraintName("FK_BOLETO_ASIENTO_PROGRAMACION");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_BOLETO_CLIENTE");

                entity.HasOne(d => d.IdComprobanteNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdComprobante)
                    .HasConstraintName("FK_BOLETO_COMPROBANTE");

                entity.HasOne(d => d.IdDestinoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdDestino)
                    .HasConstraintName("FK_BOLETO_DESTINO");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_BOLETO_USUARIO");
            });

            modelBuilder.Entity<Bus>(entity =>
            {
                entity.HasKey(e => e.IdBus);

                entity.ToTable("BUS");

                entity.Property(e => e.IdBus).HasColumnName("id_bus");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();

                entity.Property(e => e.IdMarca).HasColumnName("id_marca");

                entity.Property(e => e.IdModelo).HasColumnName("id_modelo");

                entity.Property(e => e.NroAsientos).HasColumnName("nro_asientos");

                entity.Property(e => e.Placa)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("placa");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Bus)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("FK_BUS_MARCA");

                entity.HasOne(d => d.IdModeloNavigation)
                    .WithMany(p => p.Bus)
                    .HasForeignKey(d => d.IdModelo)
                    .HasConstraintName("FK_BUS_MODELO");
            });

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.HasKey(e => e.IdCargo);

                entity.ToTable("CARGO");

                entity.Property(e => e.IdCargo).HasColumnName("id_cargo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("CLIENTE");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.ApellidoM)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellidom");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Dni)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("dni");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fecha_nacimiento");

                entity.Property(e => e.IdDocumento).HasColumnName("id_documento");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("razon_social");

                entity.Property(e => e.Ruc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ruc");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("sexo")
                    .IsFixedLength();

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.IdDocumentoNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.IdDocumento)
                    .HasConstraintName("FK_CLIENTE_DOCUMENTO");
            });

            modelBuilder.Entity<Comprobante>(entity =>
            {
                entity.HasKey(e => e.IdComprobante);

                entity.ToTable("COMPROBANTE");

                entity.Property(e => e.IdComprobante).HasColumnName("id_comprobante");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Destino>(entity =>
            {
                entity.HasKey(e => e.IdDestino);

                entity.ToTable("DESTINO");

                entity.Property(e => e.IdDestino).HasColumnName("id_destino");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ciudad");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();
            });

            modelBuilder.Entity<DetalleReserva>(entity =>
            {
                entity.HasKey(e => e.IdDetalleReserva);

                entity.ToTable("DETALLE_RESERVA");

                entity.Property(e => e.IdDetalleReserva).HasColumnName("id_detalle_reserva");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();

                entity.Property(e => e.IdAsientoProg).HasColumnName("id_asiento_prog");

                entity.Property(e => e.IdReserva).HasColumnName("id_reserva");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombres");

                entity.Property(e => e.NroDocumento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nro_documento");

                entity.HasOne(d => d.IdAsientoProgNavigation)
                    .WithMany(p => p.DetalleReserva)
                    .HasForeignKey(d => d.IdAsientoProg)
                    .HasConstraintName("FK_DETALLE_RESERVA_ASIENTO_PROGRAMACION");

                entity.HasOne(d => d.IdReservaNavigation)
                    .WithMany(p => p.DetalleReserva)
                    .HasForeignKey(d => d.IdReserva)
                    .HasConstraintName("FK_DETALLE_RESERVA_RESERVA");
            });

            modelBuilder.Entity<Documento>(entity =>
            {
                entity.HasKey(e => e.IdDocumento);

                entity.ToTable("DOCUMENTO");

                entity.Property(e => e.IdDocumento).HasColumnName("id_documento");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca);

                entity.ToTable("MARCA");

                entity.Property(e => e.IdMarca).HasColumnName("id_marca");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.HasKey(e => e.IdModelo);

                entity.ToTable("MODELO");

                entity.Property(e => e.IdModelo).HasColumnName("id_modelo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Nivel>(entity =>
            {
                entity.HasKey(e => e.IdNivel);

                entity.ToTable("NIVEL");

                entity.Property(e => e.IdNivel).HasColumnName("id_nivel");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Origen>(entity =>
            {
                entity.HasKey(e => e.IdOrigen);

                entity.ToTable("ORIGEN");

                entity.Property(e => e.IdOrigen).HasColumnName("id_origen");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ciudad");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();
            });

            modelBuilder.Entity<PagosPaypal>(entity =>
            {
                entity.HasKey(e => e.IdPago);

                entity.ToTable("PAGOS_PAYPAL");

                entity.Property(e => e.IdPago).HasColumnName("id_pago");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Dni)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("dni");

                entity.Property(e => e.DocumentoReferencia)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("documento_referencia");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();

                entity.Property(e => e.FechaPago)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_pago");

                entity.Property(e => e.Importe)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("importe");

                entity.Property(e => e.Moneda)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("moneda");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombres");

                entity.Property(e => e.NumeroItems).HasColumnName("numero_items");

                entity.Property(e => e.TxnId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("txn_id");
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.HasKey(e => e.IdPersonal);

                entity.ToTable("PERSONAL");

                entity.Property(e => e.IdPersonal).HasColumnName("id_personal");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Dni)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("dni");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();

                entity.Property(e => e.IdCargo).HasColumnName("id_cargo");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombres");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.IdCargoNavigation)
                    .WithMany(p => p.Personal)
                    .HasForeignKey(d => d.IdCargo)
                    .HasConstraintName("FK_PERSONAL_CARGO");
            });

            modelBuilder.Entity<Precio>(entity =>
            {
                entity.HasKey(e => e.IdPrecio)
                    .HasName("PK_precio");

                entity.ToTable("PRECIO");

                entity.Property(e => e.IdPrecio).HasColumnName("id_precio");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdDestino).HasColumnName("id_destino");

                entity.Property(e => e.IdOrigen).HasColumnName("id_origen");

                entity.Property(e => e.Precio1)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("precio");

                entity.HasOne(d => d.IdDestinoNavigation)
                    .WithMany(p => p.Precio)
                    .HasForeignKey(d => d.IdDestino)
                    .HasConstraintName("FK_PRECIO_DESTINO");

                entity.HasOne(d => d.IdOrigenNavigation)
                    .WithMany(p => p.Precio)
                    .HasForeignKey(d => d.IdOrigen)
                    .HasConstraintName("FK_PRECIO_ORIGEN");
            });

            modelBuilder.Entity<Programacion>(entity =>
            {
                entity.HasKey(e => e.IdProgramacion);

                entity.ToTable("PROGRAMACION");

                entity.Property(e => e.IdProgramacion).HasColumnName("id_programacion");

                entity.Property(e => e.Costo)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("costo");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Hora).HasColumnName("hora");

                entity.Property(e => e.IdBus).HasColumnName("id_bus");

                entity.Property(e => e.IdDestino).HasColumnName("id_destino");

                entity.Property(e => e.IdOrigen).HasColumnName("id_origen");

                entity.HasOne(d => d.IdBusNavigation)
                    .WithMany(p => p.Programacion)
                    .HasForeignKey(d => d.IdBus)
                    .HasConstraintName("FK_PROGRAMACION_BUS");

                entity.HasOne(d => d.IdDestinoNavigation)
                    .WithMany(p => p.Programacion)
                    .HasForeignKey(d => d.IdDestino)
                    .HasConstraintName("FK_PROGRAMACION_DESTINO");

                entity.HasOne(d => d.IdOrigenNavigation)
                    .WithMany(p => p.Programacion)
                    .HasForeignKey(d => d.IdOrigen)
                    .HasConstraintName("FK_PROGRAMACION_ORIGEN");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.IdReserva);

                entity.ToTable("RESERVA");

                entity.Property(e => e.IdReserva).HasColumnName("id_reserva");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();

                entity.Property(e => e.FechaReserva)
                    .HasColumnType("date")
                    .HasColumnName("fecha_reserva");

                entity.Property(e => e.HoraReserva).HasColumnName("hora_reserva");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.NroReserva)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nro_reserva");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_RESERVA_CLIENTE");
            });

            modelBuilder.Entity<Tripulacion>(entity =>
            {
                entity.HasKey(e => e.IdTripulacion);

                entity.ToTable("TRIPULACION");

                entity.Property(e => e.IdTripulacion).HasColumnName("id_tripulacion");

                entity.Property(e => e.IdPersonal).HasColumnName("id_personal");

                entity.Property(e => e.IdProgramacion).HasColumnName("id_programacion");

                entity.HasOne(d => d.IdPersonalNavigation)
                    .WithMany(p => p.Tripulacion)
                    .HasForeignKey(d => d.IdPersonal)
                    .HasConstraintName("FK_TRIPULACION_PERSONAL");

                entity.HasOne(d => d.IdProgramacionNavigation)
                    .WithMany(p => p.Tripulacion)
                    .HasForeignKey(d => d.IdProgramacion)
                    .HasConstraintName("FK_TRIPULACION_PROGRAMACION");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("USUARIO");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Clave)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("clave");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdPersonal).HasColumnName("id_personal");

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuario");

                entity.HasOne(d => d.Personal)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdPersonal)
                    .HasConstraintName("FK_USUARIO_PERSONAL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

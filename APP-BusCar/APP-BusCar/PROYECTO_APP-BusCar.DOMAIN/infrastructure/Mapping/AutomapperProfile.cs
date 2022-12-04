using AutoMapper;
using PROYECTO_APP_BusCar.DOMAIN.Core.DTOs;
using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PROYECTO_APP_BusCar.DOMAIN.infrastructure.Mapping
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Cliente, ClienteDTO>();
            CreateMap<ClienteDTO, Cliente>();
            CreateMap<ClienteCreateDTO, Cliente>();
            CreateMap<Cliente, ClienteCreateDTO>();

            CreateMap<Comprobante, ComprobanteDTO>();
            CreateMap<ComprobanteDTO, Comprobante>();
            CreateMap<ComprobanteCreateDTO, Comprobante>();
            CreateMap<Comprobante, ComprobanteCreateDTO>();

            CreateMap<Destino, DestinoDTO>();
            CreateMap<DestinoDTO, Destino>();
            CreateMap<DestinoCreateDTO, Destino>();
            CreateMap<Destino, DestinoCreateDTO>();

            CreateMap<DetalleReserva, DetalleReservaDTO>();
            CreateMap<DetalleReservaDTO, DetalleReserva>();
            CreateMap<DetalleReservaCreateDTO, DetalleReserva>();
            CreateMap<DetalleReserva, DetalleReservaCreateDTO>();

            CreateMap<Personal, PersonalCreateDTO>();
            CreateMap<PersonalCreateDTO, Personal>();

            CreateMap<Personal, PersonalDTO>();
            CreateMap<PersonalDTO, Personal>();

            CreateMap<Usuario, UsuarioCreateDTO>();
            CreateMap<UsuarioCreateDTO, Usuario>();

            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<UsuarioDTO, Usuario>();

            CreateMap<Usuario, UsuarioPersonalDTO>();
            CreateMap<UsuarioPersonalDTO,Usuario>();

            CreateMap<Usuario, UsersAuthenticationDTO>();
            CreateMap<UsersAuthenticationDTO, Usuario>();

            CreateMap<Usuario, UsersLoginResponseDTO>();
            CreateMap<UsersLoginResponseDTO, Usuario>();

            CreateMap<Origen, OrigenDTO>();
            CreateMap<OrigenDTO, Origen>();
            CreateMap<OrigenCreateDTO, Origen>();
            CreateMap<Origen, OrigenCreateDTO>();

            CreateMap<Asiento, AsientoDTO>();
            CreateMap<AsientoDTO, Asiento>();

            CreateMap<Asiento, AsientoCreateDTO>();
            CreateMap<AsientoCreateDTO, Asiento>();

            CreateMap<AsientoProgramacion, AsientoProgramacionDTO>();
            CreateMap<AsientoProgramacionDTO, AsientoProgramacion>();

            CreateMap<AsientoProgramacion, AsientoProgramacionCreateDTO>();
            CreateMap<AsientoProgramacionCreateDTO, AsientoProgramacion>();

            CreateMap<AsientoProgramacion, AsientoProgramacionAsientoDTO>();
            CreateMap<AsientoProgramacionAsientoDTO, AsientoProgramacion>();

            CreateMap<Documento, DocumentoDTO>();
            CreateMap<DocumentoDTO, Documento>();
            CreateMap<Documento,DocumentoCreateDTO>();
            CreateMap<DocumentoCreateDTO,Documento>();

            CreateMap<Bus, BusDTO>();
            CreateMap<BusDTO, Bus>();
            CreateMap<Bus, BusCreateDTO>();
            CreateMap<BusCreateDTO, Bus>();





        }

    }
}
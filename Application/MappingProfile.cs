using AutoMapper;
using PruebaTecnicaLAFISE.Application.Clientes.Command;
using PruebaTecnicaLAFISE.Application.CuentasBancarias.Command;
using PruebaTecnicaLAFISE.Domain.Entity;

namespace PruebaTecnicaLAFISE.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CrearClienteCommand, Cliente>();
            CreateMap<CrearCuentaBancariaCommand, CuentaBancaria>()
                .ForMember(dest => dest.Saldo, opt => opt.MapFrom(src => src.SaldoInicial));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Lab2.Models;
using Lab2.ViewModel;

namespace Lab2
{
    public class PokojProfile : Profile
    {
        public PokojProfile()
        {
            CreateMap<Pokoj, PokojViewModel>()
                .ForMember(dest => dest.vmId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.vmNazwa, opt => opt.MapFrom(src => src.Nazwa))
                .ForMember(dest => dest.vmOpis, opt => opt.MapFrom(src => src.Opis))
                .ForMember(dest => dest.vmHostel, opt => opt.MapFrom(src => src.Hostel))
                .ForMember(dest => dest.vmCenaZaNocleg, opt => opt.MapFrom(src => src.CenaZaNocleg))
                .ForMember(dest => dest.vmIloscLozek, opt => opt.MapFrom(src => src.IloscLozek))
                .ForMember(dest => dest.vmRodzajPokoju, opt => opt.MapFrom(src => src.RodzajPokoju));

            CreateMap<PokojViewModel, Pokoj>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.vmId))
                .ForMember(dest => dest.Nazwa, opt => opt.MapFrom(src => src.vmNazwa))
                .ForMember(dest => dest.Opis, opt => opt.MapFrom(src => src.vmOpis))
                .ForMember(dest => dest.Hostel, opt => opt.MapFrom(src => src.vmHostel))
                .ForMember(dest => dest.CenaZaNocleg, opt => opt.MapFrom(src => src.vmCenaZaNocleg))
                .ForMember(dest => dest.IloscLozek, opt => opt.MapFrom(src => src.vmIloscLozek))
                .ForMember(dest => dest.RodzajPokoju, opt => opt.MapFrom(src => src.vmRodzajPokoju));

            CreateMap<Pokoj, CreateViewModel>()
                .ForMember(dest => dest.vmcId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.vmcNazwa, opt => opt.MapFrom(src => src.Nazwa))
                .ForMember(dest => dest.vmcOpis, opt => opt.MapFrom(src => src.Opis))
                .ForMember(dest => dest.vmcHostel, opt => opt.MapFrom(src => src.Hostel))
                .ForMember(dest => dest.vmcCenaZaNocleg, opt => opt.MapFrom(src => src.CenaZaNocleg))
                .ForMember(dest => dest.vmcIloscLozek, opt => opt.MapFrom(src => src.IloscLozek))
                .ForMember(dest => dest.vmcRodzajPokoju, opt => opt.MapFrom(src => src.RodzajPokoju));

            CreateMap<CreateViewModel, Pokoj>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.vmcId))
                .ForMember(dest => dest.Nazwa, opt => opt.MapFrom(src => src.vmcNazwa))
                .ForMember(dest => dest.Opis, opt => opt.MapFrom(src => src.vmcOpis))
                .ForMember(dest => dest.Hostel, opt => opt.MapFrom(src => src.vmcHostel))
                .ForMember(dest => dest.CenaZaNocleg, opt => opt.MapFrom(src => src.vmcCenaZaNocleg))
                .ForMember(dest => dest.IloscLozek, opt => opt.MapFrom(src => src.vmcIloscLozek))
                .ForMember(dest => dest.RodzajPokoju, opt => opt.MapFrom(src => src.vmcRodzajPokoju));

            CreateMap<Pokoj, EditViewModel>()
                .ForMember(dest => dest.vmeId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.vmeNazwa, opt => opt.MapFrom(src => src.Nazwa))
                .ForMember(dest => dest.vmeOpis, opt => opt.MapFrom(src => src.Opis))
                .ForMember(dest => dest.vmeHostel, opt => opt.MapFrom(src => src.Hostel))
                .ForMember(dest => dest.vmeCenaZaNocleg, opt => opt.MapFrom(src => src.CenaZaNocleg))
                .ForMember(dest => dest.vmeIloscLozek, opt => opt.MapFrom(src => src.IloscLozek))
                .ForMember(dest => dest.vmeRodzajPokoju, opt => opt.MapFrom(src => src.RodzajPokoju));

            CreateMap<EditViewModel, Pokoj>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.vmeId))
                .ForMember(dest => dest.Nazwa, opt => opt.MapFrom(src => src.vmeNazwa))
                .ForMember(dest => dest.Opis, opt => opt.MapFrom(src => src.vmeOpis))
                .ForMember(dest => dest.Hostel, opt => opt.MapFrom(src => src.vmeHostel))
                .ForMember(dest => dest.CenaZaNocleg, opt => opt.MapFrom(src => src.vmeCenaZaNocleg))
                .ForMember(dest => dest.IloscLozek, opt => opt.MapFrom(src => src.vmeIloscLozek))
                .ForMember(dest => dest.RodzajPokoju, opt => opt.MapFrom(src => src.vmeRodzajPokoju));
        }
    }
}
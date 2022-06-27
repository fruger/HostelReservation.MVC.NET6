using Lab2.Models;
using Lab2.ViewModel;
using AutoMapper;

namespace Lab2
{
    public class HostelProfile: Profile
    {
        public HostelProfile()
        {
            CreateMap<Hostel, HostelViewModel>();

            CreateMap<HostelViewModel, Hostel>();
        }
    }
}

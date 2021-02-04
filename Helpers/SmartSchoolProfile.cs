using AutoMapper;
using SmartEscola.DTO;
using SmartEscola.Models;

namespace SmartEscola.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoDTO>()
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                
                )
                .ForMember(
                    dest => dest.Idade,
                    opt => opt.MapFrom(src => src.DataNascimento.GetCurrentAge())
                );

            CreateMap<AlunoDTO, Aluno>();
            CreateMap<Aluno,AlunoRegisterDTO>().ReverseMap();


            CreateMap<Professor, ProfessorDTO>()
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                );

            CreateMap<ProfessorDTO, Professor>();
            CreateMap<Professor, ProfessorRegisterDTO>().ReverseMap();
        }
    }
}

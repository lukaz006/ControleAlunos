using AutoMapper;
using ControleAlunos.Api.Context;
using ControleAlunos.Api.Entities;
using ControleAlunos.Models.DTOs;

namespace ControleAlunos.Api.Profiles;

public class AlunosProfile : Profile
{
    public AlunosProfile()
    {
        CreateMap<CadastrarAlunoDto, Alunos>();
        CreateMap<UpdateAlunoDto, Alunos>();
        CreateMap<Alunos, UpdateAlunoDto>();
        CreateMap<Alunos, ReadTurmaDto>();
        CreateMap<Alunos, ReadAlunoDto>()
            .ForMember(alunoDto => alunoDto.Turma,
            opt => opt.MapFrom(aluno => aluno.Turma.NomeDaTurma));
    }
}

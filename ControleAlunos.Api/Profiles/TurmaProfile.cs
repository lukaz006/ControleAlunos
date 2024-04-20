using AutoMapper;
using ControleAlunos.Api.Context;
using ControleAlunos.Api.Entities;
using ControleAlunos.Models.DTOs;

namespace ControleAlunos.Api.Profiles;

public class TurmaProfile : Profile
{
    public TurmaProfile()
    {
        CreateMap<CadastrarTurmaDto, Turma>();
        CreateMap<Turma, ReadTurmaDto>()
            .ForMember(turmaDto => turmaDto.Alunos,
            opt => opt.MapFrom(turmas => turmas.ObterNomesAlunos()));
        CreateMap<UpdateTurmaDto, Turma>();
        CreateMap<Turma, UpdateTurmaDto>();
    }
}

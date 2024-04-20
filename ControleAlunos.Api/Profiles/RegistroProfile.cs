using AutoMapper;
using ControleAlunos.Api.Context;
using ControleAlunos.Api.Entities;
using ControleAlunos.Models.DTOs;

namespace ControleAlunos.Api.Profiles;

public class RegistroProfile : Profile
{
    public RegistroProfile()
    {
        CreateMap<CadastrarRegistroDto, Registro>();
        CreateMap<UpdateRegistroDto, Registro>();
        CreateMap<Registro, UpdateRegistroDto>();
        CreateMap<Registro, ReadRegistroDto>();
    }
}

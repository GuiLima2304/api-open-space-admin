using AutoMapper;

namespace Estagio.OpenSpaceAdmin.Profiles
{

  public class AutoMapperProfile : Profile 
  {
    public AutoMapperProfile()
    {
      CreateMap<Models.Arquivo,ViewModels.ArquivoModel>().ReverseMap();
      CreateMap<Models.Usuario,ViewModels.UsuarioModel>().ReverseMap();
      CreateMap<Models.Apresentacao, ViewModels.ApresentacaoModel>().ReverseMap();
    }
  }
}
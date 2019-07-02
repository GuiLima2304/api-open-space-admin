using System;

namespace Estagio.OpenSpaceAdmin.ViewModels
{
  public class AprovacaoViewModel
  {
    public bool Aprovado { get; set; }
    public DateTime Data { get; set; }
    public string MotivoReprovacao {get;set;}
  }
}
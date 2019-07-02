namespace OpenSpaceAdmin.ViewModels.Base
{
    public class GenericResponse<TData> : BaseResponse
    {
      public TData Dado { get; set; }
      public GenericResponse(TData data)
      {
          this.Status = 1;
          this.Mensagem = "Sucesso";
          this.Dado = data;
      }
    }
}
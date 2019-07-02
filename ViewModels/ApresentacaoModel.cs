using System;
using System.Collections.Generic;

namespace Estagio.OpenSpaceAdmin.ViewModels
{
    public partial class ApresentacaoModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public UsuarioModel Usuario { get; set; }
        public bool Aprovado { get; set; }
        public string MotivoReprovacao { get; set; }
        public DateTime? DataApresentacao { get; set; }
    }
}
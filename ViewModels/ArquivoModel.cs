using System;
using System.Collections.Generic;

namespace Estagio.OpenSpaceAdmin.ViewModels
{
    public partial class ArquivoModel
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public ApresentacaoModel ApresentacaoId { get; set; }

    }
}
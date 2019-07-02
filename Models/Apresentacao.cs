﻿using System;
using System.Collections.Generic;

namespace Estagio.OpenSpaceAdmin.Models
{
    public partial class Apresentacao
    {
        public Apresentacao()
        {
            Arquivo = new HashSet<Arquivo>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int UsuarioId { get; set; }
        public bool Aprovado { get; set; }
        public string MotivoReprovacao { get; set; }
        public DateTime? DataApresentacao { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Arquivo> Arquivo { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;

namespace Estagio.OpenSpaceAdmin.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Apresentacao = new HashSet<Apresentacao>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Apresentacao> Apresentacao { get; set; }
    }
}

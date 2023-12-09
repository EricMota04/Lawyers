﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Lawyers.DAL.Entities
{
    [Table("EstadosCasos", Schema ="dbo")]
    public class EstadosCasosModel
    {
        public int Id { get; set; }
        public string? Estado { get; set; }
    }
}

﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Lawyers.BLL.Models
{
    [Table("USUARIOS")]
    public class UsuariosModel
    {
        public int Id { get; set; }
        public string? Usuario { get; set; }
        public string? Contrasena { get; set; }
        public int RolId { get; set; }
    }
}

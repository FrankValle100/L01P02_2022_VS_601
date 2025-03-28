using System.ComponentModel.DataAnnotations;

namespace Vistas_y_Variables_de_Sesión.Models
{
    public class usuarios
    {
        [Key]
        [Display(Name = "ID de Usuario")]
        public int id_usuario { get; set; }

        [Display(Name = "Nombre Completo")]
        [Required(ErrorMessage = "El nombre del usuario NO es opcional!")]
        public string? nombre { get; set; }

        [Display(Name = "Documento de Identidad")]
        public string? documento { get; set; }

        [Display(Name = "Carnet de Identidad")]
        public string? carnet { get; set; }

        [Display(Name = "ID de Carrera")]
        public int? carrera_id { get; set; }

        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "El correo es obligatorio!")]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo válido!")]
        public string? email { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "La contraseña NO puede estar vacía!")]
        [DataType(DataType.Password)]
        public string? contrasenia { get; set; }

        [Display(Name = "Tipo de Usuario")]
        public string? tipo_usuario { get; set; }

        [Display(Name = "Bloqueado")]
        public char? bloqueado { get; set; }

        [Display(Name = "Último Login")]
        [DataType(DataType.DateTime)]
        public DateTime? ultimo_login { get; set; }

        [Display(Name = "Activo")]
        public char? activo { get; set; }
    }
}

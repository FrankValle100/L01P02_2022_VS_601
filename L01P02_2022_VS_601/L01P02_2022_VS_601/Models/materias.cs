using System.ComponentModel.DataAnnotations;

namespace L01P02_2022_VS_601.Models
{
    public class materias
    {
        [Key]
        public int id { get; set; }
        public string? materia { get; set; }

        public int unidades_valorativas { get; set; }

        public char estado { get; set; }
    }
}

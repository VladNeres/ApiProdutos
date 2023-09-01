﻿using System.ComponentModel.DataAnnotations;

namespace Domain.ViewlModels
{
    public class Categorias
    {
        public  int ID { get; set; }
        [Required(ErrorMessage = "O Campo nome é obrigatório")]
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime DataAlteracao { get; set; }
    }
}
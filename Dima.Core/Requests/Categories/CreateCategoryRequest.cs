﻿using System.ComponentModel.DataAnnotations;

namespace Dima.Core.Requests.Categories;

public class CreateCategoryRequest : Request
{
    [Required(ErrorMessage = "Titulo invalido")]
    [MaxLength(80, ErrorMessage = "O titulo deve ter no maximo 80 caracteres")]
    public string Title { get; set; } = string.Empty;
    [Required (ErrorMessage = "Descrição invalida")]
    public string Description { get; set; } = string.Empty;
    
}
﻿using Domain.Product;

namespace Application.Categories;

public class ListCategoryResponseDTO
{
    public ICollection<Category> Categories { get; set; }
}

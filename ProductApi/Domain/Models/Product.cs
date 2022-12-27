﻿namespace ProductApi.Domain.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Image { get; set; }
}
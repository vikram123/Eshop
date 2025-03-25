﻿namespace Catlog.Api.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageFile { get; set; }

        public List<string> Category { get; set; }
    }
}

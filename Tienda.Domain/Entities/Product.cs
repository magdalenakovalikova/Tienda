using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public string Size { get; private set; }
    public string Color { get; private set; }

    public Product(string name, decimal price, string size, string color)
    {
        if (price <= 0)
        {
            throw new ArgumentException("Price must be positive");
        }

        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        Size = size;
        Color = color;
    }

    public void Update(string name, decimal price, string size, string color)
    {
        if (price <= 0)
        {
            throw new ArgumentException("Price must be positive");
        }

        Name = name;
        Price = price;
        Size = size;
        Color = color;
    }
}


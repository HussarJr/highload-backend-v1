using System;
using System.Collections.Generic;

namespace highload_backend_v1;

public partial class Product
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public int? Price { get; set; }

    public int? Count { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Cart> Carts { get; } = new List<Cart>();

    public virtual ICollection<OrdersElement> OrdersElements { get; } = new List<OrdersElement>();
}

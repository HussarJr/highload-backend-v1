using System;
using System.Collections.Generic;

namespace highload_backend_v1;

public partial class Cart
{
    public string? Customer { get; set; }

    public string? Products { get; set; }

    public string Id { get; set; } = null!;

    public virtual User? CustomerNavigation { get; set; }

    public virtual Product? ProductsNavigation { get; set; }
}

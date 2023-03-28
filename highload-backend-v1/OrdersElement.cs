using System;
using System.Collections.Generic;

namespace highload_backend_v1;

public partial class OrdersElement
{
    public string? OrderId { get; set; }

    public string? ElementId { get; set; }

    public string Id { get; set; } = null!;

    public virtual Product? Element { get; set; }

    public virtual Order? Order { get; set; }
}

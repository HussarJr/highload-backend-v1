using System;
using System.Collections.Generic;

namespace highload_backend_v1;

public partial class Order
{
    public string Id { get; set; } = null!;

    public string? Customer { get; set; }

    public string? Description { get; set; }

    public virtual User? CustomerNavigation { get; set; }
}

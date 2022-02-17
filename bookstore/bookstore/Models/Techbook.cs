using System;
using System.Collections.Generic;

#nullable disable

namespace bookstore.Models
{
    public partial class Techbook
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? Value { get; set; }
    }
}

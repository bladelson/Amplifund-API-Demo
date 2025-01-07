using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDemo.Database.Models
{
    public class TodoItem
    {
        public int Id { get; set; } = -1; //-1 is sentinel for entity framework
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTimeOffset Created { get; set; } = default;
        public DateTimeOffset Modified { get; set; } = default;
    }
}
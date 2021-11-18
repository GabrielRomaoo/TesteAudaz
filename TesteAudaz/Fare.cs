using System;
using System.Collections.Generic;
using System.Text;

namespace TesteAudaz
{
    public class Fare : IModel
    {
        public Guid Id { get; set; }
        public Guid OperatorId { get; set; }
        public int Status { get; set; }
        public decimal Value { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class CreditCard : IEntity
    {
        public int CreditCardId { get; set; }
        public int CustomerId { get; set; }
        public string NameOnTheCard { get; set; }
        public string CardNumber { get; set; }
        public int CVV { get; set; }
        public string ExpirationDate { get; set; }

    }
}

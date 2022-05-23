using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Carros.Domain.Validacoes
{
    public class DomainExceptionValidacao : Exception
    {
        public DomainExceptionValidacao(string error) : base(error)
        {

        }

        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new DomainExceptionValidacao(error);
        }

    }
}

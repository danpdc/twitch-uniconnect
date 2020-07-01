using System;
using System.Collections.Generic;
using System.Text;

namespace Twtich.Uniconnect.SharedKernel.Interfaces
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T entity);
    }
}

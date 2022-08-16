using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClean.Domain.Models.BaseEntity;
public abstract class TBaseEntity<T>
{
    public T id { get; set; }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace store.Contractors
{
    public interface IDeliveryService
    {
         string UniqueCode { get; }
         string Title { get; }

        Form CreateForm(Order id);

        Form MoveNext(int ordeId, int step,IReadOnlyDictionary<string, string> items );
    }
}

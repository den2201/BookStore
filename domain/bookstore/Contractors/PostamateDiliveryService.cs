using System;
using System.Collections.Generic;
using System.Text;

namespace store.Contractors
{
    public class PostamateDiliveryService : IDeliveryService
    {

        private IReadOnlyDictionary<string, string> cities = new Dictionary<string,string>
        {
            {"1", "Moscow" },
            {"2", "Kazan"}
        };

        private IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>>
              postamates = new Dictionary<string, IReadOnlyDictionary<string, string>>
              {

                  { "1", new Dictionary<string, string>
                  {
                          {"1","Kremlin" },
                          {"2","New Ogorevo" }
                   }
                  },
                  {
                      "2", new Dictionary<string, string>
                      {
                          {"3", "Derbyiski" },
                          {"4", "Azino" }
                      }
                  }
              };


        public string UniqueCode => "Postamate";

        public string Title => "Postamate Deliveri in Kazan";

        public Form CreateForm(Order order)
        {
            return new Form(UniqueCode, order.Id, 1, false, new[]
            {
            new SelectionField("City", "city", "1", cities)
            });
        }

        public Form MoveNext(int orderId, int step, IReadOnlyDictionary<string, string> items)
        {
            if(step == 1)
            {
                if (items["city"] == "1")
                {
                    return new Form(UniqueCode, orderId, 2, false, new Field[]
                    {
                        new HiddenField("City", "city","1"),
                        new SelectionField("Postamate","postamate","1",postamates["1"])
                    });
                }
                else if (items["city"] == "2")
                {
                    return new Form(UniqueCode, orderId, 2, false, new Field[]
                    {
                        new HiddenField("City", "city","2"),
                        new SelectionField("Postamate","postamate","3",postamates["1"])
                    });

                }

            }
            else if(step == 2)
            {
                return new Form(UniqueCode, orderId, 3, true, new Field[]
                   {
                        new HiddenField("City", "city","2"),
                        new SelectionField("Postamate","postamate","3",postamates["1"])
                   });

            }

            throw new InvalidOperationException("invalid parameter");
        }
    }
}

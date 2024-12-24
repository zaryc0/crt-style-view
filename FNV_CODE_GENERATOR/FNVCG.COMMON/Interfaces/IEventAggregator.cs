using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNVCG.COMMON.Interfaces
{
    public interface IEventAggregator
    {
        void Publish<TEvent>(TEvent eventToPublish);

        void Subsribe<TEvent>(ISubscriber<TEvent> subscriber);
    }
}

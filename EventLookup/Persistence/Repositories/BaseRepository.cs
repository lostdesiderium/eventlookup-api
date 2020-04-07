using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EventLookup.Persistence.Context;

namespace EventLookup.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly EventLookupContext _eventLookupContext;

        public BaseRepository(EventLookupContext eventLookupContext)
        {
            _eventLookupContext = eventLookupContext;
        }
    }
}

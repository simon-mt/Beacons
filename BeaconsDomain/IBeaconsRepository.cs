using System;
using System.Collections.Generic;

namespace BeaconsDomain
{
    public interface IBeaconsRepository
    {
        bool Create(Beacon item);

        void DeleteAll();

        public List<Beacon> ReadAll();
    }
}

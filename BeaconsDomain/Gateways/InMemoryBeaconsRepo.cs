using System;
using System.Collections.Generic;

namespace BeaconsDomain
{
    public class InMemoryBeaconsRepository : IBeaconsRepository
    {
        private List<Beacon> _beacons = new List<Beacon>();

        public bool Create(Beacon item)
        {
            if (Exists(item.Name))
            {
                return false;
            }

            _beacons.Add(item);
            return true;
        }

        public void DeleteAll() => _beacons.Clear();

        public List<Beacon> ReadAll() => _beacons;

        private bool Exists(string name) => _beacons.Exists(q => q.Name == name);
    }
}

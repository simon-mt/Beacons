using System;
using System.Collections.Generic;

namespace BeaconsDomain
{
    public class InMemoryBeaconsRepository : IBeaconsRepository
    {
        private List<Beacon> _beacons = new List<Beacon>();

        public bool Create(Beacon item)
        {
            //Usually we create the database and load stuff inside (?)
            //we do it in memory for now

            if (Exists(item.Name))
            {
                return false;
            }

            _beacons.Add(item);
            return true;
        }

        public void DeleteAll() => _beacons.Clear();

        public List<Beacon> ReadAll() => _beacons;

        public List<Beacon> ReadByName(string name) => _beacons.FindAll(q => q.Name.Contains(name));

        public List<Beacon> ReadByActivated(bool activated) => _beacons.FindAll(q => q.Activated == activated);

        private bool Exists(string name) => _beacons.Exists(q => q.Name == name);
    }
}

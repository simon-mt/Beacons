using System;
using System.Collections.Generic;

namespace BeaconsDomain
{
    public class InMemoryBeaconsRepository : IBeaconsRepository
    {
        private List<Beacon> _beacons = new List<Beacon>();

        public bool Create(Beacon item)
        {
            if (Exists(item.Owner))
            {
                return false;
            }

            _beacons.Add(item);
            return true;
        }

        public bool Delete(Guid qualificationId) => _beacons.RemoveAll(q => q.Id == qualificationId) > 0;

        public void DeleteAll() => _beacons.Clear();

        public Beacon Read(Guid qualificationId)
        {
            if (!Exists(qualificationId))
            {
                throw new ArgumentException(nameof(qualificationId));
            }

            return _beacons.Find(q => q.Id == qualificationId);
        }

        public List<Beacon> ReadAll() => _beacons;

        private bool Exists(string owner) => _beacons.Exists(q => q.Owner == owner);
    }
}

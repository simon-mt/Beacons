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



        public InMemoryBeaconsRepository()
        {
            _beacons.Add(new Beacon() {
                Id = 0,
                Name = "Jack",
                Owner = "Pet Karslak",
                Email = "mandriolli7@washington.edu",
                Contact_phone = "590-415-5910",
                Emergency_contact_name = "Marvin Andriolli",
                Emergency_contact_phone = "983-656-3047",
                Emergency_contact_email = "mandriolli7@mozilla.com",
                Activated = true
             });

            _beacons.Add(new Beacon() {
                Id = 1,
                Name = "Dendrophthora domingensis (Spreng.) Eichl.",
                Owner = "Leta Allabarton",
                Email = "rtooley8@slate.com",
                Contact_phone = "568-629-9397",
                Emergency_contact_name = "fdfdfdf Andriolli",
                Emergency_contact_phone = "983-656-3047",
                Emergency_contact_email = "mandriollddddi7@mozilla.com",
                Activated = false
             });
        }
    }
}

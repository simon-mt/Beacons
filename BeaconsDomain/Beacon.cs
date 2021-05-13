using System;

namespace BeaconsDomain
{
    public class Beacon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Email { get; set; }
        public string Contact_phone { get; set; }
        public string Emergency_contact_name { get; set; }
        public string Emergency_contact_phone { get; set; }
        public string Emergency_contact_email { get; set; }
        public bool Activated { get; set; }
    }
}

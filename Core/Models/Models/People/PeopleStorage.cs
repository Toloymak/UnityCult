using System;
using System.Collections.Generic;

namespace Models.Models.People
{
    public class PeopleStorage
    {
        public IDictionary<Guid, PersonModel> People { get; set; }

        public PeopleStorage()
        {
            People = new Dictionary<Guid, PersonModel>();
        }
    }
}
using System;
using System.Collections.Generic;

namespace Models.Models.People
{
    public class PeopleStorage
    {
        public IDictionary<Guid, PeopleModel> People { get; set; }

        public PeopleStorage()
        {
            People = new Dictionary<Guid, PeopleModel>();
        }
    }
}
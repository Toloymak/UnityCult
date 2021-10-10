using System;
using System.Collections.Generic;
using Common.Helpers;
using Models.Models.People;
using Models.Models.Players;

namespace Services.Services
{
    public class PeopleService
    {
        public void ProcedurePeople(PlayerStorageModel playerStorageModel)
        {
            playerStorageModel.PeopleStorage.People.ForEach(ProcedurePerson);
        }

        private void ProcedurePerson(KeyValuePair<Guid, PersonModel> keyValuePair)
                                     // PlayerStorageModel playerStorageModel,
                                     // GameStateModel gameStateModel)
        {
            
        }
    }
}
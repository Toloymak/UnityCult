using System.Collections.Generic;

namespace Models.Models.Villages
{
    public class VillageMapModel
    {
        // first list - rows, inner list = columns
        public IList<IList<VillageCellModel>> Cells { get; set; }
    }
}
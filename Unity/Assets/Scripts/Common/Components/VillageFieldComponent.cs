using System.Collections.Generic;
using System.Linq;
using Business.Enums;
using Common.Models;

namespace Common.Components
{
    public class VillageFieldComponent
    {
        public FieldModel<DistrictCellModel> FieldModel { get; set; }
        
        public IEnumerable<DistrictType> GetExistingTypes()
        {
            return FieldModel
               .GetEnumerable()
               .Select(x => x.Type);
        }
    }
}
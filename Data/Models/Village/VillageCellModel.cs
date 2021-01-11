using System;

namespace Models.Models.Village
{
    public class VillageCellModel : BaseItem
    {
        public Coordinates WorldCoordinates { get; }

        public DistrictInfoModel DistrictInfoModel { get; set; }

        public VillageCellModel(Coordinates worldCoordinates)
        {
            WorldCoordinates = worldCoordinates;
        }

        public override string ToString()
        {
            return $"{WorldCoordinates}";
        }
    }
}
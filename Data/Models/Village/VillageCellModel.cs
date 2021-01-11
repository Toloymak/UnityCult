using System;

namespace Models.Models.Village
{
    public class VillageCellModel : BaseItem
    {
        public DistrictModel DistrictModel { get; set; }

        private (int x, int z) _coordinates;
        private readonly Action<(int x, int z), VillageCellModel> _editCoordinatesAction;

        public VillageCellModel(Action<(int x, int z), VillageCellModel> editCoordinatesAction)
        {
            _editCoordinatesAction = editCoordinatesAction;
        }

        public (int x, int z) Coordinates
        {
            get => _coordinates;
            set
            {
                _coordinates = value;
                _editCoordinatesAction.Invoke(value, this);
            }
        }
    }
}
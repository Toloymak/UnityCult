using Models.Models.Districts;

namespace Models.Models.Villages
{
    public class VillageCellModel
    {
        public (int x, int y) Position { get; set; }
        public DistrictModel District { get; set; }

        public VillageCellModel(int x, int y)
        {
            Position = (x, y);
        }
    }
}
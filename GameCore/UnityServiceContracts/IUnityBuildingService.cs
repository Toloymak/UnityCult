using Business.Enums;
using Models.Models.Village;

namespace Core.UnityServiceContracts
{
    public interface IUnityBuildingService
    {
        void UpdateCellView(VillageCellModel villageCellModel);
        void ShowDistrictForBuilding(DistrictType districtType);
    }
}
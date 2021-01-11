using System;
using Models.Models.Village;

namespace Models.Models
{
    public static class ListItemModelExtensions
    {
        public static ListItemModel ToListItemModel(this DistrictInfoModel districtInfoModel, Action action)
        {
            return new ListItemModel()
            {
                Name = districtInfoModel.Name,
                Description = districtInfoModel.Description,
                Resources = districtInfoModel.Resources,
                ClickAction = action
            };
        }
    }
}
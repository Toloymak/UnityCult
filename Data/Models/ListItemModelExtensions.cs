using System;
using Business.Models.Districts;

namespace Models.Models
{
    public static class ListItemModelExtensions
    {
        public static ListItemModel ToListItemModel(this DistrictModel districtModel, Action action)
        {
            return new ListItemModel()
            {
                Name = districtModel.Name,
                Description = districtModel.Description,
                Resources = districtModel.Resources,
                ClickAction = action
            };
        }
    }
}
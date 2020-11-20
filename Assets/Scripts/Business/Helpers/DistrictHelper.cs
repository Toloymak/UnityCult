using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Business.Enums;
using Business.Extensions;
using Business.Models;
using Common.Models;
using Common.TypeExtensions;

namespace Business.Helpers
{
    public class DistrictHelper
    {
        public Leaf<DistrictModel> GetRootLeafOfBuildingTree()
        {
            var allDistricts = Enum
               .GetValues(typeof(DistrictType))
               .Cast<DistrictType>()
               .Where(x => !x.IsIgnored())
               .Select(x => x.GetModel())
               .Select(x => new Leaf<DistrictModel>() {Object = x})
               .ToList();

            var rootLeaf = new Leaf<DistrictModel>();

            foreach (var district in allDistricts)
            {
                var children = allDistricts.Where(x =>
                                                      x.Object.BuildingType == DistrictBuildingType.Upgrade
                                                   && x.Object.Parent.HasValue
                                                   && x.Object.Parent.Value == district.Object.DistrictType
                                                   || x.Object.BuildingType == DistrictBuildingType.District
                                                   && x.Object.RequiredDistricts.Any(d => d == district.Object
                                                         .DistrictType))
                   .ToList();
                district.Children = children;
            }

            foreach (var district in allDistricts)
            {
                foreach (var child in district.Children)
                {
                    child.Parent = district;
                }
            }
            
            rootLeaf.Children = allDistricts
               .Where(x => !x.Object.RequiredDistricts.Any() && x.Parent == null)
               .ToList();

            return rootLeaf;
        }

        public string GetTestStructure()
        {
            var root = GetRootLeafOfBuildingTree();

            return "\n====="
              + GetString(root, 0, new List<DistrictModel>())
              + "\n=====\n";
        }

        private string GetString(Leaf<DistrictModel> leaf, int deep, IList<DistrictModel> prepared)
        {
            var result = "";
            if (deep != 0)
            {
                result += $"\n{new string('-', deep)} {leaf.Object.Name} ({(int) leaf.Object.DistrictType})";
            };

            foreach (var child in leaf.Children)
            {
                if (prepared.Contains(child.Object))
                    break;

                result += GetString(child, deep + 1, prepared);
                prepared.Add(child.Object);
            }

            return result;
        }

        private Leaf<DistrictModel> Find(Leaf<DistrictModel> leaf, DistrictType type)
        {
            if (leaf.Object.DistrictType == type)
                return leaf;
            
            foreach (var child in leaf.Children)
            {
                var result = Find(child, type);
                if (result != null)
                    return result;
            }

            return null;
        }

        public IList<BuildingActionItem> GetAvailableBuildings(DistrictType districtOnCell,
                                                                IEnumerable<DistrictType> existingBuildings)
        {
            var list = GetList(GetRootLeafOfBuildingTree())
               .Where(x => x.Object != null)
               .ToList();

            var listOfLeaf =
                districtOnCell == DistrictType.None
                    ? list
                       .Where(x => x.Parent?.Object == null)
                    : list
                       .Where(x => x.Parent?.Object != null)
                       .Where(x => x.Object.BuildingType == DistrictBuildingType.Upgrade
                               && x.Parent.Object.DistrictType == districtOnCell
                               || x.Object.BuildingType == DistrictBuildingType.District
                               && existingBuildings.Contains(x.Parent.Object.DistrictType));

            return listOfLeaf.Select(x => new BuildingActionItem()
                {
                    DistrictType = x.Object.DistrictType
                })
               .ToList();
        }

        private List<Leaf<DistrictModel>> GetList(Leaf<DistrictModel> currentLeaf)
        {
            var result = new List<Leaf<DistrictModel>>();
            
            result.Add(currentLeaf);

            foreach (var child in currentLeaf.Children)
            {
                result.AddRange(GetList(child));
            }

            return result;
        }
    }
}
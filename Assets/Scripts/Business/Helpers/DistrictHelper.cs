using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Enums;
using Business.Extensions;
using Business.Models;
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
                district.Children = allDistricts.Where(x =>
                        x.Object.BuildingType == DistrictBuildingType.Upgrade
                     && x.Object.Parent.HasValue
                     && x.Object.Parent.Value == district.Object.DistrictType
                     || x.Object.BuildingType == DistrictBuildingType.District
                     && x.Object.RequiredDistricts.Any(d => d == district.Object.DistrictType))
                   .ToList();
            }

            rootLeaf.Children = allDistricts
               .Where(x => !x.Object.RequiredDistricts.Any() && !x.Object.Parent.HasValue)
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
    }
}
﻿using System.Collections.Generic;
using System.Linq;
using Models.Enums;
using Models.Models.Districts;
using Models.Models.Effects;

namespace Models.Consts
{
    public static class DistrictConsts
    {
        private const string ToDo = "todo";
        
        private static readonly IList<DistrictModel> Headquarters = new List<DistrictModel>()
        {
            new DistrictModel()
            {
                Type = DistrictType.Headquarters1,
                Name = DistrictType.Headquarters1.ToString(),
                Description = ToDo,
                RootDistrict = DistrictType.None,
                RequiredTechnologies = new HashSet<TechnologyType>(),
                Price = new Dictionary<ResourceType, int>()
                {

                },
                Effects = new List<EffectModel>()
                {

                }
            },
            new DistrictModel()
            {
                Type = DistrictType.Headquarters2,
                Name = DistrictType.Headquarters2.ToString(),
                Description = ToDo,
                RootDistrict = DistrictType.Headquarters1,
                RequiredTechnologies = new HashSet<TechnologyType>(),
                Price = new Dictionary<ResourceType, int>()
                {

                },
                Effects = new List<EffectModel>()
                {

                }
            },
            new DistrictModel()
            {
                Type = DistrictType.Headquarters3,
                Name = DistrictType.Headquarters3.ToString(),
                Description = ToDo,
                RootDistrict = DistrictType.Headquarters2,
                RequiredTechnologies = new HashSet<TechnologyType>(),
                Price = new Dictionary<ResourceType, int>()
                {

                },
                Effects = new List<EffectModel>()
                {

                }
            },
            new DistrictModel()
            {
                Type = DistrictType.Headquarters4,
                Name = DistrictType.Headquarters4.ToString(),
                Description = ToDo,
                RootDistrict = DistrictType.Headquarters3,
                RequiredTechnologies = new HashSet<TechnologyType>(),
                Price = new Dictionary<ResourceType, int>()
                {

                },
                Effects = new List<EffectModel>()
                {

                }
            },
            new DistrictModel()
            {
                Type = DistrictType.Headquarters5,
                Name = DistrictType.Headquarters5.ToString(),
                Description = ToDo,
                RootDistrict = DistrictType.Headquarters4,
                RequiredTechnologies = new HashSet<TechnologyType>(),
                Price = new Dictionary<ResourceType, int>()
                {

                },
                Effects = new List<EffectModel>()
                {

                }
            }
        };

        private static readonly IList<DistrictModel> WarriorAcademy = new List<DistrictModel>()
        {
            new DistrictModel()
            {
                Type = DistrictType.WarriorAcademy1,
                Name = DistrictType.WarriorAcademy1.ToString(),
                Description = ToDo,
                RootDistrict = DistrictType.None,
                RequiredTechnologies = new HashSet<TechnologyType>(),
                Price = new Dictionary<ResourceType, int>()
                {

                },
                Effects = new List<EffectModel>()
                {

                },
            },
            new DistrictModel()
            {
                Type = DistrictType.WarriorAcademy2,
                Name = DistrictType.WarriorAcademy2.ToString(),
                Description = ToDo,
                RootDistrict = DistrictType.WarriorAcademy1,
                RequiredTechnologies = new HashSet<TechnologyType>(),
                Price = new Dictionary<ResourceType, int>()
                {

                },
                Effects = new List<EffectModel>()
                {

                },
            },
            new DistrictModel()
            {
                Type = DistrictType.WarriorAcademy3,
                Name = DistrictType.WarriorAcademy3.ToString(),
                Description = ToDo,
                RootDistrict = DistrictType.WarriorAcademy2,
                RequiredTechnologies = new HashSet<TechnologyType>(),
                Price = new Dictionary<ResourceType, int>()
                {

                },
                Effects = new List<EffectModel>()
                {

                },
            }
        };

        private static readonly IList<DistrictModel> Residential = new List<DistrictModel>()
        {
            new DistrictModel()
            {
                Type = DistrictType.ResidentialArea1,
                Name = DistrictType.ResidentialArea1.ToString(),
                Description = ToDo,
                RootDistrict = DistrictType.None,
                RequiredTechnologies = new HashSet<TechnologyType>(),
                Price = new Dictionary<ResourceType, int>()
                {

                },
                Effects = new List<EffectModel>()
                {

                }
            },
            new DistrictModel()
            {
                Type = DistrictType.ResidentialArea2,
                Name = DistrictType.ResidentialArea2.ToString(),
                Description = ToDo,
                RootDistrict = DistrictType.ResidentialArea1,
                RequiredTechnologies = new HashSet<TechnologyType>(),
                Price = new Dictionary<ResourceType, int>()
                {

                },
                Effects = new List<EffectModel>()
                {

                }
            },
            new DistrictModel()
            {
                Type = DistrictType.ResidentialArea3,
                Name = DistrictType.ResidentialArea3.ToString(),
                Description = ToDo,
                RootDistrict = DistrictType.ResidentialArea2,
                RequiredTechnologies = new HashSet<TechnologyType>(),
                Price = new Dictionary<ResourceType, int>()
                {

                },
                Effects = new List<EffectModel>()
                {

                }
            }
        };
        
        public static readonly IList<DistrictModel> AllDistricts =
            Headquarters
               .Concat(WarriorAcademy)
               .Concat(Residential)
               .ToArray();
    }
}
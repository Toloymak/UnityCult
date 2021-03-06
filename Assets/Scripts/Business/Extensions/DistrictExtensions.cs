﻿using System;
using System.Collections.Generic;
using System.Linq;
using Business.Attributes;
using Business.Attributes.District;
using Business.Enums;
using Business.Models;
using Business.Models.Districts;
using Common.TypeExtensions;
using UnityEngine.Timeline;

namespace Business.Extensions
{
    public static class DistrictExtensions
    {
        public static string GetName(this DistrictType districtType)
        {
            var attribute = districtType.GetAttribute<DistrictType, DistrictDescriptionAttribute>();

            return attribute == null 
                ? districtType.ToString() 
                : attribute.Name;
        }
        
        public static string GetDescription(this DistrictType districtType)
        {
            var attribute = districtType.GetAttribute<DistrictType, DistrictDescriptionAttribute>();

            return attribute == null 
                ? string.Empty 
                : attribute.Description;
        }
        
        public static string GetTexturePath(this DistrictType districtType)
        {
            var attribute = districtType.GetAttribute<DistrictType, DistrictDescriptionAttribute>();

            return attribute == null || string.IsNullOrEmpty(attribute.TexturePath)
                ? string.Empty 
                : attribute.TexturePath;
        }
        
        public static int GetMaxCount(this DistrictType districtType)
        {
            var attribute = districtType.GetAttribute<DistrictType, DistrictDescriptionAttribute>();

            return attribute?.MaxCount ?? int.MaxValue;
        }
        
        public static IDictionary<ResourceType, int> GetPrices(this DistrictType districtType)
        {
            var attributes = districtType.GetAttributes<DistrictType, DistrictPriceAttribute>();

            return attributes == null
                ? new Dictionary<ResourceType, int>()
                : attributes.ToDictionary(x => x.ResourceType, x => x.Price);
        }

        public static (DistrictBuildingType buildingType, DistrictType? parent) GetBuildingType(this DistrictType districtType)
        {
            var attribute = districtType.GetAttribute<DistrictType, DistrictBuildingTypeAttribute>();

            return attribute == null
                ? (DistrictBuildingType.District, (DistrictType?) null)
                : (attribute.BuildingType, attribute.Parent);
        }
        
        public static IEnumerable<DistrictType> GetRequiredDistricts(this DistrictType districtType)
        {
            var attribute = districtType.GetAttribute<DistrictType, RequiredDistrictsAttribute>();

            return attribute == null
                ? new DistrictType[]{}
                : attribute.DistrictTypes;
        }
        
        public static IEnumerable<ResearchType> GetRequiredResearches(this DistrictType districtType)
        {
            var attribute = districtType.GetAttribute<DistrictType, RequiredResearchesAttribute>();

            return attribute == null
                ? new ResearchType[]{}
                : attribute.ResearchTypes;
        }

        public static DistrictModel GetModel(this DistrictType districtType, Action clickAction = null)
        {
            var model = new DistrictModel();

            model.DistrictType = districtType;
            model.Name = districtType.GetName();
            model.Description = districtType.GetDescription();
            model.BuildingType = districtType.GetBuildingType().buildingType;
            model.Parent = districtType.GetBuildingType().parent;
            model.Resources = districtType.GetPrices();
            model.RequiredDistricts = districtType.GetRequiredDistricts();
            model.RequiredResearches = districtType.GetRequiredResearches();

            if (clickAction != null)
                model.ClickAction = clickAction;
            
            return model;
        }
    }
}
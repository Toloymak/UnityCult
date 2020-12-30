using System;
using System.Collections.Generic;
using System.Linq;
using Models.Enums;
using Models.Models;

namespace Core.Services.Unit
{
    public interface IUnitPriorityProvider
    {
        IList<(int, PriorityType)> GetPriority(UnitModel unitModel);
    }

    public class UnitPriorityProvider : IUnitPriorityProvider
    {
        public IList<(int, PriorityType)> GetPriority(UnitModel unitModel)
        {
            var allTypes = Enum.GetValues(typeof(PriorityType)).Cast<PriorityType>();

            return allTypes.Select(type => (InvertPriority((int) type), type)).ToList();
        }

        private int InvertPriority(int input) => 100000 - input;
    }
}
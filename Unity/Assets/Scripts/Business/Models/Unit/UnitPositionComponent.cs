using System.Diagnostics.SymbolStore;
using UnityEngine;

namespace Business.Models.Unit
{
    public class UnitPositionComponent
    {
        public (int row, int column) VillagePosition { get; set; }
        public bool IsInVillage { get; set; }
        
        public GameObject GameObject { get; set; }
    }
}
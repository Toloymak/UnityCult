using Business.Enums;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Models
{
    public class DistrictCellModel
    {
        public DistrictType Type { get; set; }
        public string Name { get; set; }
        public GameObject GameObject { get; set; }

        public Image GetLogo => _logo != null ? _logo : (_logo = GameObject.transform.Find("Logo").GetComponent<Image>());
        public Text GetName => _name != null ? _name : (_name = GameObject.transform.Find("Name").GetComponent<Text>());

        private Image _logo;
        private Text _name;
    }
}
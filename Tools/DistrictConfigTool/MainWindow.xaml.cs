using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Business.Enums;
using Business.Models.Districts;
using Newtonsoft.Json;

namespace DistrictConfigTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            JsonText.Text = JsonConvert.SerializeObject(GetConfigExample(), Formatting.Indented);
        }

        private void CalculateButton_OnClick(object sender, RoutedEventArgs e)
        {
            IList<DistrictModel> districtModels;
            try
            {
                var json = JsonText.Text;
                districtModels = JsonConvert.DeserializeObject<IList<DistrictModel>>(json);
                ResultTextBlock.Text = GetTree(districtModels);
            }
            catch (Exception exception)
            {
                ResultTextBlock.Text = exception.ToString();
            }
        }

        private string GetTree(IList<DistrictModel> districtModels, int deep = 0)
        {
            
            if (districtModels == null)
                return "";

            var result = new StringBuilder();

            foreach (var districtModel in districtModels)
            {
                result.Append('-', deep);
                result.Append(' ');
                result.Append(districtModel.Name);

                if (districtModel.Resources.Any())
                {
                    result.Append(" (");
                    result.Append(string.Join("; ", districtModel.Resources.Select(x => $"{x.Key}: {x.Value}")));
                    result.Append(" )");
                }

                result.Append("\n");
                result.Append(GetTree(districtModel.ChildDistricts, deep + 1));
            }

            return result.ToString();
        }

        private List<DistrictModel> GetConfigExample()
        {
            return new List<DistrictModel>()
            {
                new DistrictModel()
                {
                    DistrictType = DistrictType.Alchemy,
                    Resources = new Dictionary<ResourceType, int>()
                    {
                        {ResourceType.Energy, 10000}
                    },
                    RequiredDistricts = new long[] {},
                    RequiredResearches = new long[] {},
                    ChildDistricts = new List<DistrictModel>()
                },
                new DistrictModel()
                {
                    DistrictType = DistrictType.Arena,
                    Resources = new Dictionary<ResourceType, int>()
                    {
                        {ResourceType.Food, 100}
                    },
                    RequiredDistricts = new[] {1L},
                    RequiredResearches = new[] {1L},
                    ChildDistricts = new List<DistrictModel>()
                    {
                        new DistrictModel()
                        {
                            DistrictType = DistrictType.Arena2,
                            Resources = new Dictionary<ResourceType, int>()
                            {
                                {ResourceType.Food, 100}
                            },
                            RequiredDistricts = new[] {1L},
                            RequiredResearches = new[] {1L},
                            ChildDistricts = new List<DistrictModel>()
                            {
                            }
                        },
                    }
                },
            };
        }
    }
}
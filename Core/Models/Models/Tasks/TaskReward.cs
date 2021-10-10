using System.Collections.Generic;
using System.Text;
using Models.Enums;
using Models.Models.People;

namespace Models.Models.Tasks
{
    public class ResourceTaskReward
    {
        public IDictionary<ResourceType, int> Resources { get; set; }
        public IList<PersonModel> People { get; set; }
        
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            foreach (var resource in Resources)
            {
                stringBuilder.Append(resource.Key);
                stringBuilder.Append(':');
                stringBuilder.Append(resource.Value);
                stringBuilder.Append("; ");
            }

            foreach (var person in People)
            {
                stringBuilder.Append(person.Name);
                stringBuilder.Append("; ");
            }

            return stringBuilder.ToString();
        }
    }
}
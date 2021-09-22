using Newtonsoft.Json;

namespace Reportium.model
{
    public class TestExecutionStep
    {
        [JsonProperty]
        private string description;

        public void setDescription(string description)
        {
            this.description = description;
        }
        public string getDescription()
        {
            return description;
        }

    }
}

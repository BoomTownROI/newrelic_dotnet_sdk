using System.Collections.Generic;

namespace NewRelic.Platform.Sdk.config
{
    public class AgentConfiguration
    {
        public List<ConfiguredAgent> Agents;

    }

    public class ConfiguredAgent
    {
        public string Name { get; set; }
        public Dictionary<string, List<string>> Inclusions { get; set; }
        public Dictionary<string, List<string>> Exclusions { get; set; }

    }
     
}

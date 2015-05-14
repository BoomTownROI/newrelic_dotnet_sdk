// Boomtown.Alerting.NewRelic.Platform.Sdk.AgentFactory.cs updated by Tom DeMille @3:32 PM on 05/14/2015  original file creation @1:12 PM on 14/05/2015

#region

using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using NewRelic.Platform.Sdk.config;
using Newtonsoft.Json;

#endregion


namespace NewRelic.Platform.Sdk
{
    /// <summary>
    ///     An abstract utility class provided to easily create Agents from a configuration file
    /// </summary>
    public abstract class AgentFactory
    {
        private const string ConfigurationFilePath = @"config\plugin.json";

        internal List<Agent> CreateAgents()
        {
            if (!File.Exists(ConfigurationFilePath))
            {
                throw new FileNotFoundException(string.Format(CultureInfo.InvariantCulture,
                                                              "Unable to locate plugin configuration file at {0}",
                                                              Path.GetFullPath(ConfigurationFilePath)));
            }

            var ac = JsonConvert.DeserializeObject<AgentConfiguration>(File.ReadAllText(ConfigurationFilePath));

            return ac.Agents.Select(CreateAgentWithConfiguration).ToList();
        }

        /// <summary>
        ///     The AgentFactory will read configuration data from specified JSON file and invoke this method for each
        ///     object configuration containing an IDictionary of the deserialized properties
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        public abstract Agent CreateAgentWithConfiguration(ConfiguredAgent properties);
    }
}
﻿﻿using Newtonsoft.Json;

namespace Reportium.Model
{
    /// <summary>
    /// Project which contains multiple tests
    /// </summary>
    public class Project
    {
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public string Version { get; set; }

        public Project()
        {
        }

        public Project(string name, string version)
        {
            Name = name;
            Version = version;
        }


		override
		public bool Equals(object obj)
		{
			if (this == obj) return true;
			if (obj == null || this.GetType() != obj.GetType()) return false;
			Project project = (Project)obj;
            return Name == project.Name && Version == project.Version;
		}

		override
		public int GetHashCode()
		{
			int result = Name.GetHashCode();
			result = 31 * result +Version.GetHashCode();
			return result;
		}
    }
}

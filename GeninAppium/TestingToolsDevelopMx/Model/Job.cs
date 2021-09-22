using Newtonsoft.Json;

namespace Reportium.Model
{
    public class Job
    {
        [JsonProperty]
        public int Number { get; set; }// build number 
        [JsonProperty]
        public string Name { get; set; } // might be used as branch name
        [JsonProperty]
        public string Branch { get; set; }

        public Job() { }

        public Job(string name, int number)
        {
            Name = name;
            Number = number;
        }


		public Job WithBranch(string branch)
		{
			this.Branch = branch;
			return this;
		}

		override
	    public bool Equals(object obj)
		{
			if (this == obj) return true;
            if (obj == null || this.GetType() != obj.GetType()) return false;
			Job job = (Job)obj;
                return Number == job.Number && Name == job.Name && Branch == job.Branch;
		}

		override
		public int GetHashCode()
		{
			int result = Name.GetHashCode();
			result = 31 * result + Number.GetHashCode();
            result = 31 * result + Branch.GetHashCode();
			return result;
		}


	}
}







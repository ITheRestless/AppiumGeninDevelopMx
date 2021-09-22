﻿﻿using Reportium.model;
using System.Collections.Generic;
using Newtonsoft.Json;
using Reportium.Model;

namespace Reportium.model
{
    /// <summary>
    ///  Denotes a test execution instance
    /// </summary>
    public class TestExecution
    {
        [JsonProperty]
        private string id;
        [JsonProperty]
        private string name;
        [JsonProperty]
        private string owner;
        [JsonProperty]
        private string externalId;
        [JsonProperty]
        private string createdBy;
        [JsonProperty]
        private long createdAt;
        [JsonProperty]
        private string lastUpdatedBy;
        [JsonProperty]
        private long lastUpdatedAt;
        [JsonProperty]
        private long startTime;
        [JsonProperty]
        private long endTime;
        [JsonProperty]
        private long uxDuration;
        //Shouldn't serialize status 
        private TestExecutionStatus status; 
        [JsonProperty]
        private List<DevicePlatform> platforms;
        [JsonProperty]
        private Job job;
        [JsonProperty]
        private List<TestExecutionStep> steps;
        [JsonProperty]
        private List<string> tags;
        [JsonProperty]
        private Project project;

        public TestExecutionStatus getStatus()
        {
            return status;
        }
        public void setStatus(TestExecutionStatus status)
        {
            this.status = status;
        }

        public string getId()
        {
            return id;
        }
        public void setId(string id)
        {
            this.id = id;
        }

        public string getName()
        {
            return name;
        }
        public void setName(string name)
        {
            this.name = name;
        }

        public string getOwner()
        {
            return owner;
        }
        public void setOwner(string owner)
        {
            this.owner = owner;
        }

        public string getExternalId()
        {
            return externalId;
        }
        public void setExternalId(string externalId)
        {
            this.externalId = externalId;
        }

        public string getCreatedBy()
        {
            return createdBy;
        }
        public void setCreatedBy(string createdBy)
        {
            this.createdBy = createdBy;
        }

        public long getCreatedAt()
        {
            return createdAt;
        }
        public void setCreatedAt(long createdAt)
        {
            this.createdAt = createdAt;
        }

        public string getLastUpdatedBy()
        {
            return lastUpdatedBy;
        }
        public void setLastUpdatedBy(string lastUpdatedBy)
        {
            this.lastUpdatedBy = lastUpdatedBy;
        }

        public long getLastUpdatedAt()
        {
            return lastUpdatedAt;
        }
        public void setLastUpdatedAt(long lastUpdatedAt)
        {
            this.lastUpdatedAt = lastUpdatedAt;
        }

        public long getStartTime()
        {
            return startTime;
        }
        public void setStartTime(long startTime)
        {
            this.startTime = startTime;
        }

        public long getEndTime()
        {
            return endTime;
        }
        public void setEndTime(long endTime)
        {
            this.endTime = endTime;
        }

        public long getUxDuration()
        {
            return uxDuration;
        }
        public void setUxDuration(long uxDuration)
        {
            this.uxDuration = uxDuration;
        }

        public List<DevicePlatform> getPlatforms()
        {
            return platforms;
        }
        public void setPlatforms(List<DevicePlatform> platforms)
        {
            this.platforms = platforms;
        }

        public List<TestExecutionStep> getSteps()
        {
            return steps;
        }
        public void setSteps(List<TestExecutionStep> steps)
        {
            this.steps = steps;
        }

        public Job getJob()
        {
            return job;
        }
        public void setJob(Job job)
        {
            this.job = job;
        }

        public List<string> getTags()
        {
            return tags;
        }
        public void setTags(List<string> tags)
        {
            this.tags = tags;
        }

        public Project getProject()
        {
            return project;
        }

        public void setProject(Project project)
        {
            this.project = project;
        }
    }
}

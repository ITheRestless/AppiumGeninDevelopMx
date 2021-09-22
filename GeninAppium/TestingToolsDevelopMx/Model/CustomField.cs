﻿﻿﻿using Newtonsoft.Json;
using Reportium.Model.Util;

namespace Reportium.Model
{
    public class CustomField
    {
		[JsonProperty]
        public string Name { get; set; }
		[JsonProperty]
        public string Value { get; set; }

        public CustomField() { }

        public CustomField(string name, string value)
        {
            Name = name;
            Value = value;
        }


	    override
	    public bool Equals(object obj)
	    {
	        if (this == obj) return true;
	        if (!(obj is CustomField)) return false;

	        CustomField that = (CustomField)obj;

	            if (!this.Name.Equals(that.Name)) return false;
	            return this.Value != null ? this.Value.Equals(that.Value) : that.Value == null;
	    }

	    override
	    public int GetHashCode()
	    {
	        int result = Name.GetHashCode();
	            result = 31 * result + (Value != null ? Value.GetHashCode() : 0);
	        return result;
	    }

	    override
	    public string ToString()
	    {
	        return new ToStringBuilder<CustomField>(this)
	                .Append(x => x.Name)
	                .Append(x => x.Value)
	                .ToString();

	    }
	}
}

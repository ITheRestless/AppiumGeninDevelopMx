﻿﻿using Newtonsoft.Json;

namespace Reportium.model
{
    /// <summary>
    /// Created by michaeld on 22/02/2016.
    /// </summary>
    public class MobileInfo
    {
        /// <summary>
        /// All class members should be serialized
        /// </summary>
        [JsonProperty]
        private string imei;
        [JsonProperty]
        private string imsi;
        [JsonProperty]
        private string manufacturer;
        [JsonProperty]
        private string model;
        [JsonProperty]
        private string phoneNumber;
        [JsonProperty]
        private string distributor;
        [JsonProperty]
        private string description;
        [JsonProperty]
        private string firmware; // SW Version
        [JsonProperty]
        private string Operator;
        [JsonProperty]
        private string operatorCountry;
        [JsonProperty]
        private string email;

        public string getManufacturer()
        {
            return manufacturer;
        }
        public void setManufacturer(string manufacturer)
        {
            this.manufacturer = manufacturer;
        }

        public string getImei()
        {
            return imei;
        }
        public void setImei(string imei)
        {
            this.imei = imei;
        }

        public string getImsi()
        {
            return imsi;
        }
        public void setImsi(string imsi)
        {
            this.imsi = imsi;
        }

        public string getModel()
        {
            return model;
        }
        public void setModel(string model)
        {
            this.model = model;
        }

        public string getPhoneNumber()
        {
            return phoneNumber;
        }
        public void setPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }

        public string getDistributor()
        {
            return distributor;
        }
        public void setDistributor(string distributor)
        {
            this.distributor = distributor;
        }

        public string getDescription()
        {
            return description;
        }
        public void setDescription(string description)
        {
            this.description = description;
        }

        public string getFirmware()
        {
            return firmware;
        }
        public void setFirmware(string firmware)
        {
            this.firmware = firmware;
        }

        public string getOperator()
        {
            return Operator;
        }
        public void setOperator(string Operator)
        {
            this.Operator = Operator;
        }

        public string getOperatorCountry()
        {
            return operatorCountry;
        }
        public void setOperatorCountry(string operatorCountry)
        {
            this.operatorCountry = operatorCountry;
        }

        public string getEmail()
        {
            return email;
        }
        public void setEmail(string email)
        {
            this.email = email;
        }
    }
}
﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reportium.model
{
    /// <summary>
    ///  Created by eitanp on 4/4/16.
    /// </summary>
    internal class Entity
    { 
        private string id;

        public Entity(string id)
        {
            this.id = id;
        }

        public string getId()
        {
            return id;
        }

        public void setId(string id)
        {
            this.id = id;
        }

    }
}

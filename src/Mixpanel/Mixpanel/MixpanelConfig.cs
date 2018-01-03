﻿using System;
#if ASYNC
using System.Threading.Tasks;
#endif

namespace Mixpanel
{
    /// <summary>
    /// Provides properties for configuring custom behaviour of the library. You can use config by setting 
    /// values on MixpanelConfig.Global, or by passing an instance to <see cref="MixpanelClient"/>
    /// constructor (in this case configuration property will be first checked from passed instance, 
    /// and if it's not set, then from MixpanelConfig.Global). 
    /// </summary>
    public class MixpanelConfig
    {
        /// <summary>
        /// Gets or sets user defined JSON serialization function. Takes an object as a parameter and returns 
        /// serialized JSON string.
        /// </summary>
        public Func<object, string> SerializeJsonFn { get; set; }

        /// <summary>
        /// Gets or sets user defined function that will make HTTP POST requests to mixpanel endpoints.
        /// Takes 2 string parameters: url and content. Returns true if call was successful, and false otherwise.
        /// </summary>
        public Func<string, string, string, bool> HttpPostFn { get; set; }

#if ASYNC
        /// <summary>
        /// Gets or sets user defined function that will make async HTTP POST requests to mixpanel endpoints.
        /// Takes 2 string parameters: url and content. Returns true if call was successful, and false otherwise.
        /// </summary>
        public Func<string, string, Task<bool>> AsyncHttpPostFn { get; set; }
#endif

        /// <summary>
        /// Gets ot sets user defined function for retrievenig error logs. Takes 2 parameters: message and exception.
        /// </summary>
        public Action<string, Exception> ErrorLogFn { get; set; }

        /// <summary>
        /// Gets or sets the format for mixpanel properties.
        /// </summary>
        public MixpanelPropertyNameFormat? MixpanelPropertyNameFormat { get; set; }

        /// <summary>
        /// Regulates "ip" query string parameter.
        /// </summary>
        public MixpanelIpAddressHandling? IpAddressHandling { get; set; }

        /// <summary>
        /// A global instance of the config.
        /// </summary>
        public static MixpanelConfig Global { get; private set; }

        static MixpanelConfig()
        {
            Global = new MixpanelConfig();
        }

        /// <summary>
        /// Resets all properties for current instance to it's default values.
        /// </summary>
        public void Reset()
        {
            SerializeJsonFn = null;
            HttpPostFn = null;
#if ASYNC
            AsyncHttpPostFn = null;
#endif
            ErrorLogFn = null;
            MixpanelPropertyNameFormat = null;
            IpAddressHandling = null;
        }
    }
}
﻿using System;
#if ASYNC
using System.Threading.Tasks;
#endif

namespace Mixpanel
{
    internal static class ConfigHelper
    {
        public static Func<object, string> GetSerializeJsonFn(MixpanelConfig config)
        {
            if (config != null && config.SerializeJsonFn != null)
                return config.SerializeJsonFn;

            if (MixpanelConfig.Global.SerializeJsonFn != null)
                return MixpanelConfig.Global.SerializeJsonFn;

            return new DefaultJsonSerializer().Serialize;
        }

        public static Func<string, string, string, bool> GetHttpPostFn(MixpanelConfig config)
        {
            if (config != null && config.HttpPostFn != null)
                return config.HttpPostFn;

            if (MixpanelConfig.Global.HttpPostFn != null)
                return MixpanelConfig.Global.HttpPostFn;

            return new DefaultHttpClient().Post;
        }

#if ASYNC
        public static Func<string, string, Task<bool>> GetAsyncHttpPostFn(MixpanelConfig config)
        {
            if (config != null && config.AsyncHttpPostFn != null)
                return config.AsyncHttpPostFn;

            if (MixpanelConfig.Global.AsyncHttpPostFn != null)
                return MixpanelConfig.Global.AsyncHttpPostFn;

            return new DefaultHttpClient().PostAsync;
        }
#endif
        
        public static Action<string, Exception> GetErrorLogFn(MixpanelConfig config)
        {
            if (config != null && config.ErrorLogFn != null)
                return config.ErrorLogFn;

            if (MixpanelConfig.Global.ErrorLogFn != null)
                return MixpanelConfig.Global.ErrorLogFn;

            return null;
        }


#if !JSON
        public static bool SerializeJsonFnSet(MixpanelConfig config)
        {
            return
                MixpanelConfig.Global.SerializeJsonFn != null ||
                (config != null && config.SerializeJsonFn != null);

        }
#endif

        public static MixpanelPropertyNameFormat GetMixpanelPropertyNameFormat(MixpanelConfig config)
        {
            if (config != null && config.MixpanelPropertyNameFormat != null)
            {
                return config.MixpanelPropertyNameFormat.Value;
            }

            if (MixpanelConfig.Global.MixpanelPropertyNameFormat != null)
            {
                return MixpanelConfig.Global.MixpanelPropertyNameFormat.Value;
            }

            return MixpanelPropertyNameFormat.None;
        }

        public static MixpanelIpAddressHandling GetIpAddressHandling(MixpanelConfig config)
        {
            if (config != null && config.IpAddressHandling != null)
            {
                return config.IpAddressHandling.Value;
            }

            if (MixpanelConfig.Global.IpAddressHandling != null)
            {
                return MixpanelConfig.Global.IpAddressHandling.Value;
            }

            return MixpanelIpAddressHandling.None;
        }
    }
}
using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace cn.antontech.ITHelper.AutoActions
{
    class RegistryHelper
    {

        public static RegistryKey GetOrCreateKey(RegistryKey registryKey, string keyLocation)
        {
            return GetOrCreateKey(registryKey, keyLocation, true);
        }

        public static RegistryKey GetOrCreateKey(RegistryKey registryKey, string keyLocation, bool writable)
        {
            RegistryKey foundRegistryKey = registryKey.OpenSubKey(keyLocation, writable);
            return foundRegistryKey ?? RegistryHelper.CreateKey(registryKey, keyLocation);
        }

        public static RegistryKey GetOrCreateSubKey(RegistryKey registryKey, string keyLocation, string subKeyLocation)
        {
            return GetOrCreateSubKey(registryKey, keyLocation, subKeyLocation, true);
        }

        public static RegistryKey GetOrCreateSubKey(RegistryKey registryKey, string keyLocation, string subKeyLocation, bool writable)
        {
            return GetOrCreateKey(registryKey, string.Format(@"{0}\{1}",keyLocation,subKeyLocation), writable);
        }

        public static RegistryKey CreateKey(RegistryKey registryKey, string keyLocation)
        {
            return registryKey.CreateSubKey(keyLocation);
        }

    }
}

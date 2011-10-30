using System.Collections;
using Bin2Reg.Interfaces;
using Microsoft.Win32;

namespace Bin2Reg.ResourceHandlers {
    internal class RegistryHandler : IResourceHandler {
        private const string RegistryValueName = "Info";

        public bool SaveFile(byte[] file, string registryKey) {
            if (file == null)
                return false;

            return FileToRegistry(file, registryKey);
        }

        public byte[] GetFile(string registryKey) {
            byte[] file = null;

            using (var registry = Registry.CurrentUser) {
                var key = registry.OpenSubKey(registryKey, false);

                if (key != null) {
                    file = (byte[])key.GetValue(RegistryValueName);
                }
            }

            return file;
        }

        private static bool FileToRegistry(IEnumerable file, string registryKey) {
            using (var registry = Registry.CurrentUser) {
                var key = OpenRegistryKey(registry, registryKey);

                if (key != null) {
                    key.SetValue(RegistryValueName, file, RegistryValueKind.Binary);
                    return true;
                }
            }

            return false;
        }

        private static RegistryKey OpenRegistryKey(RegistryKey registry, string registryKey) {
            return registry.OpenSubKey(registryKey, true) ?? registry.CreateSubKey(registryKey);
        }
    }
}
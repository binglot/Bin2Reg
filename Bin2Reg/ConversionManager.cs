using System;
using System.IO;

namespace Bin2Reg {
    internal class ConversionManager {
        private readonly IResourceHandler _fileHandler;
        private readonly IResourceHandler _registryHandler;

        public ConversionManager(IResourceHandler fileHandler, IResourceHandler registryHandler) {
            _fileHandler = fileHandler;
            _registryHandler = registryHandler;
        }

        public string Result { get; set; }

        internal void Run(Action action, string registryKey, string filePath) {
            switch (action) {
                case Action.Store:
                    StoreFileInRegistry(filePath, registryKey);
                    break;
                case Action.Restore:
                    RestoreFileFromRegistry(filePath, registryKey);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("action");
            }
        }

        private void StoreFileInRegistry(string filePath, string registryKey) {
            var file = _fileHandler.GetFile(filePath);
            if (file == null) {
                Result = "Error: Could not find the file.";
                return;
            }
            
            var storedFile = _registryHandler.SaveFile(file, registryKey);
            if (storedFile) {
                Result = String.Format("The file {0} has been stored successfully.", Path.GetFileName(filePath));
            }
            else {
                Result = "Error: Could not save the file.";
            }
        }

        private void RestoreFileFromRegistry(string filePath, string registryKey) {
            if (File.Exists(filePath)) {
                Result = "Error: The file already exists.";
                return;
            }

            var file = _registryHandler.GetFile(registryKey);
            if (file == null) {
                Result = "Error: Could not find the value in the registry.";
                return;
            }

            var restoredFile = _fileHandler.SaveFile(file, filePath);
            if (restoredFile) {
                Result = String.Format("The file {0} has been restored successfully.", Path.GetFileName(filePath));
            }
            else {
                Result = "Error: Could not restore the file.";
            }
        }
    }
}
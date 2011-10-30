using System;
using Bin2Reg.ResourceHandlers;

namespace Bin2Reg {

    enum Action {
        Store,
        Restore
    }

    class Program {
        static void Main(string[] args) {
            var argumentsChecker = new ArgumentsChecker(args);

            if (!argumentsChecker.Run()) {
                Console.WriteLine(argumentsChecker.Error);
                return;
            }

            var action = argumentsChecker.Action;
            var registryKey = argumentsChecker.Key;
            var filePath = argumentsChecker.FilePath;

            var fileHandler = new FileHandler();
            var registryHandler = new RegistryHandler();

            var conversion = new ConversionManager(fileHandler, registryHandler);
            conversion.Run(action, registryKey, filePath);

            Console.WriteLine(conversion.Result);
        }
    }
}

using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Bin2Reg {
    internal class ArgumentsChecker {
        readonly string[] _usage = new[] { "Bin2Reg v1.0 - an application to store binary files in the registry \n",
                                           "Usage: bin2reg.exe [-s, -r] [registry_key] [file_path]", 
                                           " -s / -r\t - the action to take, \"store/restore\"",
                                           " registry_key\t - the registry key in HKCU",
                                           " file_path\t - the path of the file \n",
                                           "Ex: bin2reg.exe -s Software\\HiddenData \"C:\\my files\\test.jpg\" \n" };

        private readonly string[] _arguments;
        public string Error = "";

        public ArgumentsChecker(string[] arguments) {
            _arguments = arguments;
        }

        public Action Action { get; set; }
        public string Key { get; set; }
        public string FilePath { get; set; }


        public bool Run() {
            if (_arguments.Length != 3) {
                PrintUsage();
                return false;
            }

            Action = SetAction(_arguments[0]);
            Key = SetKey(_arguments[1]);
            FilePath = SetFilePath(_arguments[2]);

            if (!String.IsNullOrEmpty(Error)) {
                return false;
            }

            return true;
        }

        private void PrintUsage() {
            foreach (var s in _usage) {
                Console.WriteLine(s);
            }
        }

        private Action SetAction(string s) {
            switch (s) {
                case "-s":
                    return Action.Store;
                case "-r":
                    return Action.Restore;
                default:
                    Error += "Error: The first argument is wrong. \n";
                    return new Action();
            }
        }

        private string SetKey(string s) {
            // The pattern: allow any word character including underscore and the back slash (i.e. '\')
            //              except don't let it start with the back slash.
            //const string pattern = @"^\w[\w\\]*$";
            const string pattern = @"^\w[\w\\]*$";

            //if (Regex.IsMatch(s, pattern)) {
            //    Error += "Error: The second argument is wrong. \n";
            //}

            return s;
        }

        private string SetFilePath(string s) {
            var invalidCharacters = Path.GetInvalidPathChars();
            if (invalidCharacters.Any(s.Contains)) {
                Error += "Error: The third argument is wrong. \n";
            }

            return s;
        }
    }
}
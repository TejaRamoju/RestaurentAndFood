using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurentAndFood
{
    public class Constants
    {
        public string DataFilePath { get; private set; } = @"C:\FilesP\data.csv";
        public string ErrorFilePath { get; private set; } = @"C:\FilesP\errors.json";
    }
}
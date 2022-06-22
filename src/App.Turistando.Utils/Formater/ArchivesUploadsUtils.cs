using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace App.Turistando.Utils.Formater
{
    public static class ArchivesUploadsUtils
    {

        public static string getNewName() => System.Guid.NewGuid().ToString() + ".jpg";

        public static string getBase64String(string base64Image) => new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64Image, "");

    }
}

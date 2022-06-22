using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Turistando.Logic.FileUpload
{
    public interface IFileUpload
    {
        string UploadUserImage(string base64String, string containerName);
    }
}

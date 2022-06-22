using App.Turistando.Utils.Formater;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Turistando.Logic.FileUpload
{
    public class FileUpload : IFileUpload
    {
        string connectionStringFileSystem = Environment.GetEnvironmentVariable("azureFileSistem", EnvironmentVariableTarget.Machine);

        private readonly ILogger<FileUpload> _logger;
        public FileUpload(ILogger<FileUpload> logger)
        {
            _logger = logger;
        }

        public string UploadUserImage(string base64String, string containerName)
        {
            try
            {
                var fileName = ArchivesUploadsUtils.getNewName();

                var data = ArchivesUploadsUtils.getBase64String(base64String);

                byte[] imageBytes = Convert.FromBase64String(data);

                var blobClient = new BlobClient(connectionStringFileSystem, containerName, fileName);

                using (var stream = new MemoryStream(imageBytes))
                {
                    blobClient.Upload(stream);
                }

                return blobClient.Uri.AbsoluteUri;
            }
            catch(Exception e)
            {
                var exceptionMessage = "Falha ao enviar imagem do usuario para o container. [ex]: " + e.InnerException + " [message]:" + e.Message;
                _logger.LogError(exceptionMessage);
                throw new Exception(exceptionMessage);
            }           
        }

    }
}

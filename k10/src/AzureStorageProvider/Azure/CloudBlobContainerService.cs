﻿using System;
using CMS.Core;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzureStorageProvider.Azure
{
    public class CloudBlobContainerService : ICloudBlobContainerService
    {
        private ICloudBlobClient _cloudBlobClient = Service<ICloudBlobClient>.Entry();
        
        public void Create(string path, BlobContainerPublicAccessType? accessType = null)
        {
            if (accessType.HasValue)
                _cloudBlobClient.GetContainerReference(path).Create(accessType.Value);
            else
                _cloudBlobClient.GetContainerReference(path).Create();
        }

        public void DeleteAsync(string path)
        {
            _cloudBlobClient.GetContainerReference(path).DeleteAsync();
        }

        public bool Exists(string path)
        {
            return _cloudBlobClient.GetContainerReference(path).Exists();
        }

        public BlobContainerPublicAccessType? GetPublicAccess(string path)
        {
            return _cloudBlobClient.GetContainerReference(path).Properties.PublicAccess;
        }
    }
}

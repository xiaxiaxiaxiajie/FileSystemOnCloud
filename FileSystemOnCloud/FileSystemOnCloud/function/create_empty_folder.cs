using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aliyun.OSS;
using Aliyun.OSS.Common;

namespace FileSystemOnCloud.function
{
    class create_empty_folder
    {
        static string accessKeyId = config.AccessKeyId;
        static string accessKeySecret = config.AccessKeySecret;
        static string endpoint = config.Endpoint;
        static OssClient client = new OssClient(endpoint, accessKeyId, accessKeySecret);

        public static void CreateEmptyFolder(string bucketName)
        {
            // Note: key treats as a folder and must end with slash.
            const string key = "yourfolder/";
            try
            {
                // put object with zero bytes stream.
                using (MemoryStream memStream = new MemoryStream())
                {
                    client.PutObject(bucketName, key, memStream);
                    Console.WriteLine("Create dir:{0} succeeded", key);
                }
            }
            catch (OssException ex)
            {
                Console.WriteLine("CreateBucket Failed with error info: {0}; Error info: {1}. \nRequestID:{2}\tHostID:{3}",
                    ex.ErrorCode, ex.Message, ex.RequestId, ex.HostId);
            }
        }
    }
}

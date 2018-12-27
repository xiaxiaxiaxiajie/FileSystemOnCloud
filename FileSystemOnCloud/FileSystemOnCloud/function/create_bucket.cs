using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aliyun.OSS;
using Aliyun.OSS.Common;

namespace FileSystemOnCloud.function
{
    class create_bucket
    {
        static string accessKeyId = config.AccessKeyId;
        static string accessKeySecret = config.AccessKeySecret;
        static string endpoint = config.Endpoint;
        static OssClient client = new OssClient(endpoint, accessKeyId, accessKeySecret);

        public static void CreateBucket(string bucketName)
        {
            try
            {
                client.CreateBucket(bucketName);

                Console.WriteLine("Created bucket name:{0} succeeded ", bucketName);
            }
            catch (OssException ex)
            {
                Console.WriteLine("Failed with error info: {0}; Error info: {1}. \nRequestID:{2}\tHostID:{3}",
                                  ex.ErrorCode, ex.Message, ex.RequestId, ex.HostId);
            }
        }
    }
}

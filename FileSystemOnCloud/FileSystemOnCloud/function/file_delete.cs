using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aliyun.OSS;
using Aliyun.OSS.Common;

namespace FileSystemOnCloud.function
{
    class file_delete
    {
        static string accessKeyId = config.AccessKeyId;
        static string accessKeySecret = config.AccessKeySecret;
        static string endpoint = config.Endpoint;
        static OssClient client = new OssClient(endpoint, accessKeyId, accessKeySecret);

        public static void DeleteObject(string bucketName)
        {
            try
            {
                string key = null;
                var listResult = client.ListObjects(bucketName);
                foreach (var summary in listResult.ObjectSummaries)
                {
                    key = summary.Key;
                    break;
                }

                client.DeleteObject(bucketName, key);

                Console.WriteLine("Delete object succeeded");
            }
            catch (OssException ex)
            {
                Console.WriteLine("Failed with error code: {0}; Error info: {1}. \nRequestID:{2}\tHostID:{3}",
                    ex.ErrorCode, ex.Message, ex.RequestId, ex.HostId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed with error info: {0}", ex.Message);
            }
        }

        public static void DeleteObjects(string bucketName)
        {
            try
            {
                var keys = new List<string>();
                var listResult = client.ListObjects(bucketName);
                foreach (var summary in listResult.ObjectSummaries)
                {
                    keys.Add(summary.Key);
                    break;
                }
                var request = new DeleteObjectsRequest(bucketName, keys, false);
                client.DeleteObjects(request);

                Console.WriteLine("Delete objects succeeded");
            }
            catch (OssException ex)
            {
                Console.WriteLine("Failed with error code: {0}; Error info: {1}. \nRequestID:{2}\tHostID:{3}",
                    ex.ErrorCode, ex.Message, ex.RequestId, ex.HostId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed with error info: {0}", ex.Message);
            }
        }
    }
}

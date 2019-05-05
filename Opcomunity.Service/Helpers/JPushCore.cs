using Jiguang.JSMS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Opcomunity.Services.Helpers
{ 
    public class JPushConfig
    {
        public static string AppKey = "a9563e02293ba7483a913591";
        public static string MasterSecret = "e495b1781145f2eee0c02d35";
        public static int TemplateId = 148435;
    }

    public class JPushCore
    {
        public static string SendCode(string phoneNo, int tempplateId)
        {
            JSMSClient client = new JSMSClient(JPushConfig.AppKey, JPushConfig.MasterSecret);
            var resp = client.SendCode(phoneNo, tempplateId);
            return resp.Content;
        }
         
        public static string ValidateCode(string messageId, string code)
        {
            JSMSClient client = new JSMSClient(JPushConfig.AppKey, JPushConfig.MasterSecret);
            var resp = client.IsCodeValid(messageId, code);
            return resp.Content;
        }
    }
}

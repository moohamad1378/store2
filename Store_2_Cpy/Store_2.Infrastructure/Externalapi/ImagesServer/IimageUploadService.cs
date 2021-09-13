using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Infrastructure.Externalapi.ImagesServer
{
    public interface IimageUploadService
    {
        List<string> upload(List<IFormFile> files);
    }
    public class imageUploadService : IimageUploadService
    {
        public imageUploadService()
        {

        }

        public List<string> upload(List<IFormFile> files)
        {
            var client = new RestClient("https://localhost:44333/api/images?apikey=mysecretkey");
            var request = new RestRequest(Method.POST);
            foreach (var item in files)
            {
                byte[] bytes;
                using (var ms=new MemoryStream())
                {
                    item.CopyToAsync(ms);
                    bytes = ms.ToArray();
                }
                request.AddFile(item.FileName, bytes, item.FileName, item.ContentType);
            }
            IRestResponse response = client.Execute(request);
            UploadDto uploadDto = JsonConvert.DeserializeObject<UploadDto>(response.Content);
            return uploadDto.FileNameAddress;
        }
    }
    public class UploadDto
    {
        public bool Statuse { get; set; }
        public List<string> FileNameAddress { get; set; }
    }
}

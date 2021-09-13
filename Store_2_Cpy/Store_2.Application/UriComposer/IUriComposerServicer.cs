using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.ApplicationUriComposer
{
    public interface IUriComposerServicer
    {
        string ComposeIamgeUri(string Src);
    }
    public class UriComposerServicer : IUriComposerServicer
    {

        public string ComposeIamgeUri(string Src)
        {
            return "https://localhost:44333/" + Src.Replace("\\","//");
        }
    }
}

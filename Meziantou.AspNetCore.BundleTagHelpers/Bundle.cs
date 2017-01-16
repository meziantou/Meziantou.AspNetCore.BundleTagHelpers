using System.Collections.Generic;

namespace Meziantou.AspNetCore.BundleTagHelpers
{
    public class Bundle
    {
        public string Name { get; set; }
        public string OutputFileUrl { get; set; }
        public IList<string> InputFileUrls { get; set; }
    }
}

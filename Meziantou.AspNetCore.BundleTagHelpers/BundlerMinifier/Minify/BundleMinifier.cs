using System;
using System.IO;

namespace BundlerMinifier
{
    internal static class BundleMinifier
    {
        public static string GetMinFileName(string file)
        {
            string fileName = Path.GetFileName(file);

            if (fileName.IndexOf(".min.", StringComparison.OrdinalIgnoreCase) > 0)
                return file;

            string ext = Path.GetExtension(file);
            return file.Substring(0, file.LastIndexOf(ext, StringComparison.OrdinalIgnoreCase)) + ".min" + ext;
        }
    }
}

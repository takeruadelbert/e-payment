using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNITapCash.Helper
{
    class ServerHelper
    {
        public void CopyFileToServer(string filename, string sourcePath, string targetPath)
        {
            try
            {
                string sourceFile = Path.Combine(sourcePath, filename);
                string destFile = Path.Combine(targetPath, filename);
                if (!Directory.Exists(targetPath))
                {
                    Directory.CreateDirectory(targetPath);
                }
                File.Copy(sourceFile, destFile, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

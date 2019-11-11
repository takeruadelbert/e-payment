using System;
using System.IO;

namespace BNITapCash.Helper
{
    class ServerHelper
    {
        public static void CopyFileToServer(string filename, string sourcePath, string targetPath)
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

using System.IO;

namespace Client
{
    class FileCopier : IFileCopier
    {
        public void CopyFile(string sourceDirectoryPath, string fileName, string targetDirectoryPath, bool overwriteTargetFile)
        {
            var absoluteSourceFilePath = Path.Combine(sourceDirectoryPath, fileName);
            var absoluteTargetFilePath = Path.Combine(targetDirectoryPath, fileName);

            if (File.Exists(absoluteTargetFilePath) && !overwriteTargetFile) return;

            File.Copy(absoluteSourceFilePath, absoluteTargetFilePath, overwriteTargetFile);
        }
    }
}
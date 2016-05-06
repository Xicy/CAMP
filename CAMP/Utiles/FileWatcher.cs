using System.IO;

namespace CAMP.Utiles
{
    public class FileWatcher
    {
        public delegate void FileChangedEventArgs(string path);

        public event FileChangedEventArgs FileChanged;

        public FileWatcher(string path, string filefilter)
        {
            var watcher = new FileSystemWatcher
            {
                Path = path,
                IncludeSubdirectories = true,
                NotifyFilter = NotifyFilters.LastWrite,
                Filter = filefilter,
                EnableRaisingEvents = true
            };

            watcher.Changed += (sender, args) => { FileChanged?.Invoke(args.FullPath); };
        }
    }
}
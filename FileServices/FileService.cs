using Logger.FileServices;
using Logger.LoggerLogic.Interfaces;

namespace Logger
{
    /// <summary>
    /// Writes logs.
    /// </summary>
    public static class FileService
    {
        public const int QuantityOfLogFiles = 3;
        private static readonly string PathToTheLogs;

        /// <summary>
        /// Initializes static members of the <see cref="FileService"/> class. Creates new folder for logs.
        /// </summary>
        static FileService()
        {
            PathToTheLogs = Path.GetFullPath(Directory.GetCurrentDirectory() + "\\" + ConfigService.GetLogDirectoryName());
            if (!Directory.Exists(PathToTheLogs))
            {
                Directory.CreateDirectory(PathToTheLogs);
            }
        }

        /// <summary>
        /// Writes all data in a file.
        /// </summary>
        /// <param name="data">Data to write.</param>
        /// <exception cref="ArgumentNullException">If data is null - throw.</exception>
        public static void WriteAllInFile(string data)
        {
            if (data == null)
            {
                throw new ArgumentNullException($"{nameof(data)} for {nameof(WriteAllInFile)} method is null");
            }

            File.WriteAllText(GetPathForTheFile(), data);
            Console.WriteLine($"The records were written in file {GetPathForTheFile()}");
        }

        /// <summary>
        /// Deletes files in the log directory untill only <see cref="QuantityOfLogFiles"> newest left.
        /// </summary>.
        public static void DeleteFilesUntilOnlyNewestLeft()
        {
            foreach (var fi in new DirectoryInfo(PathToTheLogs).GetFiles().OrderByDescending(x => x.LastWriteTime).Skip(QuantityOfLogFiles))
            {
                fi.Delete();
            }
        }

        private static string GetPathForTheFile()
        {
            return $"{PathToTheLogs}\\{DateTime.Now.ToString("hh.mm.ss dd.MM.yyyy")}.txt";
        }
    }
}

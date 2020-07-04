using System;
using System.IO;

namespace SingletonPattern
{
    // Class for working with text file
    // Saving changes wors by request Save
    // Before this changes placed in dynamic mamory
    // Realisation of pattern singleton
    public sealed class FileWorker
    {
        // Closed private static field of class, where placed single copy of class
        // Instance initialization is performed lazily - that is,
        // it will only be performed on the first call
        // This construction also guarantees that only 
        // one instance of the class will be created when accessing from multiple threads
        private static readonly Lazy<FileWorker> instance =
            new Lazy<FileWorker>(() => new FileWorker());

        // Open propety for access to instance of singleton class 
        public static FileWorker Instance { get { return instance.Value; } }

        // Path to file
        public string FilePath { get; }
        
        // File contents in the dynamic memory
        public string Text { get; private set; }

        // Creating new instance for work with text
        // To prevent the user class from being created
        public FileWorker()
        {
            FilePath = "test.txt";
            ReadTextFromFile();
        }

        /// Add text to file without saving to permanent memory
        public void WriteText(string text)
        {
            Text += text;
        }

        // Save text to file
        public void Save()
        {
            using (var writer = new StreamWriter(FilePath, false))
            {
                writer.WriteLine(Text);
            }
        }

        /// Read data from file 
        private void ReadTextFromFile()
        {
            if (!File.Exists(FilePath))
            {
                Text = "";
            }
            else
            {
                using (var reader = new StreamReader(FilePath))
                {
                    Text = reader.ReadToEnd();
                }
            }
        }
    }
}

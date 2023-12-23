using csharp_assignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_assignment.Services
{
    

    public class FileService(string filePath) : IFileService
    {
        private readonly string _filePath = filePath;

       
        /// <summary>
        /// Saves the content to the filepath
        /// </summary>
        /// <param name="content">Content to be saved to the filepath</param>
        /// <returns>Returns true if the content was saved to the filepath</returns>
        public bool SaveContentToFile(string content)
        {
            try
            {
                using (var sw = new StreamWriter(_filePath))
                {
                    sw.WriteLine(content);
                }

                return true;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return false;
        }

        /// <summary>
        /// Reads the file in the filepath
        /// </summary>
        /// <returns>Returns the content in the filepath as a string</returns>
        public string GetContentFromFile()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    using var sr = new StreamReader(_filePath);
                    return sr.ReadToEnd();
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;


        }
    }
}

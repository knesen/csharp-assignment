using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_assignment.Interfaces
{
    public interface IFileService
    {
        bool SaveContentToFile(string content);
        string GetContentFromFile();
    }
}

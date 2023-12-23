using csharp_assignment.Interfaces;
using csharp_assignment.Services;

namespace csharp_assignment.test;

public class FileService_Tests
    {
    [Fact]
    public void SaveToFileShould_SaveContentToFile_ThenReturnTrue()
    {
        // Arrange
        IFileService fileService = new FileService(@"C:\Projects\test.txt");
        string content = "Test content";

        // Act
        bool result = fileService.SaveContentToFile(content);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void SaveToFileShould_ReturnFalse_IfFilePathDoesNotExist()
    {
        // Arrange
        IFileService fileService = new FileService($@"C:\Projects\{Guid.NewGuid()}\test.txt");
        string content = "Test content";

        // Act
        bool result = fileService.SaveContentToFile(content);

        // Assert
        Assert.False(result);
    }
}


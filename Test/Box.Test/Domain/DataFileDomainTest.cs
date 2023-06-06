using Box.Domain.Args;
using Box.Domain.Entities;

namespace Box.Test.Doamin;

public class DataFileDoaminTest
{
    private readonly string fileName;
    private readonly DataFile file;

    public DataFileDoaminTest()
    {
        fileName = "temp.jpg";
        file = DataFile.Create(new DataFileArgs(fileName));
    }

    [Fact]
    public void AfterCreateFile_ShouldReturnFile()
    {
        Assert.Equal(fileName, file.Name);
    }

    [Fact]
    public void AfterCreateFile_ShouldHasDownloadUrl()
    {
        Assert.NotEqual(string.Empty, file.Url);
    }

    [Fact]
    public void WhenCreateFileWithEmptyName_ShouldException()
    {
        Assert.Throws<DataFile.InvalidFileNameException>(() =>
            DataFile.Create(new DataFileArgs(string.Empty)));
    }

    [Fact]
    public void WhenFileExtentionIsNotSupported_ShouldException()
    {
        // Act
        var newFile = "temp.mkv";

        // Assert
        Assert.Throws<DataFile.InvalidFileExtentionException>(() =>
            DataFile.Create(new DataFileArgs(newFile)));
    }

    [Fact]
    public void WhenFileIsNotShared_ShouldThrowExceptionOnDownload()
    {
        Assert.Throws<DataFile.NotPublicDownloadableException>(()=> file.Download());
    }

    [Fact]
    public void WhenFileSharedTimeIsPassed_ShouldThrowExceptionOnDownload()
    {
        // Act
        file.Share(DateTime.Now.AddMinutes(-100));

        // Assert
        Assert.Throws<DataFile.NotPublicDownloadableException>(() => file.Download());
    }

    [Fact]
    public void WhenFileRequestedToStopShare_ShouldThrowExceptionOnDownload()
    {
        // Act
        file.StopShare();

        // Assert
        Assert.Throws<DataFile.NotPublicDownloadableException>(() => file.Download());
    }

    [Fact]
    public void WehenFileIsShared_ShouldReturnUrl()
    {
        // Act
        file.Share(DateTime.Now.AddMinutes(100));

        // Assert
        var downloadableFile = file.Download();
        Assert.Equal(downloadableFile, file.Url);
    }

    [Fact]
    public void WhenCreateFileWithInvalidName_ShouldException()
    {
        Assert.Throws<DataFile.InvalidFileNameException>(() =>
            DataFile.Create(new DataFileArgs("temp/.jpg")));
    }

    [Fact]
    public void WhenFileCreated_ShouldTakeExtention()
    {
        Assert.Equal(".jpg", file.Extention);
    }

    [Fact]
    public void WhenFileCreated_ShouldContainsProvier()
    {
        Assert.NotNull(file.Provider);
        Assert.NotNull(file.PhysicalPath);
        Assert.NotEqual(string.Empty, file.PhysicalPath);
    }

    [Fact]
    public void AfterSaveFile_ShouldContainSystemName()
    {
        Assert.NotEmpty(file.SystemName);
    }

    [Fact]
    public void AfterRename_ShouldReturnNewName()
    {
        // Act
        var newName = "NewFile.jpg";
        file.Rename(newName);

        // Assert
        Assert.NotEmpty(file.Name);
        Assert.Equal(newName, file.Name);
    }

    [Fact]
    public void AfterRename_ShouldReturnNewUpdatedDateTime()
    {
        // Act
        string updatedDateTime = file.UpdatedDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
        Thread.Sleep(20);
        var newName = "NewFile.jpg";
        file.Rename(newName);

        // Assert
        Assert.NotEqual(updatedDateTime, file.UpdatedDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
    }

    [Fact]
    public void WhenFileRenamedAndExtentionIsChanged_ShouldException()
    {
        Assert.Throws<DataFile.InvalidFileNameException>(() => file.Rename("temp2.png"));
    }
}

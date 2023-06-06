using Box.Application.Services;
using Box.Contract.Interfaces.Services;
using Box.Data.EntityFramework;
using Box.Data.Repository.EFRepository;
using Box.Data.Repository.Interfaces;
using Box.Domain.Args;
using Box.Domain.Entities;
using Moq;
using Moq.EntityFrameworkCore;

namespace Box.Test.Integration;

public class DataFileIntegrationTest
{
    private readonly string fileName;
    private readonly DataFile file;
    private readonly DataFile[] initialFiles;
    private readonly Mock<ApplicationDbContext> dbContextMock;
    private readonly DataFileService service;
    private readonly DataFileRepository repository;

    public DataFileIntegrationTest()
    {
        dbContextMock = new Mock<ApplicationDbContext>();
        repository = new EFDataFileRepository(dbContextMock.Object);
        service = new BoundedDataFileService(repository);
        initialFiles = new DataFile[]
        {
            DataFile.Create(new DataFileArgs("File1.txt")),
            DataFile.Create(new DataFileArgs("File2.jpg"))
        };
        fileName = "temp.jpg";

        file = DataFile.Create(new DataFileArgs(fileName));
    }

    [Fact]
    public void WhenCallSave_ShouldOnceCallSaveChangeAsyncOnInsert()
    {
        // Arrange
        dbContextMock.Setup(ctx => ctx.DataFile).ReturnsDbSet(initialFiles);

        // Act
        service.Save(file);

        // Assert
        dbContextMock.Verify(t => t.DataFile.Add(It.IsAny<DataFile>()), Times.Once);
    }
}

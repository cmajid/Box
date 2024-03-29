﻿using Box.Application.Services;
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
    private readonly int userId;
    private readonly string username;
    private readonly DataFile[] initialFiles;
    private readonly Mock<ApplicationDbContext> dbContextMock;
    private readonly DataFileService service;
    private readonly DataFileRepository repository;
    private readonly DownloadRepository downloadRepository;

    public DataFileIntegrationTest()
    {
        dbContextMock = new Mock<ApplicationDbContext>();
        repository = new EFDataFileRepository(dbContextMock.Object);
        downloadRepository = new EFDownloadRepository(dbContextMock.Object);
        service = new BoundedDataFileService(repository, downloadRepository);
        fileName = "temp.jpg";
        userId = 1;
        username = "SLUG";
        initialFiles = new DataFile[]
        {
            DataFile.Create(new DataFileArgs{
            Name = "File1.jpg",
            UserId = userId,
            Size = "200",
            Username = username,
            PhysicalPath = "somewhere"
        }),
            DataFile.Create(new DataFileArgs{
            Name = "File2.jpg",
            UserId = userId,
            Size = "200",
            Username = username,
            PhysicalPath = "somewhere"
        })
        };
        file = DataFile.Create(new DataFileArgs
        {
            Name = fileName,
            UserId = userId,
            Size = "200",
            Username = username,
            PhysicalPath = "somewhere"
        });
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

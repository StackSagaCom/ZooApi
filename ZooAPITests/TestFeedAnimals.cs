using Application.DTOs;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;
using ZooApi.Controllers;
using ZooApi.Repository;

namespace ZooAPITests
{
    public class AnimalsControllerTests
    {
        [Fact]
        public void GetAnimalsByType_ReturnsAnimalsByType()
        {
            // Arrange
            var mockRepository = new Mock<IZooRepository>();
            var expectedAnimals = new List<Animal>
            {
                new Carnivore { Id = 1, Name = "Lion" },
                new Carnivore { Id = 2, Name = "Tiger" }
            };
            mockRepository.Setup(repo => repo.GetZoo()).Returns(new Zoo { Animals = expectedAnimals });

            var zooService = new ZooService(mockRepository.Object); // Inject mock repository into ZooService
            var controller = new AnimalsController(zooService);

            // Act
            var actionResult = controller.GetAnimalsByType("Carnivore");
            var okResult = actionResult as OkObjectResult;

            // Assert
            Assert.NotNull(okResult);
            var animals = Assert.IsAssignableFrom<IEnumerable<AnimalDto>>(okResult.Value).ToList();
            Assert.Equal(expectedAnimals.Count, animals.Count);
        }

        [Fact]
        public void GetAllAnimals_ReturnsAllAnimals()
        {
            // Arrange
            var mockRepository = new Mock<IZooRepository>();
            var expectedAnimals = new List<Animal>
            {
                new Carnivore { Id = 1, Name = "Lion" },
                new Herbivore { Id = 2, Name = "Elephant"},
                new Carnivore { Id = 3, Name = "Tiger" }
            };
            mockRepository.Setup(repo => repo.GetZoo()).Returns(new Zoo { Animals = expectedAnimals });

            var zooService = new ZooService(mockRepository.Object); // Inject mock repository into ZooService
            var controller = new AnimalsController(zooService);

            // Act
            var result = controller.GetAnimals();
            var okResult = result as OkObjectResult;

            // Assert
            var animals = Assert.IsAssignableFrom<IEnumerable<AnimalDto>>(okResult.Value).ToList();
            Assert.Equal(expectedAnimals.Count, animals.Count);
        }
    }
}


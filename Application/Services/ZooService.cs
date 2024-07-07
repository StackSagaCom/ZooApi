using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApi.Repository;

namespace Application.Services
{
    public class ZooService
    {
        private readonly IZooRepository _zooRepository;

        public ZooService(IZooRepository zooRepository)
        {
            _zooRepository = zooRepository;
        }

        public List<AnimalDto> GetAnimals()
        {
            var animals = _zooRepository.GetZoo().Animals;
            return animals.Select(a => new AnimalDto { Name = a.Name, Type = a.GetType().Name }).ToList();
        }

        public List<AnimalDto> GetAnimalsByType(string type)
        {
            var animals = _zooRepository.GetZoo().Animals
                .Where(a => a.GetType().Name == type)
                .ToList();
            return animals.Select(a => new AnimalDto { Name = a.Name, Type = a.GetType().Name }).ToList();
        }

    }
}

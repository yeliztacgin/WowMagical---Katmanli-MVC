﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowMagical.Business.Dtos;
using WowMagical.Business.Services;
using WowMagical.Data.Entities;
using WowMagical.Data.Repositories;

namespace WowMagical.Business.Managers
{
    public class ProductManager:IProductService
    {
        private readonly IRepository<ProductEntity> _productRepository;
        public ProductManager(IRepository<ProductEntity> productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(AddProductDto addProductDto)
        {
            var entity = new ProductEntity()
            {
                Name = addProductDto.Name,
                Description = addProductDto.Description,
                UnitPrice = addProductDto.UnitPrice,
                UnitsInStock = addProductDto.UnitsInStock,
                CategoryId = addProductDto.CategoryId,
                ImagePath = addProductDto.ImagePath
            };

            _productRepository.Add(entity);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.Delete(id);
        }

        public UpdateProductDto GetProductById(int id)
        {
            var entity = _productRepository.GetById(id);

            var updateProductDto = new UpdateProductDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                UnitsInStock = entity.UnitsInStock,
                UnitPrice = entity.UnitPrice,
                CategoryId = entity.CategoryId,
                ImagePath = entity.ImagePath
            };

            return updateProductDto;
        }

        public ProductDetailDto GetProductDetailById(int id)
        {
            var productEntity = _productRepository.GetAll(x => x.Id == id);
            var productDetailDto = productEntity.Select(x => new ProductDetailDto()
            {

                Name = x.Name,
                Description = x.Description,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock,
                ImagePath = x.ImagePath,
                CategoryName = x.Category.Name,
                ModifiedDate = x.ModifiedDate,
                CategoryId = x.CategoryId


            }).ToList();
            return productDetailDto[0];

        }

        public List<ListProductDto> GetProducts()
        {
            var productEntities = _productRepository.GetAll().OrderBy(x => x.Category.Name).ThenBy(x => x.Name);
            

            var productDtoList = productEntities.Select(x => new ListProductDto()
            {
                Id = x.Id,
                Name = x.Name,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name,
                ImagePath = x.ImagePath
            }).ToList();

            return productDtoList;
        }

        public List<ListProductDto> GetProductsByCategoryId(int? categoryId)
        {
            if (categoryId.HasValue) 
            {
                var productEntities = _productRepository.GetAll(x => x.CategoryId == categoryId).OrderBy(x => x.Name);

                var productDtos = productEntities.Select(x => new ListProductDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    UnitPrice = x.UnitPrice,
                    UnitsInStock = x.UnitsInStock,
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category.Name,
                    ImagePath = x.ImagePath
                }).ToList();

                return productDtos;

            }
            else
            {
                return GetProducts(); 
            }


        }

        public void UpdateProduct(UpdateProductDto updateProductDto)
        {

            var entity = _productRepository.GetById(updateProductDto.Id);

            entity.Name = updateProductDto.Name;
            entity.Description = updateProductDto.Description;
            entity.UnitPrice = updateProductDto.UnitPrice;
            entity.UnitsInStock = updateProductDto.UnitsInStock;
            entity.CategoryId = updateProductDto.CategoryId;

            if (updateProductDto.ImagePath != "")
                entity.ImagePath = updateProductDto.ImagePath;

            _productRepository.Update(entity);
        }
    }
    }


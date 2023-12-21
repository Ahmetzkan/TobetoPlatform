﻿using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CityManager : ICityService
    {

        ICityDal _cityDal;
        IMapper _mapper;
        CityBusinessRules _cityBusinessRules;

        public CityManager(ICityDal cityDal, IMapper mapper, CityBusinessRules cityBusinessRules)
        {
            _cityDal = cityDal;
            _mapper = mapper;
            _cityBusinessRules = cityBusinessRules;
        }

        public async Task<CreatedCityResponse> AddAsync(CreateCityRequest createCityRequest)
        {
            City City = _mapper.Map<City>(createCityRequest);
            City createdCity = await _cityDal.AddAsync(City);
            CreatedCityResponse createdCityResponse = _mapper.Map<CreatedCityResponse>(createdCity);
            return createdCityResponse;
        }

        public async Task<DeletedCityResponse> DeleteAsync(DeleteCityRequest deleteCityRequest)
        {
            await _cityBusinessRules.IsExistsCity(deleteCityRequest.Id);
            City City = _mapper.Map<City>(deleteCityRequest);
            City deletedCity = await _cityDal.DeleteAsync(City);
            DeletedCityResponse deletedCityResponse = _mapper.Map<DeletedCityResponse>(deletedCity);
            return deletedCityResponse;
        }

        public async Task<IPaginate<GetListCityResponse>> GetListAsync()
        {
            var Cities = await _cityDal.GetListAsync();
            var mappedCities= _mapper.Map<Paginate<GetListCityResponse>>(Cities);
            return mappedCities;
        }

        public async Task<UpdatedCityResponse> UpdateAsync(UpdateCityRequest updateCityRequest)
        {
            await _cityBusinessRules.IsExistsCity(updateCityRequest.Id);
            City City = _mapper.Map<City>(updateCityRequest);
            City updatedCity = await _cityDal.UpdateAsync(City);
            UpdatedCityResponse updatedCityResponse = _mapper.Map<UpdatedCityResponse>(updatedCity);
            return updatedCityResponse;
        }
    }
}
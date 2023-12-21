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
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class LanguageLevelManager : ILanguageLevelService
    {
        ILanguageLevelDal _languageLevelDal;
        IMapper _mapper;
        LanguageLevelBusinessRules _languageLevelBusinessRules;

        public LanguageLevelManager(ILanguageLevelDal languageLevelDal, IMapper mapper, LanguageLevelBusinessRules languageLevelBusinessRules)
        {
            _languageLevelDal = languageLevelDal;
            _mapper = mapper;
            _languageLevelBusinessRules = languageLevelBusinessRules;
        }

        public async Task<CreatedLanguageLevelResponse> AddAsync(CreateLanguageLevelRequest createLanguageLevelRequest)
        {
            LanguageLevel languageLevel = _mapper.Map<LanguageLevel>(createLanguageLevelRequest);
            LanguageLevel addedLanguageLevel = await _languageLevelDal.AddAsync(languageLevel);
            CreatedLanguageLevelResponse responseLanguageLevel = _mapper.Map<CreatedLanguageLevelResponse>(addedLanguageLevel);
            return responseLanguageLevel;

        }
        public async Task<UpdatedLanguageLevelResponse> UpdateAsync(UpdateLanguageLevelRequest updateLanguageLevelRequest)
        {
            await _languageLevelBusinessRules.IsExistsLanguageLevel(updateLanguageLevelRequest.Id);
            LanguageLevel languageLevel = _mapper.Map<LanguageLevel>(updateLanguageLevelRequest);
            LanguageLevel updatedLanguageLevel = await _languageLevelDal.UpdateAsync(languageLevel);
            UpdatedLanguageLevelResponse responseLanguageLevel = _mapper.Map<UpdatedLanguageLevelResponse>(updatedLanguageLevel);
            return responseLanguageLevel;
        }

        public async Task<DeletedLanguageLevelResponse> DeleteAsync(DeleteLanguageLevelRequest deleteLanguageLevelRequest)
        {
            await _languageLevelBusinessRules.IsExistsLanguageLevel(deleteLanguageLevelRequest.Id);
            LanguageLevel languageLevel = _mapper.Map<LanguageLevel>(deleteLanguageLevelRequest);
            LanguageLevel deletedLanguageLevel = await _languageLevelDal.DeleteAsync(languageLevel,true);
            DeletedLanguageLevelResponse responseLanguageLevel = _mapper.Map<DeletedLanguageLevelResponse>(deletedLanguageLevel);
            return responseLanguageLevel;
        }

        public async Task<IPaginate<GetListLanguageLevelResponse>> GetListAsync()
        {
            var LanguageLevelListed = await _languageLevelDal.GetListAsync();
            var mappedListed = _mapper.Map<Paginate<GetListLanguageLevelResponse>>(LanguageLevelListed);
            return mappedListed;
        }    
    }
}
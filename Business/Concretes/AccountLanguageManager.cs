using AutoMapper;
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
    public class AccountLanguageManager : IAccountLanguageService
    {
        IAccountLanguageDal _accountLanguageDal;
        IMapper _mapper;
        AccountLanguageBusinessRules _accountLanguageBusinessRules;
        public AccountLanguageManager(IAccountLanguageDal accountLanguageDal, IMapper mapper, AccountLanguageBusinessRules accountLanguageBusinessRules)
        {
            _accountLanguageDal = accountLanguageDal;
            _mapper = mapper;
            _accountLanguageBusinessRules = accountLanguageBusinessRules;
        }


        public async Task<CreatedAccountLanguageResponse> AddAsync(CreateAccountLanguageRequest createAccountLanguageRequest)
        {
            var AccountLanguage = _mapper.Map<AccountLanguage>(createAccountLanguageRequest);
            var addedAccountLanguage = await _accountLanguageDal.AddAsync(AccountLanguage);
            var responseAccountLanguage = _mapper.Map<CreatedAccountLanguageResponse>(addedAccountLanguage);
            return responseAccountLanguage;
        }

        public async Task<DeletedAccountLanguageResponse> DeleteAsync(DeleteAccountLanguageRequest deleteAccountLanguageRequest)
        {
            await _accountLanguageBusinessRules.IsExistsAccountLanguage(deleteAccountLanguageRequest.Id);
            var AccountLanguage = _mapper.Map<AccountLanguage>(deleteAccountLanguageRequest);
            var deletedAccountLanguage = await _accountLanguageDal.DeleteAsync(AccountLanguage);
            var responseAccountLanguage = _mapper.Map<DeletedAccountLanguageResponse>(deletedAccountLanguage);
            return responseAccountLanguage;
        }

        public async Task<IPaginate<GetListAccountLanguageResponse>> GetListAsync()
        {
            var AccountLanguageListed = await _accountLanguageDal.GetListAsync();
            var mappedListed = _mapper.Map<Paginate<GetListAccountLanguageResponse>>(AccountLanguageListed);
            return mappedListed;
        }

        public async Task<UpdatedAccountLanguageResponse> UpdateAsync(UpdateAccountLanguageRequest updateAccountLanguageRequest)
        {
            await _accountLanguageBusinessRules.IsExistsAccountLanguage(updateAccountLanguageRequest.Id);
            var AccountLanguage = _mapper.Map<AccountLanguage>(updateAccountLanguageRequest);
            var updatedAccountLanguage = await _accountLanguageDal.UpdateAsync(AccountLanguage);
            var responseAccountLanguage = _mapper.Map<UpdatedAccountLanguageResponse>(updatedAccountLanguage);
            return responseAccountLanguage;
        }
    }
}
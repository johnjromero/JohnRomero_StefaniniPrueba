using AutoMapper;
using Backend.Core.Dtos;
using Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Infraestructure.Profiles
{
    public class BankingTransactionProfile : Profile
    {
        public BankingTransactionProfile()
        {
            CreateMap<BankingTransactionCreateDto, BankingTransaction>();
            CreateMap<BankingTransaction, BankingTransactionReadDto>();
        }
    }
}

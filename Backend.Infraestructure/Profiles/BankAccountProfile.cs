using AutoMapper;
using Backend.Core.Dtos;
using Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Infraestructure.Profiles
{
    public class BankAccountProfile : Profile
    {
        public BankAccountProfile()
        {
            CreateMap<BankAccount, BankAccountReadDto>();
        }
    }
}

﻿using DocumentFormat.OpenXml.Wordprocessing;
using InsiscoCore.Base.Data;
using InsiscoCore.Base.Service;
using InsiscoCore.Service;
using Org.BouncyCastle.Asn1.Mozilla;
using PrestaQi.Model;
using PrestaQi.Model.Configurations;
using PrestaQi.Model.Dto.Output;
using PrestaQi.Model.Enum;
using System;
using System.Linq;

namespace PrestaQi.Service.WriteServices
{
    public class CapitalDetailWriteService : WriteService<CapitalDetail>
    {
        IRetrieveService<CapitalDetail> _CapitalDetailRetrieveService;
        IRetrieveRepository<Capital> _CapitalRetrieveRepository;
        IRetrieveService<Investor> _InvestorRetrieveService;
        IWriteRepository<Capital> _CapitalWriteService;

        public CapitalDetailWriteService(
            IWriteRepository<CapitalDetail> repository,
            IRetrieveService<CapitalDetail> capitalDetailRetrieveService,
            IRetrieveRepository<Capital> capitalRetrieveRepository,
            IRetrieveService<Investor> investorRetrieveService,
            IWriteRepository<Capital> capitalWriteService
            ) : base(repository)
        {
            this._CapitalDetailRetrieveService = capitalDetailRetrieveService;
            this._CapitalRetrieveRepository = capitalRetrieveRepository;
            this._InvestorRetrieveService = investorRetrieveService;
            this._CapitalWriteService = capitalWriteService;
        }

        public SetPaymentPeriod Update(CapitalDetail entity)
        {
            SetPaymentPeriod setPaymentPeriod = new SetPaymentPeriod();

            var entityFound = this._CapitalDetailRetrieveService.Find(entity.id);
            var capital = this._CapitalRetrieveRepository.Find(entity.Capital_Id);
            var investor = this._InvestorRetrieveService.Find(capital.investor_id);

            setPaymentPeriod.Mail = investor.Mail;
            setPaymentPeriod.UserId = investor.id;
            setPaymentPeriod.Payment = entity.Payment;
            setPaymentPeriod.Period_Id = entity.id;
            setPaymentPeriod.Capital_Id = entity.Capital_Id;

            if (entityFound == null)
                throw new SystemValidationException("Record not found");

            entity.IsPayment = true;
            entity.updated_at = DateTime.Now;
            entity.created_at = entityFound.created_at;

            setPaymentPeriod.Success = base.Update(entity);

            if (setPaymentPeriod.Success && this._CapitalDetailRetrieveService.Where(p => p.IsPayment == false && p.Capital_Id == entity.Capital_Id).Count() == 0)
            {
                capital.Enabled = false;
                capital.Investment_Status = (int)PrestaQiEnum.InvestmentEnum.Terminada;
                capital.updated_at = DateTime.Now;

                this._CapitalWriteService.Update(capital);

                setPaymentPeriod.PaymentTotal = true;
            }

            return setPaymentPeriod;
        }

        

    }
}

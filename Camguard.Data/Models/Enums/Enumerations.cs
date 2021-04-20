using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Skylight.Models.Enums
{

    public enum UType
    {
        HMO=0,
        PROVIDER=1,
        CLIENT=2,
        MARKETER=3,
        AGENT = 4,
        ENROLLEE=5,
        ROOT =360,
       
    }

    public enum Module
    {
        Company = 1,
        Employee = 2,
        Dependant = 3,
        Provider = 4,
        Policy = 5,
        CompanyPolicy = 6,
        ProviderLevel = 7,
        Capitation = 8,
        ClaimsBatch = 9,
        Claim = 10,
        Authentication=11,
        Authorization=12,
        IdCard=13,
        Error=14,
    }

    public enum LogActivity
    {
        Insert = 1,
        Update = 2,
        Delete = 3,
        View = 4,
    }

    public enum Sex
    {
        Unknown = 0,
        Male = 1,
        Female = 2
    }

    public enum MaritalStat
    {
        Unknown = 0,
        Single = 1,
        Married = 2,
        Divorced = 3
    }
    public enum PType
    {
        All = 0,
        PCP = 1,
        SCP = 2,
        PHM = 3,
    }

    public enum EnrType
    {
        Principal = 1,
        Dependant = 2
    }

    public enum SerType
    {
        Prepaid = 1,
        FFS = 2
    }
    public enum GenType
    {
        Unknown=0,
        AA = 1,
        AS = 2,
        AC = 3,
        SS = 4,
        SC = 5,
        CC = 6
    }
    public enum RelType
    {
        Unknown = 0,
        Spouse = 1,
        Child = 2,
        Mother = 3,
        Father = 4,
        Sibbling = 5,
        Father_Inlaw = 7,
        Mother_Inlaw = 8,
        Employee = 9

    }
    public enum DepType
    {
        Unknown = 0,
        Biological = 1,
        External = 2
    }
    public enum ComType
    {
        Percentage = 0,
        Flat = 1
    }
    public enum EmployeeOption
    {
        All = 0,
        Active = 1,
        Awaiting = 2,
        IDCardReady = 3,
        Inactive = 4,
        PPolicyError=5,
        PProviderError=6,
        DPolicyError=7,
        DProviderError=8

    }
    public enum MUnite
    {
        NA = 0,
        Tablet = 1,
        Syrup = 2,
        Teaspoon = 3,

    }
    public enum MPeriod
    {
        Hourly = 0,
        Daily = 1,
        Weekly = 2,
        Monthly = 3,
        Quarterly = 4,
        Yearly = 5,
    }
    public enum DiagType
    {
        Primary = 0,
        Secondary = 1,
        RuledOut = 2,
    }

    public enum ReqStatus
    {
        Pending = 0, //When the provider has sent the request and it's pending approval
        Accepted = 1,// when the request has been accepted and code has been generated   
        Rejected = 3,// when the request has been rejected
        Processed = 4,// When the code has been processed
        Revoked = 5,// when the generated code has been revoked
        Used=6,//When an Item has been added to the code
    }

    public enum ProcessSource
    {
        Internal = 0,
        External = 1
    }
    public enum RuleType
    {
        General = 0,
        Clinical = 1
    }

    public enum RuleLimitType
    {
      NoLimit=0,
      TimeLimit=1,
      QuantityLimit=2,
      QuanityInTimeLimit=3,
      AgeLimit=3,
      AgeRangeLimit=4,
      Session=5,
      Year=6,
      Month=7,
      Day=8,
      PrincipalOnly=9,
      Emergency=10,
      Amount=11

    }
    public enum LicenseMessage
    {
        RUNNING=0,
        LICENSE_EXPIRED=1,
        SYSTEM_TIME_INCORRECT=2,
        DISPUTE_LOCKDOWN=3,
        CONTRACT_TERMINATION=4
    }

    public enum Status
    {
        Active=0,
        InActive=1,
        
    }


    public enum ServiceStatus
    {
        Successful = 0,
        Failed = 1,
        Suspended = 2
    }



}
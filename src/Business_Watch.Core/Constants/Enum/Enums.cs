using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Watch.Constants.Enum
{
    public enum Sex
    {
        Male = 0,
        Female = 1,
    }

    public enum Category_User
    {
        Staff = 0,
        Customer = 1
    }

    public enum Category_Watch
    {
        Electroic = 0,
        Classic = 1,
        Modern = 2,
        Mechanical = 3
    }

    public enum Category_Human_Watch
    {
        Boy = 0,
        Girl = 1,
        Kids = 2,
        Double = 3,
    }

    public enum Status_Shipper
    {
        IsRent = 0,
        NoContract = 1
    }

    public enum Postage
    {
        Weekly = 0,
        Monthly = 1,
        Quarterly = 2,
        SemiAnnually = 3,
        Annually = 4,
    }

    public enum Category_BankAccount
    {
        PersonalAccount = 0, 
        BossAccount = 1
    }

    public enum Category_Discount
    {
        VIP = 0,
        NewAccount = 1,
    }

    public enum Category_Pay
    {
        Banking = 1,
        Directing = 2,
    }

    public enum Time_Delivery
    {
        TimeInWorks = 1,
        Weekend = 2,
        Evening = 3,
        Night = 4,
        NormalTime = 5,
    }

    public enum Category_Review
    {
        Watch = 0,
        Shipper = 1,
        Trade_Mark = 2,
    }

    //public enum 
}

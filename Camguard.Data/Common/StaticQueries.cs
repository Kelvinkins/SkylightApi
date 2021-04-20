using System;
using System.Collections.Generic;
using System.Text;

namespace Camguard.Data.Common
{
    public class StaticQueries
    {

        public const string SetOnUsToTrue = @"UPDATE AuthNumModels
                    SET          Isonus = 1
                    WHERE(Isonus IS NULL) AND(LEFT(PanNumber, 6) IN('506105', '539923', '519878', '470651', '470652',
                        '427011', '427012', '427013', '470653', '443893', '470654', '470655', '506100', '506145', '519510', '543338'))";


        public const string UpdateMasterSettlement = @"UPDATE AuthNumModels
                    SET          SettlementAccount = '48919400008201'
                    WHERE  (SettlementAccount IS NULL) AND (LEFT(PanNumber, 2) IN ('51', '52', '53', '54', '55', '56', '57', '58', '59'))";

        public const string SetOnUsToFalse = @"UPDATE AuthNumModels
                    SET          Isonus = 0
                    WHERE  (Isonus IS NULL) AND (LEFT(PanNumber, 6) NOT IN ('506105', '539923', '519878', '470651', '470652', '427011', '427012', 
                    '427013', '470653', '443893', '470654', '470655', '506100', '506145', '519510', '543338'))";

        public const string UpdateCardless = @"UPDATE AuthNumModels
                    SET          SettlementAccount = '48919400009701'
                    WHERE  (SettlementAccount IS NULL) AND (LEFT(PanNumber, 1) = '6')"; 
        
        public const string UpdateSettlementVerve = @"UPDATE AuthNumModels
                    SET          SettlementAccount = '48919400001501'
                    WHERE  (SettlementAccount IS NULL) AND (LEFT(PanNumber, 2) = '50')"; 

        public const string UpdateSettlementVisa = @"UPDATE AuthNumModels
                    SET          SettlementAccount = '48919400007201'
                    WHERE  (SettlementAccount IS NULL) AND (LEFT(PanNumber, 1) = '4')";
        public const string UpdateAtmStatus = @"UPDATE AtmModels Set IsConnected=0 Where Cast(getDate()-Date_Updated As TIME) > '02:00:00.0000000'";



    }
}

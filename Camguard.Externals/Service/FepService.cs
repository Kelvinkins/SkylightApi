using Camguard.Externals.IContract;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Camguard.Externals.Service
{
    public class FepService : IFepService
    {

        public string GetFinacleBalance(string terminalid)
        {
            string result = "";

            OracleConnection con;

            try
            {

                con = new OracleConnection();
                //con.ConnectionString = @"Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 172.16.25.69)(PORT = 1821))(CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = FBNFFRDB) (SID = FBNFFRDBDG) (UR = A))); User Id=Camguard;Password=S3cur1ty";
                con.ConnectionString = @"Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 172.16.25.69)(PORT = 1821)) (CONNECT_DATA =(SERVER = DEDICATED) (SERVICE_NAME = FBNFFRDB) (SID = FBNFFRDBDG))); User Id=apprecon; Password=Nigeria124$";
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                con.Open();

                cmd.CommandText = @"select a.AtmSolid, b.AtmBranch, a.EmployeeID, a.TillAcctNo, a.CurBalance, sysdate CurDateTime from(select sol_id AtmSolid, TILL_ACCT_NO TillAcctNo, clr_bal_amt CurBalance, TERM_ID EmployeeID  from custom.Terminal_table a, tbaadm.gam b
                where foracid = TILL_ACCT_NO and a.DEL_FLG= 'N' and a.BANK_ID= '01' and TERM_ID=:EmployeeID order by sol_id, TILL_ACCT_NO)a
                 join
                 (select sol_id AtmSolid, sol_desc AtmBranch from tbaadm.sol where del_flg= 'N' order by sol_id)b on b.AtmSolid=a.AtmSolid";
                cmd.Parameters.Add(new OracleParameter("EmployeeID", terminalid));

                OracleDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

                while (reader.Read())
                {
                    result = reader["CurBalance"].ToString();
                }

            }
            catch (Exception exx)
            {

            }

            return result;
        }

    }
}

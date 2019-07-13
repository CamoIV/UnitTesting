using System;

namespace TestNinja.FundamentalsInterfaces

{
    public interface IStatementGenerator
    {
        string SaveStatement(int housekeeperOid, string housekeeperName, DateTime statementDate);
    }
}
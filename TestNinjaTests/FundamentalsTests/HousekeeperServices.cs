using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.FundamentalsInterfaces;

namespace TestNinjaTests.FundamentalsTests
{
    [TestFixture]
    public class HousekeeperServices
    {
        [Test]
        public void SendStatementEmails_WhenUsed_GenerateStatement()
        {
            Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(uow => uow.Query<Housekeeper>())
                .Returns(new List<Housekeeper>() {
                    new Housekeeper
                    {
                        Email = "a",
                        Oid = 1,
                        FullName = "b",
                        StatementEmailBody = "c"
                    }
                }.AsQueryable);

            Mock<IStatementGenerator> statementGenerator = new Mock<IStatementGenerator>();
            Mock<IEmailSender> emailSender = new Mock<IEmailSender>();
            Mock<IXtraMessageBox> messageBox = new Mock<IXtraMessageBox>();

            HousekeeperService service = new HousekeeperService(
                unitOfWork.Object,
                statementGenerator.Object,
                emailSender.Object,
                messageBox.Object
                );

            service.SendStatementEmails(new DateTime(2019, 07, 04));
            statementGenerator.Verify(sg => sg.SaveStatement(1, "b", new DateTime(2019, 07, 04)));
        }
    }
}

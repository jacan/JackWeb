using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSubstitute;
using System.Data.SqlTypes;

namespace JackWeb.Tests.Fakes
{
    public static class FakeFactory
    {
        public static IPogo CreateFakePogo()
        {
            var date = DateTime.Now;

            var pogoFake = Substitute.For<IPogo>();
            pogoFake.Created.Returns(date);
            pogoFake.Deleted.Returns(date/*SqlDateTime.MinValue*/);
            pogoFake.IsDeleted.Returns(false);
            pogoFake.Id.Returns(1);
            pogoFake.Modified.Returns(date);

            return pogoFake;
        }
    }
}

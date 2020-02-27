using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankAccountApp.Tests
{
    public class SystemDateTimeProviderTests
    {
        [Fact]
        public void FormattedCurrentDate_ReturnsFormattedDate()
        {
            var sut = new FakeDateTimeProvider(new DateTime(2020, 2, 1));

            Assert.Equal("02/01/2020", sut.FormattedCurrentDate);
        }

        private class FakeDateTimeProvider : SystemDateTimeProvider
        {
            private readonly DateTime _currentDateTime;

            public FakeDateTimeProvider(DateTime currentDateTime)
            {
                _currentDateTime = currentDateTime;
            }

            protected override DateTime Today()
            {
                return _currentDateTime;
            }
        }

    }
}

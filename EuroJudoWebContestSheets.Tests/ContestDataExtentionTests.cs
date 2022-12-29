using EuroJudoWebContestSheets.Extentions;
using System.Collections.Generic;
using System.Linq;
using EuroJudoWebContestSheets.Database.Models;
using Xunit;

namespace EuroJudoWebContestSheets.Tests
{
    public class ContestDataExtentionTests
    {
        [Fact]
        public void WhiteWon_WithIppon()
        {
            ContestSheetData data = new ContestSheetData
            {
                IponWhite = 1,
            };

            Assert.True(data.WhiteWon());
        }

        [Fact]
        public void WhiteWon_WithWazaari()
        {
            ContestSheetData data = new ContestSheetData
            {
                WazaariWhite = 1,
            };

            Assert.True(data.WhiteWon());
        }

        [Fact]
        public void WhiteWon_WithWazaariAwasetteIppon()
        {
            ContestSheetData data = new ContestSheetData
            {
                WazaariWhite = 2,
            };

            Assert.True(data.WhiteWon());
        }

        [Fact]
        public void WhiteWon_WithIpponAgainstWazaari()
        {
            ContestSheetData data = new ContestSheetData
            {
                IponWhite = 1,
                WazaariBlue = 1,
            };

            Assert.True(data.WhiteWon());
        }

        [Fact]
        public void BlueWon_WithIppon()
        {
            ContestSheetData data = new ContestSheetData
            {
                IponBlue = 1,
            };

            Assert.False(data.WhiteWon());
        }

        [Fact]
        public void BlueWon_WithWazaari()
        {
            ContestSheetData data = new ContestSheetData
            {
                WazaariBlue = 1,
            };

            Assert.False(data.WhiteWon());
        }

        [Fact]
        public void BlueWon_WithWazaariAwasetteIppon()
        {
            ContestSheetData data = new ContestSheetData
            {
                WazaariBlue = 2,
            };

            Assert.False(data.WhiteWon());
        }

        [Fact]
        public void BlueWon_WithIpponAgainstWazaari()
        {
            ContestSheetData data = new ContestSheetData
            {
                IponBlue = 1,
                WazaariWhite = 1,
            };

            Assert.False(data.WhiteWon());
        }

        [Fact]
        public void CompetitorWinsOnceAsBlue()
        {
            List<ContestSheetData> contests = new List<ContestSheetData>
            {
                new ContestSheetData
                {
                    IponWhite = 1,
                },
                new ContestSheetData
                {
                    IponBlue = 1,
                },
            };

            Assert.Single(contests.Where(c => !c.WhiteWon()));
        }
    }
}

using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.Application.Common.Exceptions;
using WebMVC.Application.Services.Scraper.Commands.Meta;
using WebMVC.Domain.Enums;

namespace Application.IntegrationTests.WebScraper.Commands.Meta
{
    using static Testing;
    public class GetMetaDataTests : TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new GetMetaCommand();
            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public void ShouldRequireText()
        {
            var command = new GetMetaCommand() { Text = "", ScrapeType = ScrapeTypes.Text.Name };
            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public async Task ShouldNotTakeOtherThanLinkOrText()
        {
            var command = new GetMetaCommand() { Text = "something", ScrapeType = "something" };
            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<Exception>();
        }

        [Test]
        public async Task ShouldNotBeAbleToCallInvalidURL()
        {
            var command = new GetMetaCommand() { Text = "ahttps://www.tutorialspoint.com/index.htm", ScrapeType = ScrapeTypes.Link.Name };
            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }
    }
}

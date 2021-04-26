using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.Application.Common.Exceptions;
using WebMVC.Application.Services.Scraper.Commands.Body;
using WebMVC.Domain.Enums;

namespace Application.IntegrationTests.WebScraper.Commands.Body
{
    using static Testing;
    public class GetBodyDataTests : TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new GetBodyCommand();
            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public void ShouldRequireText()
        {
            var command = new GetBodyCommand() { Text = "", ScrapeType = ScrapeTypes.Text.Name };
            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public async Task ShouldNotTakeOtherThanLinkOrText()
        {
            var command = new GetBodyCommand() { Text = "something", ScrapeType = "something" };
            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<Exception>();
        }

        [Test]
        public async Task ShouldNotBeAbleToCallInvalidURL()
        {
            var command = new GetBodyCommand() { Text = "ahttps://www.tutorialspoint.com/index.htm", ScrapeType = ScrapeTypes.Link.Name };
            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }

        
    }

}

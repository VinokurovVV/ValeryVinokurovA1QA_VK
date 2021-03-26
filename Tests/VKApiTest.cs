using Aquality.Selenium.Browsers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using VkApi.Pages;
using VkApi.Utils;

namespace VkApi
{
    [Binding]
    public class Tests
    {
        private readonly Browser browser = AqualityServices.Browser;

        private readonly AuthorizationPage authorizationPage = new AuthorizationPage();
        private readonly NewsPage newsPage = new NewsPage();
        private readonly UserPage userPage = new UserPage();

        private string randomText;

        [Given(@"I am navigated to vk authorization page")]
        public void GivenIAmNavigatedToVkAuthorizationPage()
        {
            browser.Maximize();
            browser.GoTo(JsonReader.GetParameterFromDataFile("url"));
            browser.WaitForPageToLoad();
        }

        [When(@"I am login")]
        public void WhenIAmLogin()
        {
            authorizationPage.Authorization(JsonReader.GetParameterFromDataFile("login"), JsonReader.GetParameterFromDataFile("password"));
        }

        [When(@"I go to user the page")]
        public void WhenIGoToUserThePage()
        {
            newsPage.menuForm.ClickOnMyPageButton();
        }

        [When(@"I am adding a post to the page")]
        public void WhenIAmAddingAPostToThePage()
        {
            randomText = StringUtils.GenerateRandomString();
            userPage.CreatePost(randomText);
        }

        [Then(@"The post will be created")]
        public void ThenThePostWillBeCreated()
        {
            Assert.IsTrue(userPage.CheckThatPostIsAppear(randomText),"Post is not appear.");
        }

        [When(@"I add a comment to the post")]
        public void WhenIAddACommentToThePost()
        {
            userPage.CreateComment(randomText);
        }

        [Then(@"The comment will be created")]
        public void ThenTheCommentWillBeCreated()
        {
            Assert.IsTrue(userPage.CheckThatCommentIsAppear(randomText),"Comment is not appear.");
        }

        [When(@"I like the last post")]
        public void WhenILikeTheLastPost()
        {
            userPage.ClickOnLike();
        }

        [Then(@"Like on the post will turn up")]
        public void ThenLikeOnThePostWillTurnUp()
        {
            Assert.IsTrue(userPage.IsLikeActive(),"Like is not active");
        }

        [AfterScenario]
        public void TearDown()
        {
            if (browser != null)
            {
                browser.Quit();
            }
        }
    }
}

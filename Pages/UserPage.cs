using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApi.Pages
{
    class UserPage : Form
    {
        private readonly ITextBox postFieldTextBox = ElementFactory.GetTextBox(By.XPath("//div[@id='post_field']"), "postFieldTextBox");
        private readonly IButton sendPostButton = ElementFactory.GetButton(By.XPath("//button[@id='send_post']"), "sendPostButton");
        private readonly ITextBox newPostTextBox = ElementFactory.GetTextBox(By.XPath("//div[@class='wall_text']"), "newPostTextBox");
        private readonly IButton commentButton = ElementFactory.GetButton(By.XPath("//a[contains(@class,'comment')]"), "commentButton");
        private readonly ITextBox commentTextBox = ElementFactory.GetTextBox(By.XPath("//div[contains(@id,'reply_field')]"), "commentTextBox");
        private readonly IButton sendCommentButton = ElementFactory.GetButton(By.XPath("//button[contains(@class,'reply_send_button')]"), "sendCommentButton");
        private readonly ITextBox newCommentTextBox = ElementFactory.GetTextBox(By.XPath("//div[@class='reply_text']"), "newCommentTextBox");
        private readonly IButton likeButton = ElementFactory.GetButton(By.XPath("//a[contains(@class,'like_btn')]"), "likeButton");
        private readonly ILink activeLikeLink = ElementFactory.GetLink(By.XPath("//a[contains(@class,'like animate active')]"), "activeLikeLink");

        public UserPage() : base(By.XPath("//div[contains(@class,'page_block']"), "MypagePage")
        {

        }

        public UserPage CreatePost(string text)
        {
            postFieldTextBox.Click();
            postFieldTextBox.SendKeys(text);
            sendPostButton.Click();

            return this;
        }

        public bool CheckThatPostIsAppear(string text)
        {
            Func<bool> func = new Func<bool>(() => newPostTextBox.Text.Equals(text));

            return AqualityServices.ConditionalWait.WaitFor(func, TimeSpan.FromSeconds(3));
        }

        public UserPage CreateComment(string text)
        {
            commentButton.Click();
            commentTextBox.SendKeys(text);
            sendCommentButton.Click();

            return this;
        }

        public bool CheckThatCommentIsAppear(string text)
        {
            Func<bool> func = new Func<bool>(() => newCommentTextBox.Text.Equals(text));

            return AqualityServices.ConditionalWait.WaitFor(func, TimeSpan.FromSeconds(3));
        }
        public UserPage ClickOnLike()
        {
            AqualityServices.Browser.Refresh();
            likeButton.Click();

            return this;
        }

        public bool IsLikeActive()
        {
            return activeLikeLink.State.IsDisplayed;
        }
    }
}

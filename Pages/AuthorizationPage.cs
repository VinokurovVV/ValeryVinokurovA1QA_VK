using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VkApi.Pages
{
    class AuthorizationPage : Form
    {
        private readonly ITextBox loginTextBox = ElementFactory.GetTextBox(By.XPath("//input[@id='index_email']"), "loginTextBox");
        private readonly ITextBox passwordTextBox = ElementFactory.GetTextBox(By.XPath("//input[@id='index_pass']"), "passwordTextBox");
        private readonly IButton loginButton = ElementFactory.GetButton(By.XPath("//button[@id='index_login_button']"), "loginButton");

        public AuthorizationPage() : base(By.XPath("//div[@id='index_login']"), "AuthorizationPage")
        {

        }

        public NewsPage Authorization(string login, string password)
        {
            loginTextBox.SendKeys(login);
            passwordTextBox.SendKeys(password);
            loginButton.Click();

            return new NewsPage();
        }
    }
}

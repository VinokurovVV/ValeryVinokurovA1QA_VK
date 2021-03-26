using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VkApi.Pages
{
    public class MenuForm : Form
    {
        private readonly IButton myPageButton = ElementFactory.GetButton(By.XPath("//li[@id='l_pr']"), "myPageButton");

        public MenuForm() : base(By.XPath("//div[@id='side_bar_inner']"), "MenuForm")
        {

        }

        public MenuForm ClickOnMyPageButton()
        {
            myPageButton.Click();

            return this;
        }
    }
}

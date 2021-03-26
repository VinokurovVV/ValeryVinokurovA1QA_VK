using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VkApi.Pages
{
    public class NewsPage : Form
    {
        public MenuForm menuForm;

        public NewsPage() : base(By.XPath("//div[@id='feed_rmenu']"), "NewsPage")
        {
            menuForm = new MenuForm();
        }
    }
}

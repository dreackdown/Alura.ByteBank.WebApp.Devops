using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using Xunit;

namespace Alura.ByteBank.WebApp.Testes
{
    public class RealizarLogin : IDisposable
    {
        public IWebDriver driver { get; private set; }
        public IDictionary<String, Object> vars { get; private set; }
        public IJavaScriptExecutor js { get; private set; }
        public RealizarLogin()
        {
            driver = new ChromeDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<String, Object>();
        }
        public void Dispose()
        {
            driver.Quit();
        }
        [Fact]
        public void ExecutandoLoginWebApp()
        {
            driver.Navigate().GoToUrl("https://localhost:44309/");
            driver.Manage().Window.Size = new System.Drawing.Size(1309, 712);
            {
                IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.LinkText("Home"));
                Assert.True(elements.Count > 0);
            }
            {
                IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.LinkText("ByteBank-WebApp"));
                Assert.True(elements.Count > 0);
            }
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("Email")).Click();
            driver.FindElement(By.Id("Email")).SendKeys("andre@email.com");
            driver.FindElement(By.Id("Senha")).Click();
            driver.FindElement(By.Id("Senha")).SendKeys("senha01");
            driver.FindElement(By.Id("btn-logar")).Click();
            {
                IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.Id("agencia"));
                Assert.True(elements.Count > 0);
            }
            {
                IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.CssSelector(".btn"));
                Assert.True(elements.Count > 0);
            }
            driver.FindElement(By.CssSelector(".btn")).Click();
        }
    }

}

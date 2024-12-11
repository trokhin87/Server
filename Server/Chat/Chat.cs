using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Server.Chat
{   
    public class Chat
    {
        private string _url = "https://alice.yandex.ru/";
        public string ChatAnswer(string promt)
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            IWebDriver driver = new ChromeDriver(options);
            try
            {
                // Открываем страницу
                driver.Navigate().GoToUrl(_url);
                Thread.Sleep(3000);

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                // Находим поле ввода
                IWebElement inputField = wait.Until(d =>
                    d.FindElement(By.XPath("/html/body/div[1]/div/div[7]/div/div[3]/div[1]/div[1]/div/textarea"))); // Универсальный поиск текстового поля

                // Вводим запрос
                inputField.SendKeys(promt);
                inputField.SendKeys(Keys.Enter);

                // Ожидание загрузки ответа
                wait.Until(d =>
                    d.FindElements(By.XPath("/html/body/div[1]/div/div[6]/div/div/div[2]/div/div/div[2]/div/div/div[1]/div/div[2]")).Count > 0); // Проверка, что сообщения появились
                Thread.Sleep(5000);

                // Находим все элементы ответа
                var responseElements = driver.FindElements(By.XPath("/html/body/div[1]/div/div[6]/div/div/div[2]/div/div/div[2]/div/div/div[1]/div"));

                // Собираем текст всех сообщений
                string response = string.Join("\n", responseElements.Select(e => e.Text));

                //Console.WriteLine("Ответ от ChatGPT: " + response);
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            finally
            {
                driver.Quit();
            }
            return string.Empty;
        }
    }
}

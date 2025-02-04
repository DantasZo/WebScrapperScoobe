using System;
using System.Threading.Tasks;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebScraper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://www.skoob.com.br/estante/livros/1/2762696/page:1?privacy-agree=true";
            string url2 = "https://www.skoob.com.br/estante/livros/3/2762696/page:1";
            string email = "";
            string pass = "";
            string filePath = @"";

            ChromeOptions options = new ChromeOptions();
            options.AddArgument(@""); 

            using IWebDriver driver = new ChromeDriver(options);

            try
            {
                driver.Navigate().GoToUrl(url);

                await Task.Delay(5000); 

                IWebElement emailField = driver.FindElement(By.Id("UsuarioEmail"));
                emailField.SendKeys(email);

                IWebElement passwordField = driver.FindElement(By.Id("UsuarioSenha"));
                passwordField.SendKeys(pass);

                passwordField.Submit();

                
                await Task.Delay(5000); 

                driver.Navigate().GoToUrl(url2);

                await Task.Delay(5000); 

               
                IWebElement iconElement = driver.FindElement(By.CssSelector("img[src='https://static-sp.skoob.com.br/icones/est_v_on.gif']"));
                iconElement.Click();

                await Task.Delay(5000); 

                int pageCount = 0;
                bool hasNextPage = true;

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    while (hasNextPage && pageCount < 6)
                    {
                        IList<IWebElement> contentDivs = driver.FindElements(By.CssSelector("div.livro-conteudo.ng-scope"));
                        foreach (IWebElement contentDiv in contentDivs)
                        {
                            IWebElement h3Element = contentDiv.FindElement(By.CssSelector("h3.ng-binding"));
                            IWebElement pElement = contentDiv.FindElement(By.CssSelector("p.ng-binding"));
                            string itemText = h3Element.Text + " " + pElement.Text;
                            writer.WriteLine($"{itemText};");
                        }

                        try
                        {
                            IWebElement nextPageLink = driver.FindElement(By.CssSelector("a.ng-binding[ng-click='selectPage(page + 1)']"));
                            nextPageLink.Click();
                            pageCount++;
                            await Task.Delay(5000); 
                        }
                        catch (NoSuchElementException)
                        {
                            hasNextPage = false;
                        }
                    }
                }

                Console.WriteLine($"Os dados foram coletados e armazenados em {filePath}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao acessar a página: {e.Message}");
            }

            while (true)
            {
                Console.WriteLine("Deseja encerrar? (S/N)");
                string input = Console.ReadLine().Trim().ToUpper();

                if (input == "S")
                {
                    break;
                }
                else if (input == "N")
                {
                    await Task.Delay(10000); 
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite 'S' para sair ou 'N' para aguardar.");
                }
            }
        }
    }
}
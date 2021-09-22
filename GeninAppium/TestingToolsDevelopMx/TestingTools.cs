using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Support.UI;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Globalization;
using System.Threading;

namespace TestingToolsDevelopMx
{
    public class TestingTools
    {
        public AppiumOptions capabilities;
        public AndroidDriver<AndroidElement> driver;
        public string State;

        //Inicializar "Capabilities" del driver
        public void CapsInit(String branch, String jobName)
        {
            this.capabilities = new AppiumOptions();

            capabilities.AddAdditionalCapability("autoAcceptAlerts", true);
            capabilities.AddAdditionalCapability("autoGrantPermissions", true);
            capabilities.AddAdditionalCapability("platformName", "Android");

            //Personalizar
            capabilities.AddAdditionalCapability("deviceName", "Modelo de tu dispositivo o emulador");
            capabilities.AddAdditionalCapability("app", "Ruta a tu aplicacion");
            capabilities.AddAdditionalCapability("platformVersion", "Version de Android");
        }

        //Conectar a driver en Localhost
        public AndroidDriver<AndroidElement> getDriver()
        {
            driver = new AndroidDriver<AndroidElement>(
                new Uri("127.0.0.1:4723/wd/hub"), capabilities);
            return driver;
        }

        //Reportar resultado de prueba por correo
        public void EnviarCorreo(String name, String build)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");

                string htmltext =
                    "<html>" +
                    "<head></head>" +
                    "<body>" +
                    "<h2>Reporte de prueba automatizada fallida</h2>" +
                    "<h4>Hubo un error en la prueba: " + name.ToString() + "</h4> " +
                    "<ul> " +
                    "<li>Fecha de ejecucion: " + DateTime.Now.ToString() + " - " + "</li>  " +
                    "<li>Error en el paso (" + State + ")" + "</li>  " +
                    "</body> " +
                    "</html>";

                RestClient client = new RestClient();
                RestRequest request = new RestRequest();

                client.BaseUrl = new Uri("https://api.mailgun.net/v3");
                client.Authenticator = new HttpBasicAuthenticator("api", "key-35e7388efdd202c9d79d75912e0c38d8");

                request.Resource = "{domain}/messages";
                request.AddParameter("domain", "noreplymail.develop.mx", ParameterType.UrlSegment);
                request.AddParameter("from", "Error en prueba automatizada <labpruebas@noreplymail.develop.mx>");
                request.AddParameter("to", "lab.developmx@gmail.com");
                request.AddParameter("subject", "Pruebas automatizadas: " + build);
                request.AddParameter("text", "Ocurrio un error en la prueba automatizada: " + name);
                request.AddParameter("html", htmltext);

                request.Method = Method.POST;

                client.Execute(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        //Cambiar estado actual
        public void newStep(string state)
        {
            State = state;
        }

        //Scroll hacia abajo
        public void ScrollDown(AppiumDriver<AndroidElement> driver)
        {
            ITouchAction touchAction = new TouchAction(driver)
            .Press(200, 1000)
            .Wait(500)
            .MoveTo(200, 200)
            .Release();

            touchAction.Perform();
        }

        //Scroll hacia arriba
        public void ScrollUp(AppiumDriver<AndroidElement> driver)
        {
            ITouchAction touchAction = new TouchAction(driver)
            .Press(200, 200)
            .Wait(500)
            .MoveTo(200, 1000)
            .Release();

            touchAction.Perform();
        }

        //Tap en cordenadas
        public void TouchCordinates(AppiumDriver<AndroidElement> driver, int x, int y)
        {
            ITouchAction touchAction = new TouchAction(driver)
            .Tap(x, y);

            touchAction.Perform();
        }

        //Hacer click a elemento en pantalla encontrado mediante su texto
        public void ClickText(string txt, AppiumDriver<AndroidElement> driver)
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + txt + "\")"))
            );

            searchElement.Click();
        }

        //Introducir texto a una caja a travez del ID
        public void InputText(string id, string text, AppiumDriver<AndroidElement> driver)
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.Id(id))
            );

            searchElement.Click();
            searchElement.Clear();
            searchElement.SendKeys(text);

            Thread.Sleep(1200);

            if (driver.IsKeyboardShown())
            {
                Thread.Sleep(2000);

                driver.Navigate().Back();
            }
        }

        //Hacer click a elemento en pantalla mediante su ID
        public void ClickButton(string id, AppiumDriver<AndroidElement> driver)
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.Id(id))
            );

            searchElement.Click();
        }

        //Hacer click al primer elemento encontrado que pertenezca a la clase
        public void ClickClass(string clss, AppiumDriver<AndroidElement> driver)
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.ClassName(clss))
            );

            searchElement.Click();
        }

        //Verificar que un elemento se encuentré en pantalla
        public bool CheckElement(string id, AppiumDriver<AndroidElement> driver)
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.Id(id))
            );

            if (searchElement == null)
            {
                Console.WriteLine("Salida inesperada");
                return false;
            }
            else
            {
                Console.WriteLine("Salida correcta");
                return true;
            }
        }

        //Verificar que un elemento se encuentre en pantalla
        public bool CheckText(string txt, AppiumDriver<AndroidElement> driver)
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + txt + "\")"))
            );

            if (searchElement == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Obtener el texto de un elemento en pantalla
        public string GetElemenText(string id, AppiumDriver<AndroidElement> driver)
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.Id(id))
            );

            return searchElement.GetAttribute("text");
        }

        //Comparar el texto de un elemento con un string
        public bool CheckElementText(string id, string text, AppiumDriver<AndroidElement> driver)
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.Id(id))
            );

            if (searchElement.GetAttribute("text") != text)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Instrucciones para hacer login
        public void LogIn(AppiumDriver<AndroidElement> driver, String mail, String pass)
        {
            ClickButton("com.soriana.appsorianasf:id/imgArrow", driver);
            ClickButton("com.soriana.appsorianasf:id/btnIniciaSesion", driver);
            InputText("com.soriana.appsorianasf:id/editEmail", mail, driver);
            InputText("com.soriana.appsorianasf:id/editPass", pass, driver);
            ClickButton("com.soriana.appsorianasf:id/btn_login", driver);
        }
    }
}
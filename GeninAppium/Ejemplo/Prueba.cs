using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using TestingToolsDevelopMx;

namespace Ejemplo
{
    [TestClass]
    public class Prueba
    {
        TestingTools testingTools = new TestingTools();

        [TestMethod]
        public void PruebaEjemplo()
        {
            //                       Grupo de pruebas       Nombre de prueba
            testingTools.CapsInit("Pruebas Automatizadas", "Ejemplo de Prueba");

            AppiumDriver<AndroidElement> driver = testingTools.getDriver();

            try
            {

                /*Escribe aqui los pasos
                 
                    Ejemplo:
                testingtools.newStep("Presionar boton 'Perfil'");
                testingtools.ClickButton("com.soriana.appsorianasf:id/menuPerfilFragment", driver);

                */

                driver.Quit();
            } catch (Exception ex)
            {
                driver.Quit();
            }
        }
    }
}

# AppiumGeninDevelopMx

Este es un repositorio con una plantilla lista para correr pruebas automatizadas de una app para android, para correr tus pruebas necesitas:

  - Appium Desktop
  - Visual Studio Code
  - Emulador de Android Studio o dispositivo android conectado mediante USB con el modo depuracion USB
  - AndroidSDK Tools
  - Variable ANDROID_SDK_ROOT
  - Apk de la aplicacion a probar en el directorio de archivos
  
Este repositorio contiene:

  - Proyecto "TestingToolsDevelopMx" el cual contiene una clase con los metodos y variables necesarios para correr las pruebas en android
  - Pryecto "Ejemplo" con una clase "Prueba" que sirve a modo de plantilla para realizar tu primera prueba automatizada
  - Dependencias "Appium", "SeleniumWaitHelpers" y "RestSharp" instalables desde NuGetManager
  
Como correr las pruebas:

  1 - iniciar appium desktop con tu emulador encendido o tu dispositivo conectado en modo depuracion USB
  
  2 - Configurar la ip del servidor como 127.0.0.1
  
  3 - Seleccionar el puerto de red 4723
  
  4 - Click derecho en el nombre de tu prueba en visual studio y selecciona "Ejecutar prueba"

using Automation.Drivers;
using Automation.Pages;
using TechTalk.SpecFlow.Assist;

namespace Automation.Steps;

[Binding]
public class LoginTestSteps
{
    public readonly Driver _driver;
    public readonly Login _login;

    public LoginTestSteps(Driver driver)
    {
        _driver = driver;
        _login = new Login(_driver.Page);
    }
    
    [Given(@"Yo estoy navegando hacia la pagina")]
    public void GivenYoEstoyNavegandoHaciaLaPagina()
    {
        _driver.Page.GotoAsync("https://parqueportales.tribalworldwide.gt/login/");
    }

    [Given(@"Yo Quiero iniciar sesion")]
    public async Task GivenYoQuieroIniciarSesion()
    {
        await _login.isTextvisivle();
    }

    [When(@"Yo ingreso mis datos de inicio de sesion")]
    public async Task WhenYoIngresoMisDatosDeInicioDeSesion(Table table)
    {
        dynamic data = table.CreateDynamicInstance(); 
        await _login.FillLogin((String)data.email, (String)data.password);
    }

    [Then(@"Yo debo poder ver mi cuenta ya creada")]
    public async Task ThenYoDeboPoderVerMiCuentaYaCreada()
    {
        await _login.isCerrarSesionBtnVisible();
    }
}
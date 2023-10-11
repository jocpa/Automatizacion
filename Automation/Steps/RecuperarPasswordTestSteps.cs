using Automation.Drivers;
using Automation.Pages;
using TechTalk.SpecFlow.Assist;

namespace Automation.Steps;

[Binding]
public class RecuperarPasswordTestSteps
{
    public readonly Driver _driver;
    public readonly RecuperarPassword _recuperarPassword;

    public RecuperarPasswordTestSteps(Driver driver)
    {
        _driver = driver;
        _recuperarPassword = new RecuperarPassword(_driver.Page);
    }
    
    [Given(@"Yo Estoy navegando hacia la pagina web")]
    public void GivenYoEstoyNavegandoHaciaLaPaginaWeb()
    {
        _driver.Page.GotoAsync("https://parqueportales.tribalworldwide.gt/login/");
    }

    [Given(@"Yo quiero recuperar mi password")]
    public async Task GivenYoQuieroRecuperarMiPassword()
    {
        await _recuperarPassword.OpenRecuperarPassword();
    }

    [When(@"Yo ingrese mi email")]
    public async Task WhenYoIngreseMiEmail(Table table)
    { 
        dynamic data = table.CreateDynamicInstance();
        await _recuperarPassword.FillForm((String)data.email);
    }

    [Then(@"Yo debo poder recuperar mi cuenta")]
    public async Task ThenYoDeboPoderRecuperarMiCuenta()
    {
        await _recuperarPassword.isModalVisible();
    }
}
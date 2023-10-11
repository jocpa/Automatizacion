using Automation.Drivers;
using Automation.Pages;
using TechTalk.SpecFlow.Assist;

namespace Automation.Steps;

[Binding]
public sealed class ContactoTestSteps
{
    private readonly Driver _driver;
    private readonly Contacto _contacto;

    public ContactoTestSteps(Driver driver)
    {
        _driver = driver;
        _contacto = new Contacto(_driver.Page);
    }
    
    [Given(@"Yo quiero suscribirme a contacto")]
    public void GivenYoQuieroSuscribirmeAContacto()
    {
        _driver.Page.GotoAsync("https://spectrumviviendas.tribalworldwide.gt/spectrum-te-guia/");
    }

    [Given(@"Yo hago click en contactanos")]
    public async Task GivenYoHagoClickEnContactanos()
    {
        await _contacto.OpenContact();
    }

    [When(@"Yo ingreso mis datos personales")]
    public async Task WhenYoIngresoMisDatosPersonales(Table table)
    {
        dynamic data = table.CreateDynamicInstance();
        await _contacto.ContactForm((String)data.nombre, (String)data.celular, (String)data.correo);
    }

    [Then(@"Yo debo ver una alerta de envio exitoso")]
    public async Task ThenYoDeboVerUnaAlertaDeEnvioExitoso()
    {
        await _contacto.isAlertVisible();
    }
}
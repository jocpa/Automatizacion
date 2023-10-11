using TechTalk.SpecFlow.Assist;
using Automation.Drivers;
using Automation.Pages;

namespace Automation.Steps;

[Binding]
public class AgendarCitaTestSteps
{
    public readonly Driver _driver;
    public readonly AgendarCita _agendarCita;

    public AgendarCitaTestSteps(Driver driver)
    {
        _driver = driver;
        _agendarCita = new AgendarCita(_driver.Page);
    }
    
    [Given(@"Yo estoy navegando hacia la aplicacio")]
    public void GivenYoEstoyNavegandoHaciaLaAplicacio()
    {
        _driver.Page.GotoAsync("https://parqueportales.tribalworldwide.gt/agendar-cita/");
    }

    [Given(@"Yo quiero agendar una cita")]
    public async Task GivenYoQuieroAgendarUnaCita()
    {
        await _agendarCita.isTextVisible();
    }

    [When(@"Yo ingrese mis datos personales")]
    public async Task WhenYoIngreseMisDatosPersonales(Table table)
    {
        dynamic data = table.CreateDynamicInstance();
        await _agendarCita.FillForm((String)data.nombre, (String)data.email, (String)data.telefono);
    }

    [Then(@"Yo debo ser agendado para una cita")]
    public async Task ThenYoDeboSerAgendadoParaUnaCita()
    {
        await _agendarCita.isSuccesAlertVisible();
    }
}
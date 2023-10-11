using Automation.Drivers;
using Automation.Pages;
using TechTalk.SpecFlow.Assist;

namespace Automation.Steps;

[Binding]
public sealed class CalculadoraTestSteps
{
    private readonly Driver _driver;
    private readonly Calculadora _calculadora;
    
    public CalculadoraTestSteps(Driver driver)
    {
        _driver = driver;
        _calculadora = new Calculadora(_driver.Page);
    }

    [Given(@"Yo estoy navegando hacia la aplicacion")]
    public void GivenYoEstoyNavegandoHaciaLaAplicacion()
    {
        _driver.Page.GotoAsync("https://spectrumviviendas.tribalworldwide.gt");
    }

    [Given(@"Yo hago click en cotiza tu vivienda")]
    public async Task GivenYoHagoClickEnCotizaTuVivienda()
    {
        await _calculadora.OpenCalculator();
    }

    [Given(@"Yo ingreso los siguientes valores")]
    public async Task GivenYoIngresoLosSiguientesValores(Table table)
    {
        dynamic data = table.CreateDynamicInstance();
        await _calculadora.CalcularFinanciamiento((String)data.Inmueble, (String)data.Enganche);
    }

    [Then(@"Debo ver la cotizacions")]
    public async Task ThenDeboVerLaCotizacions()
    {
        await _calculadora.isbtnDescargarVisible();
    }
}
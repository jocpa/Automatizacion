using Microsoft.Playwright;

namespace Automation.Pages;

public class Calculadora
{
    private IPage _page;
    private readonly ILocator _btnCalculadora;
    private readonly ILocator _valorPropiedad;
    private readonly ILocator _valorEnganche;
    private readonly ILocator _tiempo;
    private readonly ILocator _btnCalcular;
    private readonly ILocator _btnDescargarPDF;
    private readonly ILocator _emptyAlert;

    public Calculadora(IPage page)
    {

        _page = page;
        _btnCalculadora = _page.Locator("#site-navigation").GetByText("Cotiza tu vivienda");
        _valorPropiedad = _page.Locator("#inmueble");
        _valorEnganche = _page.Locator("#enganche");
        _tiempo = _page.Locator("");
        _btnCalcular = _page.Locator("text='Calcular financiamiento'");
        _btnDescargarPDF = _page.Locator(".donwload_pdf");
        _emptyAlert = _page.Locator(".invalid-feedback");
    }

    public async Task OpenCalculator() => await _btnCalculadora.ClickAsync();

    public async Task IsEmptyAlertVisible() => await _emptyAlert.IsVisibleAsync();

    public async Task CalcularFinanciamiento(String valor, String enganche)
    {
        await _valorPropiedad.FillAsync(valor);
        await _valorEnganche.FillAsync(enganche); 
        //await _tiempo.SelectOptionAsync(tiempo);
        await _btnCalcular.ClickAsync();
    }

    public async Task<bool> isbtnDescargarVisible() => await _btnDescargarPDF.IsVisibleAsync();
}
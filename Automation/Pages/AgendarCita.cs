using Microsoft.Playwright;

namespace Automation.Pages;

public class AgendarCita
{
    private IPage _page;
    private readonly ILocator _h1Text;
    private readonly ILocator _inputNombre;
    private readonly ILocator _inputCorreo;
    private readonly ILocator _inputTelefono;
    private readonly ILocator _btnEnviar;
    private readonly ILocator _emptyAlert;
    private readonly ILocator _alertSucces;

    public AgendarCita(IPage page)
    {
        _page = page;
        _h1Text = _page.Locator("#primary > section > div.make-appointment__wrapper > div.row.d-none.d-lg-block > div > h1");
        _inputNombre = _page.Locator("#fullName");
        _inputCorreo = _page.Locator("#email");
        _inputTelefono = _page.Locator("#phone");
        _btnEnviar = _page.Locator("text=Enviar");
        _emptyAlert = _page.Locator(".invalid-feedback");
        _alertSucces = _page.Locator(".toast-body");
    }

    public async Task<bool> isTextVisible() => await _h1Text.IsVisibleAsync();
    public async Task<bool> isEmptyAlertVisible() => await _emptyAlert.IsVisibleAsync();
    public async Task<bool> isSuccesAlertVisible() => await _alertSucces.IsVisibleAsync();

    public async Task FillForm(String nombre, String email, String telefono)
    {
        await _inputNombre.FillAsync(nombre);
        await _inputCorreo.FillAsync(email);
        await _inputTelefono.FillAsync(telefono);
        await _btnEnviar.ClickAsync();
    }
}
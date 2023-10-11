using Microsoft.Playwright;

namespace Automation.Pages;

public class Contacto
{
    
    private IPage _page;
    private readonly ILocator _btnContacto;
    private readonly ILocator _inputNombre;
    private readonly ILocator _inputCelular;
    private readonly ILocator _inputCorreo;
    private readonly ILocator _inputProyecto;
    private readonly ILocator _btnEnviar;
    private readonly ILocator _alert;
    private readonly ILocator _emptyAlert;

    public Contacto(IPage page)
    {
        _page = page;
        _btnContacto = _page.Locator("#openContact");
        _inputNombre = _page.Locator("#nombreUser");
        _inputCelular = _page.Locator("#phoneUser");
        _inputCorreo = _page.Locator("#emailUser");
        _inputProyecto = _page.Locator(".selected selector-wrapper");
        _btnEnviar = _page.Locator("#btn-send");
        _alert = _page.Locator(".msg-envio");
        _emptyAlert = _page.Locator(".invalid-feedback");
    }

    public async Task OpenContact() => _btnContacto.ClickAsync();
    public async Task isEmptyAlertVisible() => _emptyAlert.IsVisibleAsync();

    public async Task ContactForm(String nombre, String celular, String correo)
    {
        await _inputNombre.FillAsync(nombre);
        await _inputCelular.FillAsync(celular);
        await _inputCorreo.FillAsync(correo);
        //await _inputProyecto.SelectOptionAsync(proyecto);
        //Parque San Jorge
        await _btnEnviar.ClickAsync();
    }

    public async Task<bool> isAlertVisible() => await _alert.IsVisibleAsync();

}
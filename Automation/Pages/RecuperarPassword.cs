using Microsoft.Playwright;

namespace Automation.Pages;

public class RecuperarPassword
{
    private IPage _page;
    private readonly ILocator _olvidePasswordLink;
    private readonly ILocator _h1Text;
    private readonly ILocator _inputEmail;
    private readonly ILocator _btnEnviar;
    private readonly ILocator _emptyAlert;
    private readonly ILocator _CorreoValidoAlert;
    private readonly ILocator _modal;

    public RecuperarPassword(IPage page)
    {
        _page = page;
        _olvidePasswordLink = _page.Locator("#form-sigin > div.ptop10 > p > a");
        _h1Text = _page.Locator("#primary > section > div.detail-apartment__slider.detail-apartment__slider--login.detail-apartment__slider--w40.detail-apartment__slider--register > div > div > div > div > h1");
        _inputEmail = _page.Locator("#email");
        _btnEnviar = page.Locator("text=Enviar");
        _CorreoValidoAlert = _page.Locator(".invalid-feedback text=Debe ser un correo válido.");
        _emptyAlert = _page.Locator(".invalid-feedback");
        _modal = _page.Locator(".data-modal");
    }

    public async Task OpenRecuperarPassword() => await _olvidePasswordLink.ClickAsync();
    public async Task<bool> isTextVisivle() => await _h1Text.IsVisibleAsync();
    public async Task<bool> isCorreoValidoAlertVisible() => await _CorreoValidoAlert.IsVisibleAsync();
    public async Task<bool> isEmptyAlertVisible() => await _emptyAlert.IsVisibleAsync();
    public async Task<bool> isModalVisible() => await _modal.IsVisibleAsync();

    public async Task FillForm(String email)
    {
        await _inputEmail.FillAsync(email);
        _btnEnviar.ClickAsync();
    }
}

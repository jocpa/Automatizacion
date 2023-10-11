using Microsoft.Playwright;

namespace Automation.Pages;

public class Login
{

    private IPage _page;
    private readonly ILocator _inputCorreo;
    private readonly ILocator _inputpassword;
    private readonly ILocator _btnInciarSesion;
    private readonly ILocator _h1Text;
    private readonly ILocator _invalidPassword;
    private readonly ILocator _emptyAlert;
    private readonly ILocator _CorreoValidoAlert;
    private readonly ILocator _cerrarSesionBtn;
    

    public Login(IPage page)
    {
        _page = page;
        _h1Text = _page.Locator("text=Inicia sesión");
        _inputCorreo = _page.Locator("#email");
        _inputpassword = _page.Locator("#password");
        _btnInciarSesion = _page.Locator("#form-sigin > div.ptop10 > div > button");
        _invalidPassword = _page.Locator(
            ".invalid-feedback text=La contraseña debe tener al menos 6 caracteres, contener mayúsculas, minúsculas y números, sin caracteres especiales.");
        _CorreoValidoAlert = _page.Locator(".invalid-feedback text=Debe ser un correo válido.");
        _emptyAlert = _page.Locator(".invalid-feedback");
        _cerrarSesionBtn = _page.Locator("//*[@id=\"primary\"]/section/div[2]/div/div/div[3]/a");
    }

    public async Task<bool> isTextvisivle() => await _h1Text.IsVisibleAsync();
    public async Task<bool> isInvalidPasswordVisible() => await _invalidPassword.IsVisibleAsync();
    public async Task<bool> isCorreoValidoAlertVisible() => await _CorreoValidoAlert.IsVisibleAsync();
    public async Task<bool> isEmptyAlertVisible() => await _emptyAlert.IsVisibleAsync();
    public async Task<bool> isCerrarSesionBtnVisible() => await _cerrarSesionBtn.IsVisibleAsync();

    public async Task FillLogin(String email, String password)
    {
        await _inputCorreo.FillAsync(email);
        await _inputpassword.FillAsync(password);
        await _btnInciarSesion.ClickAsync();
    }
    

}
using Microsoft.Playwright;

namespace Automation.Pages;

public class Registro
{
    private IPage _page;
    private readonly ILocator _crearCuentaBtn;
    private readonly ILocator _h1Text;
    private readonly ILocator _inputCorreo;
    private readonly ILocator _inputNombre;
    private readonly ILocator _inputApellido;
    private readonly ILocator _inputProfesion;
    private readonly ILocator _inputCelular;
    private readonly ILocator _inputPassword;
    private readonly ILocator _inputConfirmPassword;
    private readonly ILocator _newsletter;
    private readonly ILocator _terminos;
    private readonly ILocator _bntCrearCuenta;
    private readonly ILocator _emptyAlert;
    private readonly ILocator _dangerAlert;
    private readonly ILocator _incorrectPasswordAlert;
    private readonly ILocator _validarCuentaBtn;

    public Registro(IPage page)
    {
        _page = page;
        _crearCuentaBtn = _page.Locator("//*[@id=\"form-sigin\"]/div[3]/div/a");
        _h1Text = _page.Locator("text=Crea una nueva cuenta");
        _inputCorreo = _page.Locator("#email");
        _inputNombre = _page.Locator("#fname");
        _inputApellido = _page.Locator("#lname");
        _inputProfesion = _page.Locator("#profession");
        _inputCelular = _page.Locator("#phone");
        _inputPassword = _page.Locator("#password");
        _inputConfirmPassword = _page.Locator("#confirm-password");
        _newsletter = _page.Locator("#newsletter");
        _terminos = _page.Locator("#terms");
        _bntCrearCuenta = _page.Locator("text=Crear cuenta");
        _emptyAlert = _page.Locator(".invalid-feedback");
        _dangerAlert = _page.Locator(".toast-body");
        _incorrectPasswordAlert =
            _page.Locator(
                ".invalid-feedback text=La contraseña debe tener al menos 6 caracteres, contener mayúsculas, minúsculas y números, sin caracteres especiales.");
        _validarCuentaBtn = _page.Locator("//*[@id=\"primary\"]/section/div[2]/div/div/div/div/h1");
    }

    public async Task openRegisterPage() => await _crearCuentaBtn.ClickAsync();
    public async Task<bool> isTextVisible() => await _h1Text.IsVisibleAsync();
    public async Task<bool> isEmptyAlertVisible() => await _emptyAlert.IsVisibleAsync();
    public async Task<bool> isDangerAlertVisible() => await _dangerAlert.IsVisibleAsync();
    public async Task<bool> isValidarCuentaBtnVisible() => await _validarCuentaBtn.IsVisibleAsync();

    public async Task<bool> isIncorrectPasswordAlertVisible() => await _incorrectPasswordAlert.IsVisibleAsync();

    public async Task CrearCuentaForm(String email, String nombre, String apellido, String profesion, String celular,
        String password)
    {
        _inputCorreo.FillAsync(email);
        _inputNombre.FillAsync(nombre);
        _inputApellido.FillAsync(apellido);
        _inputProfesion.FillAsync(profesion);
        _inputCelular.FillAsync(celular);
        _inputPassword.FillAsync(password);
        _inputConfirmPassword.FillAsync(password);
        _terminos.ClickAsync();
        _bntCrearCuenta.ClickAsync();
    }
}
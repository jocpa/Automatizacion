using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Drivers;
using Automation.Pages;
using TechTalk.SpecFlow.Assist;

namespace Automation.Steps;

[Binding]
public sealed class RegistroTestSteps
{

    private readonly Driver _driver;
    private readonly Registro _registro;

    public RegistroTestSteps(Driver driver)
    {
        _driver = driver;
        _registro = new Registro(_driver.Page);
    }
    
    [Given(@"Yo estoy navegando hacia la pagina web")]
    public void GivenYoEstoyNavegandoHaciaLaPaginaWeb()
    {
        _driver.Page.GotoAsync("https://parqueportales.tribalworldwide.gt/login/");
    }

    [Given(@"Yo quiero registrarme en la pagina")]
    public async Task GivenYoQuieroRegistrarmeEnLaPagina()
    {
        await _registro.openRegisterPage();
    }

    [When(@"Yo ingreso mis datos")]
    public async Task WhenYoIngresoMisDatos(Table table)
    {
        dynamic data = table.CreateDynamicInstance();
        await _registro.CrearCuentaForm((String)data.email, (String)data.nombre, (String)data.apellido,
            (String)data.profesion, (String)data.celular, (String)data.password);
    }

    [Then(@"Yo debo ser redireccionado a una nueva pagina")]
    public async Task ThenYoDeboSerRedireccionadoAUnaNuevaPagina()
    {
        await _registro.isValidarCuentaBtnVisible();
    }
}
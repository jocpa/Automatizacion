Feature: ContactoTest
	Solicitando informacion sobre algun proyecto en el formulario de contacto

@contacto
Scenario: HappyPathFormularioContacto
	Given Yo quiero suscribirme a contacto
	And Yo hago click en contactanos
	When Yo ingreso mis datos personales
		| nombre        | celular  | correo                         | 
		| Gwen Staci | "57804923" | gwenspiderwoman@gmail.com | 
	Then Yo debo ver una alerta de envio exitoso
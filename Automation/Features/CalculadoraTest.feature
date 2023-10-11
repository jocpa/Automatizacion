Feature: CalculadoraTest
	Calculado financiamiento para cualquier inmueble

@calculate
Scenario: Calcular financiamiento para un inmueble
	Given Yo estoy navegando hacia la aplicacion
	And Yo hago click en cotiza tu vivienda
	And Yo ingreso los siguientes valores
		| Inmueble | Enganche | Tiempo    |
		| "500000" | "25000"  | "15 Años" |
	Then Debo ver la cotizacions
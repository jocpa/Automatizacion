Feature: LoginTest
	Test de Iniciando sesion

@mytag
Scenario: Iniciando sesion
	Given Yo estoy navegando hacia la pagina
	And Yo Quiero iniciar sesion
	When Yo ingreso mis datos de inicio de sesion
		| email                    | password |
		| jarzu@tribalworldwide.gt | 1234Abcd |
	Then Yo debo poder ver mi cuenta ya creada
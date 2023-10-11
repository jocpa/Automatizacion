Feature: RegistroTest
	Test para crear un usuario en Spectrum Portales

@registro
Scenario: Happy path Registro
	Given Yo estoy navegando hacia la pagina web
	And Yo quiero registrarme en la pagina
	When Yo ingreso mis datos
		| email                    | nombre | apellido | profesion | celular  | password |
		| jarzu@tribalworldwide.gt | Pablo  | Arzu     | QA Tester | "56304455" | 1234Abcd |
	Then Yo debo ser redireccionado a una nueva pagina
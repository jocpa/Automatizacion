Feature: RecuperarPasswordTestSteps
	Testing al formulario de recuperar password

@Recuperar
Scenario: Happy path Recuperar password
	Given Yo Estoy navegando hacia la pagina web
	And Yo quiero recuperar mi password
	When Yo ingrese mi email
		| email                    |
		| jarzu@tribalworldwide.gt |
	Then Yo debo poder recuperar mi cuenta
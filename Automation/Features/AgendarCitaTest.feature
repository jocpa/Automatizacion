Feature: AgendarCitaTest
	Testing al formulario de agendar cita

@Cita
Scenario: Happy Path Agendar Cita
	Given Yo estoy navegando hacia la aplicacio
	And Yo quiero agendar una cita
	When Yo ingrese mis datos personales
		| nombre | email                   | telefono   |
		| Pablo  | jarzu@tribalworlwide.gt | "56904466"|
	Then Yo debo ser agendado para una cita
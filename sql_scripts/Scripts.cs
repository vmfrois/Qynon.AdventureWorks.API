using System;

public class Scripts
{
	CREATE TABLE Competidores(
	Id serial PRIMARY KEY,
	Nome VARCHAR (150) NOT NULL,
	Sexo CHAR(1) NOT NULL,
	TemperaturaMediaCorpo DECIMAL NOT NULL,
	Peso DECIMAL NOT NULL,
	Altura DECIMAL NOT NULL);
	


	CREATE TABLE PistaCorrida(
		Id serial PRIMARY KEY,
		Descricao VARCHAR (50 ) NOT NULL
	);


	CREATE TABLE HistoricoCorrida(
		Id serial PRIMARY KEY,
		CompetidorId INT,
		PistaCorridaId INT,
		DataCorrida DATE NOT NULL,
		TempoGasto DECIMAL NOT NULL,
		CONSTRAINT fk_competidor
	
		FOREIGN KEY(CompetidorId)
			REFERENCES Competidores(Id),
		CONSTRAINT fk_pista_corrida
	
		FOREIGN KEY(PistaCorridaId)
			REFERENCES PistaCorrida(Id)
		);
}

use odirlei_lanhouse_saep;

insert into Usuarios values('admin@admin', '12345');

BULK INSERT TiposDefeitos
	FROM 'C:\csv\defeito.csv'
		WITH(
			FORMAT = 'csv',
			FIRSTROW = 1,
			FIELDTERMINATOR = ',',
			ROWTERMINATOR = '\n',
			CODEPAGE = 'ACP',
			DATAFILETYPE = 'Char'
		);

BULK INSERT TiposEquipamentos
	FROM 'C:\csv\tipo_equipamento.csv'
		WITH(
			FORMAT = 'csv',
			FIRSTROW = 1,
			FIELDTERMINATOR = ',',
			ROWTERMINATOR = '\n',
			CODEPAGE = 'ACP',
			DATAFILETYPE = 'Char'
		);

BULK INSERT RegistroDefeitos
	FROM 'C:\csv\registro_defeito.csv'
		WITH(
			FORMAT = 'csv',
			FIRSTROW = 1,
			FIELDTERMINATOR = ',',
			ROWTERMINATOR = '\n',
			CODEPAGE = 'ACP',
			DATAFILETYPE = 'Char'
		);


BACKUP DATABASE odirlei_lanhouse_saep
	TO DISK = 'C:\bd\Lanhouse - SAEP.BAK';
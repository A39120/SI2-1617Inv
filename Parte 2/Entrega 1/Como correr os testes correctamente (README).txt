Para correr os testes correctamente:

Notas:
	- Se a tabela já está criada não é preciso fazer o passo 'adicionar Procedures e Views', mesmo após resets
	- Depois da execução dos testes em ADO.NET ou EntityFramework é necessário restaurar o estado inicial da BD e executar AppTests.sql

Testar ADO.NET:
	0- NÃO ter usado POPULAR_TABELAS.sql (caso tenha sido usado será esmagado pelo passo seguinte com CRIAR_TABELAS.sql)
	1- Executar CRIAR_TABELAS.sql + adicionar Procedures e Views
	2- Executar AppTests.sql
	3- No Visual Studio abrir o test explorer (TEST > Windows > Test Explorer)
	4- Seleccionar os métodos de teste com o prefixo 'Ado_'
	5- Correr os testes seleccionados

Testar EF: 
	Mesmo de cima mas no passo 4 tem que ter o prefixo 'Ef_'

Testes de Comparação:
	1- Executar CRIAR_TABELAS.sql + adicionar Procedures e Views
	2- Executar POPULAR_TABELAS.sql
	3- Seleccionar os métodos que não têm os prefixos 'Ado_' e 'Ef_'
	4- Correr os testes seleccionados
Para correr os testes correctamente:

Notas:
	- Se a tabela já está criada não é preciso fazer o passo 'adicionar Procedures e Views', mesmo após resets

Testar ADO.NET:
	0- NÃO ter usado POPULAR_TABELAS.sql (caso tenha sido usado será esmagado pelo passo seguinte com CRIAR_TABELAS.sql)
	1- Executar CRIAR_TABELAS.sql + adicionar Procedures e Views
	2- Executar AppTests.sql
	3- Seleccionar os métodos de teste com o prefixo 'Ado_'
	4- Correr os testes seleccionados

Testar EF: 
	Mesmo de cima mas no passo 3 tem que ter o prefixo 'Ef_'

Testes de Comparação:
	1- Executar CRIAR_TABELAS.sql + adicionar Procedures e Views
	2- Executar POPULAR_TABELAS.sql
	3- Seleccionar os métodos que não têm os prefixos 'Ado_' e 'Ef_'
	4- Correr os testes seleccionados
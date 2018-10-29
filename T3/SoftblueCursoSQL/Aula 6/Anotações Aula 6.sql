USE curso_sql;

SELECT COUNT(*) AS Contador FROM funcionarios;

SELECT * FROM funcionarios;

SELECT COUNT(*) AS Contador FROM funcionarios WHERE salario >= 1500;
SELECT COUNT(*) AS Contador FROM funcionarios WHERE salario >= 1500 AND departamento = 'Juridico';

SELECT SUM(salario) AS 'Total Salários' FROM funcionarios;
SELECT SUM(salario) AS 'Total Salários' FROM funcionarios WHERE departamento = 'TI';

SELECT AVG(salario) AS 'Média Salarial' FROM funcionarios;
SELECT AVG(salario) AS 'Média Salarial TI' FROM funcionarios WHERE departamento = 'TI';

SELECT nome, salario FROM funcionarios WHERE salario IN (SELECT MAX(salario) FROM funcionarios);
SELECT MAX(salario) FROM funcionarios WHERE departamento = "TI";

SELECT MIN(salario) FROM funcionarios;
SELECT MIN(salario) FROM funcionarios WHERE departamento = "TI";

SELECT DISTINCT(departamento) FROM funcionarios;
SELECT departamento FROM funcionarios;

SELECT * FROM funcionarios ORDER BY salario;
SELECT * FROM funcionarios ORDER BY salario DESC;
SELECT * FROM funcionarios ORDER BY departamento, salario DESC;

SELECT * FROM funcionarios LIMIT 2;
SELECT * FROM funcionarios LIMIT 1, 2;

SELECT AVG(salario) FROM funcionarios GROUP BY departamento;

SELECT departamento, AVG(salario) FROM funcionarios GROUP BY departamento HAVING AVG(SALARIO) > 2000;
SELECT departamento, COUNT(*) FROM funcionarios GROUP BY departamento;

SELECT nome FROM funcionarios WHERE departamento IN ('Juridico');

SELECT nome FROM funcionarios WHERE departamento IN
	(
		SELECT departamento FROM funcionarios GROUP BY departamento HAVING AVG(SALARIO) > 2000
	);
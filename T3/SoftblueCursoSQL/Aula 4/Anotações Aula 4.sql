USE curso_sql;

INSERT INTO funcionarios (id, nome, salario, departamento) VALUES (1, 'Alguém', 1400, 'TI');

SELECT * FROM funcionarios;

INSERT INTO funcionarios (id, nome, salario, departamento) VALUES (2, 'Outro Alguém', 2000, 'Jurídico');

INSERT INTO funcionarios (nome, salario, departamento) VALUES ('Maria', 1800, 'Jurídico');

SELECT * FROM funcionarios WHERE salario >= 2000;

SELECT * FROM funcionarios ORDER BY salario ASC;

SELECT * FROM funcionarios WHERE nome = 'Joãozinho';

UPDATE funcionarios SET salario = salario * 1.1  WHERE id = 1;

SET SQL_SAFE_UPDATES = 1; /*<- Ativa*/
SET SQL_SAFE_UPDATES = 0; /*<- Desativa*/

UPDATE funcionarios SET salario = ROUND(salario * 1.1, 2);

DELETE FROM funcionarios WHERE id = 4;

INSERT INTO veiculos (funcionario_id, veiculo, placa) VALUES (1, "Carro", "SBA-0001");

INSERT INTO veiculos (funcionario_id, veiculo, placa) VALUES (1, "Carro", "SBA-0002");

SELECT * FROM veiculos;

UPDATE veiculos SET funcionario_id = 5 WHERE id = 2;

INSERT INTO salarios (faixa, inicio, fim) VALUES ('Analista Jr.', 1000, 2000);
INSERT INTO salarios (faixa, inicio, fim) VALUES ('Analista Pleno', 2000, 4000);

SELECT salario AS pagode, nome AS sortudo FROM funcionarios f WHERE f.salario > 2000;

SELECT * FROM funcionarios WHERE nome = "Alguém"
UNION
SELECT * FROM funcionarios WHERE id = 5;

SELECT * FROM funcionarios WHERE nome = "Alguém"
UNION ALL
SELECT * FROM funcionarios WHERE id = 1;


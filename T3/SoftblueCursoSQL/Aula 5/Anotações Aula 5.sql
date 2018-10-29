USE curso_sql;

INSERT INTO veiculos (funcionario_id, veiculo, placa) VALUES (2, "Carro", "ABC-1234");
INSERT INTO veiculos (funcionario_id, veiculo, placa) VALUES (3, "Carro 2", "ZCK-2334");
INSERT INTO veiculos (funcionario_id, veiculo, placa) VALUES (5, "Carro 3", "OPQ-4001");

SELECT * FROM funcionarios;
SELECT * FROM veiculos;

SELECT * FROM funcionarios f INNER JOIN veiculos v ON v.funcionario_id = f.id;

SELECT * FROM funcionarios f LEFT JOIN veiculos v ON v.funcionario_id = f.id
UNION /*MySQL não possui o comando FULL JOIN! */
SELECT * FROM funcionarios f RIGHT JOIN veiculos v ON v.funcionario_id = f.id;

CREATE TABLE cpfs 
(
	id INT UNSIGNED NOT NULL,
    cpf VARCHAR(14) NOT NULL,
    PRIMARY KEY (id),
    CONSTRAINT fk_cpf FOREIGN KEY (id) REFERENCES funcionarios (id)
);

INSERT INTO cpfs (id, cpf) VALUES (1, "111.111.111-11");
INSERT INTO cpfs (id, cpf) VALUES (2, "222.222.222-22");
INSERT INTO cpfs (id, cpf) VALUES (3, "333.333.333-33");
INSERT INTO cpfs (id, cpf) VALUES (5, "555.555.555-55");

SELECT * FROM cpfs;

SELECT * FROM funcionarios INNER JOIN cpfs ON funcionarios.id = cpfs.id;
SELECT * FROM funcionarios INNER JOIN cpfs USING (id); /* Equi Join - Campo em comum*/

CREATE TABLE clientes
(
	id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    nome VARCHAR(45) NOT NULL,
    quem_indicou INT UNSIGNED,
    PRIMARY KEY (id),
    CONSTRAINT fk_quem_indicou FOREIGN KEY (quem_indicou) REFERENCES clientes (id)
);

INSERT INTO clientes (id, nome, quem_indicou) VALUES (1, "Joãozinho", NULL);
INSERT INTO clientes (id, nome, quem_indicou) VALUES (2, "Pedrimho", 1);
INSERT INTO clientes (id, nome, quem_indicou) VALUES (3, "Mariazinha", 2);
INSERT INTO clientes (id, nome, quem_indicou) VALUES (4, "Paulinha", 1);

SELECT * FROM clientes;

SELECT c1.nome AS Cliente, c2.nome AS 'Indicado Por' FROM clientes c1 
INNER JOIN clientes c2 ON c1.quem_indicou = c2.id
UNION
SELECT c1.nome AS Cliente, IFNULL(c2.nome, "Ninguém") AS 'Indicado Por' FROM clientes c1 
LEFT JOIN clientes c2 ON c1.quem_indicou = c2.id;

SELECT * FROM funcionarios
INNER JOIN veiculos ON veiculos.funcionario_id = funcionarios.id
INNER JOIN cpfs on funcionarios.id = cpfs.id;

CREATE VIEW funcionario_a AS SELECT * FROM funcionarios WHERE salario >= 1500;

DROP VIEW funcionario_a;

SELECT * FROM funcionario_a;

UPDATE funcionarios SET salario = 1500 WHERE id = 3;

CREATE VIEW funcionario_join AS SELECT c1.nome AS Cliente, c2.nome AS 'Indicado Por' FROM clientes c1 
INNER JOIN clientes c2 ON c1.quem_indicou = c2.id
UNION
SELECT c1.nome AS Cliente, IFNULL(c2.nome, "Ninguém") AS 'Indicado Por' FROM clientes c1 
LEFT JOIN clientes c2 ON c1.quem_indicou = c2.id;

SELECT * FROM funcionario_join;

CREATE TABLE instrutores
(
	id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    nome VARCHAR(45) NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE cursos
(
	id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    ins INT UNSIGNED,
    titulo VARCHAR(45) NOT NULL,
    PRIMARY KEY (id),
    CONSTRAINT fk_instrutor FOREIGN KEY (ins) REFERENCES instrutores (id)
);

INSERT INTO instrutores (nome) VALUES ('André');
INSERT INTO instrutores (nome) VALUES ('Carlos');
INSERT INTO instrutores (nome) VALUES ('Samuel');
INSERT INTO instrutores (nome) VALUES ('Fábio');

INSERT INTO cursos (ins, titulo) VALUES (1, 'Java');
INSERT INTO cursos (ins, titulo) VALUES (NULL, 'PHP');
INSERT INTO cursos (ins, titulo) VALUES (1, 'MySQL');
INSERT INTO cursos (ins, titulo) VALUES (3, 'SQL');
INSERT INTO cursos (ins, titulo) VALUES (2, 'C++');

SELECT * FROM instrutores LEFT JOIN cursos ON instrutores.id = cursos.ins
UNION
SELECT * FROM instrutores RIGHT JOIN cursos ON instrutores.id = cursos.ins;
SELECT * FROM instrutores INNER JOIN cursos ON instrutores.id = cursos.ins;
USE curso_sql;

CREATE TABLE pedidos
(
	id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    descricao VARCHAR(100) NOT NULL,
    valor DOUBLE NOT NULL DEFAULT '0',
    pago VARCHAR(3) NOT NULL DEFAULT 'Não',
    PRIMARY KEY (id)
);

INSERT INTO pedidos (descricao, valor) VALUES ('TV', 2000);
INSERT INTO pedidos (descricao, valor) VALUES ('Geladeira', 500);
INSERT INTO pedidos (descricao, valor) VALUES ('DVD Player', 200);

SELECT * FROM pedidos;

CALL limpa_pedidos();

CREATE TABLE estoque
(
	id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    descricao VARCHAR(50) NOT NULL,
    quantidade INT NOT NULL,
    PRIMARY KEY (id)
);

CREATE TRIGGER gatilho_limpa_pedidos
BEFORE INSERT ON estoque
FOR EACH ROW
CALL limpa_pedidos();

INSERT INTO estoque (descricao, quantidade) VALUES ('Fogão', 5);

SELECT * FROM estoque;

UPDATE pedidos SET pago = "Sim" WHERE id = 14;

INSERT INTO estoque (descricao, quantidade) VALUES ('Forno', 3);
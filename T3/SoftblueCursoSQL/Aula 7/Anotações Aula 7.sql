CREATE USER 'admin'@'200.200.190.190' IDENTIFIED BY 'admin';
CREATE USER 'admin'@'%' IDENTIFIED BY 'admin';
CREATE USER 'admin'@'localhost' IDENTIFIED BY 'admin';

GRANT ALL ON curso_sql.* TO 'admin'@'localhost';

GRANT SELECT, INSERT ON curso_sql.* TO 'admin'@'localhost';

GRANT SELECT ON curso_sql.* TO 'admin'@'%';

GRANT INSERT ON curso_sql.funcionarios TO 'admin'@'%';

REVOKE INSERT ON curso_sql.funcionarios FROM 'admin'@'%';

REVOKE SELECT ON curso_sql.* FROM 'admin'@'%';

GRANT SELECT ON curso_sql.funcionarios TO 'admin'@'localhost';

GRANT SELECT ON curso_sql.veiculos TO 'admin'@'localhost';

REVOKE SELECT ON curso_sql.funcionarios FROM 'admin'@'localhost';
REVOKE SELECT ON curso_sql.veiculos FROM 'admin'@'localhost';

REVOKE ALL ON curso_sql.* FROM 'admin'@'localhost';

DROP USER 'admin'@'%';
DROP USER 'admin'@'localhost';

SELECT User FROM mysql.User;

SHOW GRANTS FOR 'admin'@'%';
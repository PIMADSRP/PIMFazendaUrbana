### COMANDOS PARA TESTE:

# insert
INSERT into funcionario (nome_funcionario, sexo_funcionario, email_funcionario, cargo_funcionario, usuario_funcionario, senha_funcionario) 
values ('nomefuncionarioteste', 'masculino', 'funcionarioteste@gmail.com', 'gerente', 'nomedeusuarioteste', 'senhateste');

INSERT into enderecofuncionario (logradouro_endfuncionario, numero_endfuncionario, complemento_endfuncionario, bairro_endfuncionario, cidade_endfuncionario, uf_endfuncionario, cep_endfuncionario, id_funcionario) 
values ('rua 1', '11', 'ap 1', 'bairro 1', 'cidade 1', 'SP', '11111111', '1');

INSERT into telefonefuncionario (ddd_telfuncionario, numero_telfuncionario, id_funcionario) 
values ('11', '11111111', '1');

## update
update cliente set nome_cliente = 'aaaaaaaaaaa' where id_cliente = 7;

update funcionario set nome_funcionario = 'bbbbbbbb' where id_funcionario = 8;

UPDATE funcionario SET cargo_funcionario = 'funcionário' WHERE usuario_funcionario = 'nomedeusuarioteste';
UPDATE funcionario SET ativo_funcionario = 1 WHERE id_funcionario = 6;
UPDATE funcionario SET sexo_funcionario = 'M' WHERE id_funcionario = 1;

UPDATE funcionario SET 
nome_funcionario = 'aaaaaaaa',
sexo_funcionario = 'F',
email_funcionario = 'aaaaa@aaaa.aaa',
cargo_funcionario = 'Gerente',
usuario_funcionario = 'aaaaaaaauser'
WHERE id_funcionario = 7;
UPDATE endereco_funcionario SET 
logradouro_endfuncionario = 'rua aaaa',
numero_endfuncionario = '123',
complemento_endfuncionario = 'ap 123',
bairro_endfuncionario = 'bairro aaa',
cidade_endfuncionario = 'cidade aaa',
uf_endfuncionario = 'SP',
cep_endfuncionario = '87654321'
WHERE id_funcionario = 7;
UPDATE telefone_funcionario SET 
ddd_telfuncionario = '12',
numero_telfuncionario = '123456789'
WHERE id_funcionario = 7;

## select
select * from cliente;
select * from enderecocliente;
select * from telefonecliente;

select * from fornecedor;
select * from enderecofornecedor;
select * from telefonefornecedor;

select * from funcionario;
select * from enderecofuncionario;
select * from telefonefuncionario;

SELECT COUNT(*) FROM funcionario WHERE usuario_funcionario = 'luiz1231';
SELECT COUNT(*) FROM funcionario WHERE usuario_funcionario = 'asdasd';

SELECT senha_funcionario, ativo_funcionario FROM funcionario WHERE usuario_funcionario = 'igor123';

SELECT f.id_funcionario, f.nome_funcionario, f.sexo_funcionario, f.email_funcionario, f.cargo_funcionario, 
f.usuario_funcionario, f.ativo_funcionario, 
t.ddd_telfuncionario, t.numero_telfuncionario, t.ativo_telfuncionario, 
e.logradouro_endfuncionario, e.numero_endfuncionario, e.complemento_endfuncionario, e.bairro_endfuncionario, e.cidade_endfuncionario, 
e.uf_endfuncionario, e.cep_endfuncionario, e.ativo_endfuncionario
FROM funcionario f
LEFT JOIN telefonefuncionario t ON f.id_funcionario = t.id_funcionario
LEFT JOIN enderecofuncionario e ON f.id_funcionario = e.id_funcionario
;

SELECT f.id_funcionario, f.nome_funcionario, f.sexo_funcionario, f.email_funcionario, f.cargo_funcionario, 
f.usuario_funcionario, f.ativo_funcionario, 
t.ddd_telfuncionario, t.numero_telfuncionario, t.ativo_telfuncionario, 
e.logradouro_endfuncionario, e.numero_endfuncionario, e.complemento_endfuncionario, e.bairro_endfuncionario, e.cidade_endfuncionario, 
e.uf_endfuncionario, e.cep_endfuncionario, e.ativo_endfuncionario
FROM funcionario f
LEFT JOIN telefonefuncionario t ON f.id_funcionario = t.id_funcionario
LEFT JOIN enderecofuncionario e ON f.id_funcionario = e.id_funcionario
WHERE f.ativo_funcionario = true;

select * from cultivo;
select * from recomendacaocultivo;

## describe
describe cliente;
describe enderecocliente;
describe telefonecliente;

describe fornecedor;
describe enderecofornecedor;
describe telefonefornecedor;

describe funcionario;
describe enderecofuncionario;
describe telefonefuncionario;

## delete
DELETE FROM telefonecliente;
DELETE FROM enderecocliente;
DELETE FROM cliente;

DELETE FROM telefonefornecedor;
DELETE FROM enderecofornecedor;
DELETE FROM fornecedor;

DELETE FROM telefonefuncionario;
DELETE FROM enderecofuncionario;
DELETE FROM funcionario;

## truncate
TRUNCATE TABLE enderecocliente;
TRUNCATE TABLE telefonecliente;
TRUNCATE TABLE cliente;

TRUNCATE TABLE enderecofornecedor;
TRUNCATE TABLE telefonefornecedor;
TRUNCATE TABLE fornecedor;

TRUNCATE TABLE enderecofuncionario;
TRUNCATE TABLE telefonefuncionario;
TRUNCATE TABLE funcionario;

## drop
DROP TABLE telefonecliente;
DROP TABLE enderecocliente;
DROP TABLE cliente;

DROP TABLE telefonefornecedor;
DROP TABLE enderecofornecedor;
DROP TABLE fornecedor;

DROP TABLE enderecofuncionario;
DROP TABLE telefonefuncionario;
DROP TABLE funcionario;

### CRIAÇÃO DO BANCO:
CREATE DATABASE testepim;
USE testepim;

## Cliente:
CREATE TABLE `cliente` (
  `id_cliente` int NOT NULL AUTO_INCREMENT,
  `nome_cliente` varchar(255) DEFAULT NULL,
  `email_cliente` varchar(255) DEFAULT NULL,
  `cnpj_cliente` varchar(255) DEFAULT NULL,
  `ativo_cliente` boolean DEFAULT true,
  PRIMARY KEY (`id_cliente`)
);
CREATE TABLE `endereco_cliente` (
  `id_endcliente` int NOT NULL AUTO_INCREMENT,
  `logradouro_endcliente` varchar(255) DEFAULT NULL,
  `numero_endcliente` varchar(255) DEFAULT NULL,
  `complemento_endcliente` varchar(255) DEFAULT NULL,
  `bairro_endcliente` varchar(255) DEFAULT NULL,
  `cidade_endcliente` varchar(255) DEFAULT NULL,
  `uf_endcliente` varchar(255) DEFAULT NULL,
  `cep_endcliente` varchar(255) DEFAULT NULL,
  `ativo_endcliente` boolean DEFAULT true,
  `id_cliente` int NOT NULL,
  PRIMARY KEY (`id_endcliente`),
  KEY `id_cliente` (`id_cliente`),
  CONSTRAINT `endereco_cliente_ibfk_1` FOREIGN KEY (`id_cliente`) REFERENCES `cliente` (`id_cliente`)
);
CREATE TABLE `telefone_cliente` (
  `id_telcliente` int NOT NULL AUTO_INCREMENT,
  `ddd_telcliente` varchar(255) DEFAULT NULL,
  `numero_telcliente` varchar(255) DEFAULT NULL,
  `ativo_telcliente` boolean DEFAULT true,
  `id_cliente` int NOT NULL,
  PRIMARY KEY (`id_telcliente`),
  KEY `id_cliente` (`id_cliente`),
  CONSTRAINT `telefone_cliente_ibfk_1` FOREIGN KEY (`id_cliente`) REFERENCES `cliente` (`id_cliente`)
);

## Fornecedor:
CREATE TABLE `fornecedor` (
  `id_fornecedor` int NOT NULL AUTO_INCREMENT,
  `nome_fornecedor` varchar(255) DEFAULT NULL,
  `email_fornecedor` varchar(255) DEFAULT NULL,
  `cnpj_fornecedor` varchar(255) DEFAULT NULL,
  `ativo_fornecedor` boolean DEFAULT true,
  PRIMARY KEY (`id_fornecedor`)
);
CREATE TABLE `endereco_fornecedor` (
  `id_endfornecedor` int NOT NULL AUTO_INCREMENT,
  `logradouro_endfornecedor` varchar(255) DEFAULT NULL,
  `numero_endfornecedor` varchar(255) DEFAULT NULL,
  `complemento_endfornecedor` varchar(255) DEFAULT NULL,
  `bairro_endfornecedor` varchar(255) DEFAULT NULL,
  `cidade_endfornecedor` varchar(255) DEFAULT NULL,
  `uf_endfornecedor` varchar(255) DEFAULT NULL,
  `cep_endfornecedor` varchar(255) DEFAULT NULL,
  `ativo_endfornecedor` boolean DEFAULT true,
  `id_fornecedor` int NOT NULL,
  PRIMARY KEY (`id_endfornecedor`),
  KEY `id_fornecedor` (`id_fornecedor`),
  CONSTRAINT `endereco_fornecedor_ibfk_1` FOREIGN KEY (`id_fornecedor`) REFERENCES `fornecedor` (`id_fornecedor`)
);
CREATE TABLE `telefone_fornecedor` (
  `id_telfornecedor` int NOT NULL AUTO_INCREMENT,
  `ddd_telfornecedor` varchar(255) DEFAULT NULL,
  `numero_telfornecedor` varchar(255) DEFAULT NULL,
  `ativo_telfornecedor` boolean DEFAULT true,
  `id_fornecedor` int NOT NULL,
  PRIMARY KEY (`id_telfornecedor`),
  KEY `id_fornecedor` (`id_fornecedor`),
  CONSTRAINT `telefone_fornecedor_ibfk_1` FOREIGN KEY (`id_fornecedor`) REFERENCES `fornecedor` (`id_fornecedor`)
);

## Funcionario:
CREATE TABLE `funcionario` (
  `id_funcionario` int NOT NULL AUTO_INCREMENT,
  `nome_funcionario` varchar(255) DEFAULT NULL,
  `sexo_funcionario` varchar(255) DEFAULT NULL,
  `email_funcionario` varchar(255) DEFAULT NULL,
  `cargo_funcionario` varchar(255) DEFAULT NULL,
  `usuario_funcionario` varchar(255) DEFAULT NULL,
  `credenciais_funcionario` varchar(255) DEFAULT NULL,
  `ativo_funcionario` boolean DEFAULT true,
  PRIMARY KEY (`id_funcionario`)
);
CREATE TABLE `endereco_funcionario` (
  `id_endfuncionario` int NOT NULL AUTO_INCREMENT,
  `logradouro_endfuncionario` varchar(255) DEFAULT NULL,
  `numero_endfuncionario` varchar(255) DEFAULT NULL,
  `complemento_endfuncionario` varchar(255) DEFAULT NULL,
  `bairro_endfuncionario` varchar(255) DEFAULT NULL,
  `cidade_endfuncionario` varchar(255) DEFAULT NULL,
  `uf_endfuncionario` varchar(255) DEFAULT NULL,
  `cep_endfuncionario` varchar(255) DEFAULT NULL,
  `ativo_endfuncionario` boolean DEFAULT true,
  `id_funcionario` int NOT NULL,
  PRIMARY KEY (`id_endfuncionario`),
  KEY `id_funcionario` (`id_funcionario`),
  CONSTRAINT `endereco_funcionario_ibfk_1` FOREIGN KEY (`id_funcionario`) REFERENCES `funcionario` (`id_funcionario`)
);
CREATE TABLE `telefone_funcionario` (
  `id_telfuncionario` int NOT NULL AUTO_INCREMENT,
  `ddd_telfuncionario` varchar(255) DEFAULT NULL,
  `numero_telfuncionario` varchar(255) DEFAULT NULL,
  `ativo_telfuncionario` boolean DEFAULT true,
  `id_funcionario` int NOT NULL,
  PRIMARY KEY (`id_telfuncionario`),
  KEY `id_funcionario` (`id_funcionario`),
  CONSTRAINT `telefone_funcionario_ibfk_1` FOREIGN KEY (`id_funcionario`) REFERENCES `funcionario` (`id_funcionario`)
);


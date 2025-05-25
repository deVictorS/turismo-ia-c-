CREATE DATABASE turismo;

CREATE TABLE cliente (
id INT AUTO_INCREMENT PRIMARY KEY,
nome VARCHAR(100),
genero VARCHAR(1),
nacionalidade VARCHAR(50),
telefone VARCHAR(20),
dataNasc VARCHAR(20),
cpf VARCHAR(14),
rg VARCHAR(20),
passaporte VARCHAR(20),
cep VARCHAR(10),
rua VARCHAR(100),
bairro VARCHAR(50),
cidade VARCHAR(50),
estado VARCHAR(50),
pais VARCHAR(50),
preferencias TEXT
);

CREATE TABLE pacote (
id INT AUTO_INCREMENT PRIMARY KEY,
origem VARCHAR(50),
destino VARCHAR(50),
dataIda VARCHAR(20),
horaIda VARCHAR(10),
dataVolta VARCHAR(20),
horaVolta VARCHAR(10),
valor VARCHAR(20),
parcelamento VARCHAR(10),
descricao TEXT
);


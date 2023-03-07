drop database dbClinicaMedica;

create database dbClinicaMedica;

use dbClinicaMedica;

create table tbPaciente(
codPac int not null auto_increment,
nome varchar(100) not null,
email varchar(100),
telefone char(14),
cpf char(14) not null,
endereco varchar(100),
numero char(10),
cep char(8),
complemento varchar(50),
bairro varchar(50),
cidade varchar(50),
siglaEst char(2),
primary key(codPac));

create table tbUsuarios(
cdoUsu int not null auto_increment,
nomeUsu varchar(20) not null,
senhaUsu varchar(20) not null,
primary key (cdoUsu)
);

update tbPaciente set nome = "", email = "", telefone = "", cpf= "", endereco="", numero="", cep="", complemento="", bairro="", cidade="", siglaEst="" where codpac = 1;

insert into tbPaciente(nome,email,telefone,cpf,
	endereco,numero,cep,complemento,bairro,cidade,
	siglaEst) values('Senac','senac@senac.com',
	'(11) 98574-8582','560.054.738-24','Rua Dr. Antonio Bento','377',
	'04750000','casa','Santo Amaro','São Paulo','sp');
insert into tbUsuarios(nomeUsu,senhaUsu) values ('senac', 'senac');
insert into tbUsuarios(nomeUsu,senhaUsu) values ('admin', 'admin');
insert into tbUsuarios(nomeUsu,senhaUsu) values ('visitante', '123456');


select * from tbUsuarios where nomeUsu = 'senac' and senhaUsu = 'senac'

-- Pesquisa por nome

select * from tbPaciente where nome like '%s%';


-- Pesquisa por código

select * from tbPaciente where codpac = 4;


delete from tbPaciente where codpac = 1;


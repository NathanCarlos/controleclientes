create database ATIVIDADEAVALIATIVA;

GO
use ATIVIDADEAVALIATIVA;

GO
create table status_cliente(

id_status int primary key identity,
desc_status varchar(7)
);
GO
insert into status_cliente(desc_status) values('ATIVO'),
('INATIVO');

GO
create table cliente(
id_cli int primary key identity,
nome_cli varchar(255) not null,
endereco_cli varchar(255) not null,
email_cli varchar(255),
telefone_cli varchar(15),
status_cli int not null,
CONSTRAINT status_cli_fk FOREIGN KEY(status_cli) REFERENCES status_cliente
);

drop database ATIVIDADEAVALIATIVA;

select * from cliente

delete from cliente;
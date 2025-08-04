create database estoque;

use estoque;

create table produto(
	id_produto int primary key auto_increment,
	nome varchar(45) not null,
    quantidade int not null,
    preco double not null,
    categoria varchar(45) not null
);

select * from produto;

delete  from produto where id_produto = 1;
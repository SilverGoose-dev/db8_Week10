create database bookclub;
use bookclub;

create table Person (
id int not null Auto_increment,
firstname varchar(50),
lastname varchar(50),
email varchar(50),
primary key (id)
);

create table Presentation (
id int not null auto_increment,
personid int,
presentationdate datetime,
booktitle varchar(50),
bookauthore varchar(50),
genre varchar(50),
primary key (id),
foreign key (personid) references person(id)
);
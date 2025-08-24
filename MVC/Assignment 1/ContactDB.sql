create database ContactDB

use ContactDB

create table Contacts
(Id bigint identity(1,1) primary key,
FirstName varchar(30) not null,
LastName varchar(30) not null,
Email varchar(30) not null)
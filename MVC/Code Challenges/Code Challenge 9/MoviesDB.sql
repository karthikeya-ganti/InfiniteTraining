create database MoviesDB

use MoviesDB

create table Movies
(Mid int identity(1,1) primary key,
Moviename varchar(20) not null,
DirectorName varchar(20) not null,
DateofRelease date not null)
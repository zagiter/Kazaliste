SELECT name, collation_name FROM sys.databases;
GO
ALTER DATABASE db_aa69bf_kazaliste SET SINGLE_USER WITH
ROLLBACK IMMEDIATE;
GO
ALTER DATABASE db_aa69bf_kazaliste COLLATE Croatian_CI_AS;
GO
ALTER DATABASE db_aa69bf_kazaliste SET MULTI_USER;
GO
SELECT name, collation_name FROM sys.databases;
GO


create table predstave (
    sifra int not null primary key identity(1,1),
    naziv varchar(255) not null,
    datum varchar(50),
    cijena varchar(50),
);

create table kupci (
    sifra int not null primary key identity(1,1),
    ime varchar(50) not null,
    prezime varchar(50) not null,
    email varchar(100),
    telefon varchar(20)
);

create table kupovine (
    sifra int not null primary key identity(1,1),
    kupac_sifra int not null,
    predstava_sifra int not null,
    broj_sjedala int not null,
    
	foreign key (kupac_sifra) references kupci(sifra),
    foreign key (predstava_sifra) references predstave(sifra)
);


insert into predstave (naziv, datum, cijena) values 
('Vesela udovica', '2024-03-19 18:00:00', 15.00),
('Maratonci trče počasni krug', '2024-03-21 19:00:00', 15.00);


insert into kupci (ime, prezime, email, telefon) values 
('Ivana', 'Ivić', 'ivanai@nekimail.com', '123456789'),
('Marko', 'Markić', 'markom@nekimail.com', '234567891'),
('Pero', 'Perić', 'perop@nekimail.com', '313131313');


insert into kupovine (kupac_sifra, predstava_sifra, broj_sjedala) values 
(1, 2, 2),
(3, 1, 1),      
(2, 1, 4);

select * from predstave
select * from kupci
select * from kupovine
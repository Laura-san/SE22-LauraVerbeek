-- 64 Bits
-- Version 4.0.1.14
-- Laura Verbeek S24

DROP TABLE acteur       CASCADE CONSTRAINTS;
DROP TABLE film         CASCADE CONSTRAINTS;
DROP TABLE filmografie  CASCADE CONSTRAINTS;
DROP TABLE genre        CASCADE CONSTRAINTS;
DROP TABLE recensie     CASCADE CONSTRAINTS;
DROP TABLE gebruiker    CASCADE CONSTRAINTS;
DROP TABLE medewerker   CASCADE CONSTRAINTS;
DROP TABLE gast         CASCADE CONSTRAINTS;
DROP TABLE filmserie    CASCADE CONSTRAINTS;

DROP SEQUENCE seq_acteur;
DROP SEQUENCE seq_filmografie;
DROP SEQUENCE seq_film;
DROP SEQUENCE seq_recensie;
DROP SEQUENCE seq_gebruiker;

CREATE TABLE acteur
(acteurID       int             NOT NULL  PRIMARY KEY,
naam            varchar2(100),
biografie       varchar2(350),
geboortedatum   date);

CREATE TABLE film
(filmID             number(10)      PRIMARY KEY   NOT NULL,
titel               varchar2(100)   NOT NULL,
releaseDatum        date,
omschrijving        varchar2(350),
genre               varchar2(100),
vorigeFilm          varchar2(100),
volgendeFilm        varchar2(100),
leeftijdgrens       varchar2(3)     CHECK(leeftijdgrens=null or leeftijdgrens='16+' or leeftijdgrens='18+'),
sex                 varchar2(5)     NOT NULL      CHECK(sex='True' or sex='False'),
geweld              varchar2(5)     NOT NULL      CHECK(geweld='True' or geweld='False'),
discriminatie       varchar2(5)     NOT NULL      CHECK(discriminatie='True' or discriminatie='False'),
drugAlcoholGebruik  varchar2(5)     NOT NULL      CHECK(drugAlcoholGebruik='True' or drugAlcoholGebruik='False'),
angst               varchar2(5)     NOT NULL      CHECK(angst='True' or angst='False'));

CREATE TABLE filmserie
(filmA  number(10),
filmB   number(10),
FOREIGN KEY (filmA) REFERENCES film(filmID),
FOREIGN KEY (filmB) REFERENCES film(filmID),
PRIMARY KEY (filmA, filmB)
);

CREATE TABLE filmografie
(filmografieNummer  number(10)  PRIMARY KEY   NOT NULL,
acteur              number(10)  NOT NULL,
film                number(10)  NOT NULL,
FOREIGN KEY (acteur)  REFERENCES acteur(acteurID),
FOREIGN KEY (film)    REFERENCES film(filmID));

CREATE TABLE genre
(genreCode    varchar2(100)   PRIMARY KEY   NOT NULL,
omschrijving  varchar2(100));

CREATE TABLE recensie
(recensieNummer   number(10)      PRIMARY KEY   NOT NULL,
geplaatstDoor     varchar2(100),
cijfer            number(2)       check(cijfer>=0 and cijfer<=10),
beoordeling       varchar2(100),
film              number(10));

CREATE TABLE gebruiker
(gebruikersID   number(10)      PRIMARY KEY   NOT NULL,
soort           varchar2(100)   NOT NULL      CHECK(soort='medewerker' or soort='gast'),
gebruikersNaam  varchar2(100)   NOT NULL      UNIQUE,
wachtwoord      varchar2(100),
voornaam        varchar2(100),
achternaam      varchar2(100),
geboortedatum   date);

CREATE TABLE medewerker
(gebruikersID   number(10)   PRIMARY KEY    NOT NULL,
aangenomenOp    Date,
salaris         number(10),
postcode        varchar2(100),
woonplaats      varchar2(100));

CREATE TABLE gast
(gebruikersID   number(38)      PRIMARY KEY   NOT NULL,
eMail           varchar2(100)   UNIQUE,
lidNieuwsbrief  varchar2(1)     NOT NULL      CHECK(lidNieuwsbrief='y' or lidNieuwsbrief='n'));

ALTER TABLE film
ADD CONSTRAINT FK_Genre  FOREIGN KEY(genre) REFERENCES genre(genreCode);

ALTER TABLE recensie
ADD CONSTRAINT FK_plaatsingrecensie FOREIGN KEY(geplaatstDoor) REFERENCES gebruiker(gebruikersnaam);

ALTER TABLE recensie
ADD CONSTRAINT FK_recensiefilm FOREIGN KEY (film) REFERENCES film(filmID);

ALTER TABLE gast
ADD CONSTRAINT sub_gastgebruiker FOREIGN KEY(gebruikersID) REFERENCES gebruiker(gebruikersID);

ALTER TABLE medewerker
ADD CONSTRAINT sub_admingebruiker FOREIGN KEY(gebruikersID) REFERENCES gebruiker(gebruikersID);

CREATE SEQUENCE seq_acteur
MINVALUE      0
START WITH    0
INCREMENT BY  1
CACHE         10;

CREATE SEQUENCE seq_filmografie
MINVALUE      0
START WITH    0
INCREMENT BY  1
CACHE         10;

CREATE SEQUENCE seq_film
MINVALUE      0
START WITH    0
INCREMENT BY  1
CACHE         10;

CREATE SEQUENCE seq_recensie
MINVALUE      0
START WITH    0
INCREMENT BY  1
CACHE         10;

CREATE SEQUENCE seq_gebruiker
MINVALUE      0
START WITH    0
INCREMENT BY  1
CACHE         10;

INSERT INTO acteur(ACTEURID, NAAM, BIOGRAFIE, GEBOORTEDATUM)
VALUES (seq_acteur.nextval, 'Daniel Radcliffe',
'Daniel Jacob Radcliffe was born on July 23rd, 1989 to Alan Radcliffe and Marcia Gresham. His father is from a Northern Irish Protestant background, while his mother was born in South Africa, to a Jewish family (from Lithuania, Poland, Russia, and Germany). Daniel began performing in small school productions as a young boy.',
'23-07-89');

INSERT INTO acteur(ACTEURID, NAAM, BIOGRAFIE, GEBOORTEDATUM)
VALUES (seq_acteur.nextval, 'Emma Watson',
'Rupert Alexander Lloyd Grint was born the elder son of Nigel and Jo Grint. The first of 5 children, Rupert has one brother and 3 sisters. His brother James was born when Rupert was a year old, Georgina and Samantha were born in 1993 and 1996 respectively, and last, but not least, Charlotte, who was born in 1999.',
'24-06-88');

INSERT INTO acteur(ACTEURID, NAAM, BIOGRAFIE, GEBOORTEDATUM)
VALUES (seq_acteur.nextval, 'Rupert Grint',
'Emma Charlotte Duerre Watson was born in Paris, France to English parents, Jacqueline Luesby and Chris Watson, who are lawyers. When Emma was five her parents divorced, and she then moved to Oxfordshire, England with her mother and younger brother, Alexander. Since the divorce, Emmaas extended family has grown as her parents both have new partners.',
'15-04-90');

INSERT INTO acteur(ACTEURID, NAAM, BIOGRAFIE, GEBOORTEDATUM)
VALUES (seq_acteur.nextval, 'Shailene Woodley',
'Actress Shailene Woodley is the daughter of Lori and Lonnie Woodley. She has one brother, Tanner. She was educated at Simi Valley High School in California. When Woodley was four years old she began commercial modeling. Acting roles followed, and she made her screen debut in 1999',
'15-11-91');

INSERT INTO genre(GENRECODE, OMSCHRIJVING)
VALUES ('Drama', 'drama');

INSERT INTO genre(GENRECODE, OMSCHRIJVING)
VALUES ('Adventure', 'aventuur');

INSERT INTO genre(GENRECODE, OMSCHRIJVING)
VALUES ('Comedy', 'Humor');

INSERT INTO genre(GENRECODE, OMSCHRIJVING)
VALUES ('Humor', 'humor');

INSERT INTO film(FILMID, TITEL, RELEASEDATUM, OMSCHRIJVING, GENRE, VORIGEFILM, VOLGENDEFILM, LEEFTIJDGRENS, SEX, GEWELD, DISCRIMINATIE, DRUGALCOHOLGEBRUIK, ANGST)
VALUES (seq_film.nextval, 'Harry Potter and the Philosophers stone', '22-11-2001', 'Rescued from the outrageous neglect of his aunt and uncle, a young boy with a great destiny proves his worth while attending Hogwarts School of Witchcraft and Wizardry.', 'Adventure',
'' , 'Harry Potter and the chamber of secrets', '', 'False', 'True', 'True', 'False', 'False');

INSERT INTO film(FILMID, TITEL, RELEASEDATUM, OMSCHRIJVING, GENRE, VORIGEFILM, VOLGENDEFILM, LEEFTIJDGRENS, SEX, GEWELD, DISCRIMINATIE, DRUGALCOHOLGEBRUIK, ANGST)
VALUES (seq_film.nextval, 'Harry Potter and the chamber of secrets', '21-11-2002', 'Harry ignores warnings not to return to Hogwarts, only to find the school plagued by a series of mysterious attacks and a strange voice haunting him.',
'Adventure', 'Harry Potter and the Philosophers stone', 'Harry Potter and the prisoner of azkaban', '', 'False', 'True', 'False', 'False', 'False');

INSERT INTO film(FILMID, TITEL, RELEASEDATUM, OMSCHRIJVING, GENRE, VORIGEFILM, VOLGENDEFILM, LEEFTIJDGRENS, SEX, GEWELD, DISCRIMINATIE, DRUGALCOHOLGEBRUIK, ANGST)
VALUES (seq_film.nextval, 'Harry Potter and the prisoner of azkaban', '02-06-200', 'It is Harries third year at Hogwarts; not only does he have a new "Defense Against the Dark Arts" teacher, but there is also trouble brewing. Convicted murderer Sirius Black has escaped the Wizards Prison and is coming after Harry.',
'Drama','Harry Potter and the chamber of secrets', '', '', 'False', 'True', 'False', 'False', 'False');

INSERT INTO film(FILMID, TITEL, RELEASEDATUM, OMSCHRIJVING, GENRE, VORIGEFILM, VOLGENDEFILM, LEEFTIJDGRENS, SEX, GEWELD, DISCRIMINATIE, DRUGALCOHOLGEBRUIK, ANGST)
VALUES (seq_film.nextval, 'Divergent', '03-04-2014', 'In a world divided by factions based on virtues, Tris learns she is Divergent and would not fit in. When she discovers a plot to destroy Divergents, Tris and the mysterious Four must find out what makes Divergents dangerous before it is too late.',
'Humor','','', '', 'False', 'True', 'False', 'False', 'False');

INSERT INTO filmserie(FILMA, FILMB)
VALUES ('1', '2');

INSERT INTO filmserie(FILMA, FILMB)
VALUES ('2', '3');

INSERT INTO filmografie(FILMOGRAFIENUMMER, ACTEUR, FILM)
VALUES (seq_filmografie.nextval, '1', '1');

INSERT INTO filmografie(FILMOGRAFIENUMMER, ACTEUR, FILM)
VALUES (seq_filmografie.nextval, '1', '2');

INSERT INTO filmografie(FILMOGRAFIENUMMER, ACTEUR, FILM)
VALUES (seq_filmografie.nextval, '1', '3');

INSERT INTO filmografie(FILMOGRAFIENUMMER, ACTEUR, FILM)
VALUES (seq_filmografie.nextval, '2', '1');

INSERT INTO filmografie(FILMOGRAFIENUMMER, ACTEUR, FILM)
VALUES (seq_filmografie.nextval, '2', '2');

INSERT INTO filmografie(FILMOGRAFIENUMMER, ACTEUR, FILM)
VALUES (seq_filmografie.nextval, '2', '3');

INSERT INTO filmografie(FILMOGRAFIENUMMER, ACTEUR, FILM)
VALUES (seq_filmografie.nextval, '3', '1');

INSERT INTO filmografie(FILMOGRAFIENUMMER, ACTEUR, FILM)
VALUES (seq_filmografie.nextval, '3', '2');

INSERT INTO filmografie(FILMOGRAFIENUMMER, ACTEUR, FILM)
VALUES (seq_filmografie.nextval, '3', '3');

INSERT INTO filmografie(FILMOGRAFIENUMMER, ACTEUR, FILM)
VALUES (seq_filmografie.nextval, '4', '4');

INSERT INTO gebruiker(GEBRUIKERSID, SOORT, GEBRUIKERSNAAM, WACHTWOORD, VOORNAAM, ACHTERNAAM, GEBOORTEDATUM)
values (seq_gebruiker.nextval, 'medewerker', 'Admin', 'Admin', 'Laura', 'Verbeek', '05-07-92');

INSERT INTO gebruiker(GEBRUIKERSID, SOORT, GEBRUIKERSNAAM, WACHTWOORD, VOORNAAM, ACHTERNAAM, GEBOORTEDATUM)
values (seq_gebruiker.nextval, 'medewerker', 'Administrator', 'Admin', 'Steven', 'Thijssen', '09-11-90');

INSERT INTO gebruiker(GEBRUIKERSID, SOORT, GEBRUIKERSNAAM, WACHTWOORD, VOORNAAM, ACHTERNAAM, GEBOORTEDATUM)
values (seq_gebruiker.nextval, 'gast', 'Blackroses', 'Geheim', 'Truus', 'Jansen', '06-02-98');

INSERT INTO medewerker(GEBRUIKERSID, AANGENOMENOP, SALARIS, POSTCODE, WOONPLAATS)
VALUES ('1', '3-5-2000', '2000', '1234AB', 'Venlo');

INSERT INTO medewerker(GEBRUIKERSID, AANGENOMENOP, SALARIS, POSTCODE, WOONPLAATS)
VALUES ('2', '25-1-2008', '1000', '4321AB', 'Eindhoven');

INSERT INTO gast(GEBRUIKERSID, EMAIL, LIDNIEUWSBRIEF)
VALUES ('3', 'blackroses@gmail.com', 'n');

INSERT INTO recensie(RECENSIENUMMER, GEPLAATSTDOOR, CIJFER, BEOORDELING, FILM)
VALUES (seq_recensie.nextval, (select gebruikersnaam from gebruiker where gebruikersid = 3), '7', 'Super leuke film', '1');

INSERT INTO recensie(RECENSIENUMMER, GEPLAATSTDOOR, CIJFER, BEOORDELING, FILM)
VALUES (seq_recensie.nextval, (select gebruikersnaam from gebruiker where gebruikersid = 1), '5', 'Deze film is helemaal niets waard', '1');

COMMIT;
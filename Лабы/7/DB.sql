CREATE SCHEMA films;
use films;
CREATE TABLE country (
	country_id SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
	name VARCHAR(45) NOT NULL,
	PRIMARY KEY (country_id));
CREATE TABLE director (
	director_id MEDIUMINT UNSIGNED NOT NULL AUTO_INCREMENT,
	firstname VARCHAR(45) NOT NULL,
  	lastname VARCHAR(45) NOT NULL,
    country_id SMALLINT UNSIGNED NOT NULL, 
	PRIMARY KEY (director_id),
    FOREIGN KEY (country_id) REFERENCES country (country_id));
CREATE TABLE film (
	film_id SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
	name VARCHAR(45) NOT NULL,
    release_date DATE,
    director_id MEDIUMINT UNSIGNED NOT NULL,
	PRIMARY KEY (film_id),
    FOREIGN KEY (director_id) REFERENCES director (director_id));
CREATE TABLE film_country (
	film_id SMALLINT UNSIGNED NOT NULL,
	country_id SMALLINT UNSIGNED NOT NULL,
	PRIMARY KEY (film_id, country_id),
    FOREIGN KEY (film_id) REFERENCES film (film_id),
    FOREIGN KEY (country_id) REFERENCES country (country_id));

INSERT INTO country(name) 
	VALUES ('Россия'),('США'),('Великобритания'),('Канада');
SELECT * FROM country;
INSERT INTO director(firstname,lastname,country_id) 
	VALUES ('Андрей','Тарковский',1),('Кристофер ','Нолан',3),('Квентин','Тарантино',2),('Уэс','Андерсон',2),('Дени','Вильнёв',4);
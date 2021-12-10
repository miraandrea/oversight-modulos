CREATE SCHEMA oversight_api;
USE oversight_api;

CREATE TABLE estudiantes(
	documento int(12) primary key not null,
    nombre char(30),
	apellido char(30)
);

CREATE TABLE profesores(
	documento int(12) primary key not null,
    nombre char(30),
	apellido char(30)
);

CREATE TABLE administradores(
	documento int(12) primary key not null,
    nombre char(30),
	apellido char(30)
);

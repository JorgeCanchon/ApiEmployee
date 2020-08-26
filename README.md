# ApiEmployee
Asp web api  
# Ejecución
--
- Modificar la cadena de conexión `PostgreSqlDBContext` del archivo **ApiEmployee/appsettings.json**

- Ejecutar el siguiente script en su motor de base de datos **postgresql** para crear la base de datos y su respectiva tabla.

```postgres
create database dbemployee

create table employee(
	pk_employee bigint primary key ,
	fullname text not null,
	position text not null,
	fk_employee bigint,
	boss bool not null default(false),
	fhcreated timestamp not null default(Now()),
	foreign key (fk_employee) references employee (pk_employee)
);

create sequence pk_employee;
alter table  employee alter column pk_employee set default
nextval('pk_employee'::regclass);

insert into employee (fullname, position)
values('Jorge Canchon', 'developer')

insert into employee (fullname, position, fk_employee)
values('Jorge Canchon', 'scrum master', 1)
```


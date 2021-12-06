-.---------------------------------
#tablas FLUJO con atributos (Proceso	,Tipo,	Rol,	Proceso_sig )
create table flujo
(
    flujo varchar(3),
    proceso varchar(3),
    tipo varchar(3),
    rol varchar(3),
    proceso_sig varchar(3),
    Formulario varchar(50)
)
#insertar datos en la tabla flujo
#f1	p1	i	Frente	p2	fechaHora.php
f1	p2	p	Frente	p3	Alistar.php
f1	p3	d	Frente	p4	presentar.php
f1	p4	c	Kardex		documetoDia.php
f1	p5	p	Kardex	p1	notifica.php
f1	p8	p	Kardex		pasarSis.php

insert into flujo values('f1','p1','i','Frente','p2','fechaHora.php');
insert into flujo values('f1','p2','p','Frente','p3','Alistar.php');
insert into flujo values('f1','p3','d','Frente','p4','presentar.php');
insert into flujo values('f1','p4','c','Kardex','','documetoDia.php');
insert into flujo values('f1','p5','p','Kardex','p1','notifica.php');
insert into flujo values('f1','p8','p','Kardex','','pasarSis.php');


#tabla flujo_condicional
create table flujo_condicional
(
    flujo varchar(3),
    proceso varchar(3),
    verdad varchar(3),
    falso varchar(3)
)
#insertar datos en la tabla flujo_condicional
#f1 p4	p8	p5
insert into flujo_condicional values('f1','p4','p8','p5');


create table seguimiento
(
    notramite integer,
    usuario varchar(10),
    flujo varchar(3),
    proceso varchar(3),
    fechainicio datetime,
    fechafin datetime
)

#insertar loas datos  a tabla seguimiento
#1	Benjamin	p1	13/06/2021 13:23:02	13/06/2021 13:45:02
#1	Benjamin	p2	14/06/2021 11:45:02	14/06/2021 12:45:02

insert into seguimiento values(1,'Benjamin','P1','13/06/2021 13:23:02','13/06/2021 13:45:02');
insert into seguimiento values(1,'Benjamin','P2','14/06/2021 11:45:02','14/06/2021 12:45:02');

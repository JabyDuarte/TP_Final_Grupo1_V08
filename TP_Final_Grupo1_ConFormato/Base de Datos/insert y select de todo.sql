use tp_abm;

select * from persona;
select * from usuario; 
-- gruiz	4321@xxi
select * from roles;
select * from permisos;
select * from rolpermiso;
select * from cliente;
select * from usuariorol;
-- update rolpermiso set idpermisos = 2 where idrolpermiso = 2;
insert into usuarioRol(idrol,idusuario) values(2,2);

select * from cliente;
select * from producto;
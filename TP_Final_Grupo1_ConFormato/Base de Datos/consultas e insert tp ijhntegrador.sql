

select * from usuariorol;

select * from usuario;

update usuario set flagbloqueado = 1 where idusuario = 1;

update usuario set flagbloqueado = 0 where idusuario = 1;

select * from rolpermiso;

select * from roles;

select * from persona;

select * from permisos;

SELECT p.IdPermisos, p.Descripcion
FROM Usuario u
JOIN UsuarioRol ur ON u.IdUsuario = ur.FK_idUsuario
JOIN Roles r ON ur.FK_IdRol = r.FK_IdRol
JOIN RolPermiso rp ON r.IdRol = rp.IdRolPermiso
JOIN Permisos p ON rp.FK_IdPermisos = p.IdPermisos
WHERE u.IdUsuario = 1;

SELECT p.IdPermisos, p.Descripcion
FROM Usuario u
JOIN usuariorol ur ON u.IdUsuario = ur.fk_idUsuario
WHERE u.IdUsuario = 1;

select * from usuario;

select * from usuariorol;

select * from rolpermiso;

select * from permisos;

select idpermisos,descripcion
from permisos where idpermisos in (select fk_idrol from usuariorol where fk_idusuario in (1,3));

select nombreusuario,idpersona
from usuario where idpersona in (select fk_idusuario from usuariorol where fk_idusuario in (select idpermisos from permisos where idpermisos in (1)));

SELECT p.descripcion AS Permiso, pe.apellidoNombre AS NombrePersona FROM usuariorol ur
JOIN     rolpermiso rp ON ur.idRol = rp.idRol
JOIN     permisos p ON rp.idPermisos = p.idPermisos
JOIN     usuario u ON ur.idUsuario = u.idUsuario
JOIN    persona pe ON u.idPersona = pe.idPersona
WHERE    u.idUsuario = 4;

INSERT INTO `tipoiva` (`descripcion`, `porcentaje`) VALUES
('Consumidor Final', 21.00),('Exento', 0.00);
INSERT INTO `unidaddemedida` (`descripcion`) VALUES
('Unidad'),('Kilogramo'),('Litro');
INSERT INTO `cliente` (`razonSocial`, `fechaAlta`, `fechaBaja`, `limiteCredito`, `idTipoIVA`) VALUES
('Cliente 1', '2023-11-07', '2024-11-07', 100000.00, 1),('Cliente 2', '2023-11-07', '2024-11-07', 150000.00, 2);
INSERT INTO `producto` (`descripcion`, `idUnidadDeMedida`, `valorUnitario`, `habilitado`) VALUES
('Producto 1', 1, 10.00, 1),('Producto 2', 2, 15.00, 1),('Producto 3', 3, 20.00, 0);

select * from producto;
select * from  cliente;
select * from unidaddemedida;
select * from tipoiva;

select * from persona;
select * from usuario; 
select * from roles;
select * from permisos;
select * from rolpermiso;

update roles set fechabaja = '2024-09-10 00:00:00' where idrol = 1; 
update roles set descripcion = 'usuario consulta' where idrol = 2; 

update permisos set descripcion = 'usuario consulta' where idpermisos = 2; 
update permisos set descripcion = 'usuario admin' where idpermisos = 1; 


select * from usuariorol;

insert into usuarioRol(idrol,idusuario) values(1,1);







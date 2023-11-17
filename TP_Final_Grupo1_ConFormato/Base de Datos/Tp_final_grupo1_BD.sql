CREATE DATABASE  IF NOT EXISTS `tp_abm` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;
USE `tp_abm`;
-- MySQL dump 10.13  Distrib 5.6.24, for Win64 (x86_64)
--
-- Host: localhost    Database: tp_abm
-- ------------------------------------------------------
-- Server version	5.5.5-10.4.28-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cabecerafactura`
--

DROP TABLE IF EXISTS `cabecerafactura`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cabecerafactura` (
  `idCabeceraFactura` int(11) NOT NULL AUTO_INCREMENT,
  `numeroFactura` varchar(10) NOT NULL,
  `idCliente` int(11) NOT NULL,
  `idTipoIva` int(11) NOT NULL,
  `montoTotalSinIva` double NOT NULL,
  `montoTotalConIva` double NOT NULL,
  `ivaPorcentaje` varchar(45) NOT NULL,
  `montoIva` varchar(45) NOT NULL,
  PRIMARY KEY (`idCabeceraFactura`),
  KEY `fk_cabecera_producto_idx` (`idCliente`),
  KEY `fk_cabecera_idtipoiva_idx` (`idTipoIva`),
  CONSTRAINT `fk_cabecera_idtipoiva` FOREIGN KEY (`idTipoIva`) REFERENCES `tipoiva` (`idtipoIVA`),
  CONSTRAINT `fk_cabecera_producto` FOREIGN KEY (`idCliente`) REFERENCES `cliente` (`idcliente`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cabecerafactura`
--

LOCK TABLES `cabecerafactura` WRITE;
/*!40000 ALTER TABLE `cabecerafactura` DISABLE KEYS */;
/*!40000 ALTER TABLE `cabecerafactura` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cliente`
--

DROP TABLE IF EXISTS `cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cliente` (
  `idcliente` int(11) NOT NULL AUTO_INCREMENT,
  `razonSocial` varchar(255) NOT NULL,
  `fechaAlta` date NOT NULL,
  `fechaBaja` date NOT NULL,
  `limiteCredito` double NOT NULL,
  `idTipoIVA` int(11) NOT NULL,
  PRIMARY KEY (`idcliente`),
  KEY `fk_tipoiva_cliente_idx` (`idTipoIVA`),
  CONSTRAINT `fk_cliente_tipoIva` FOREIGN KEY (`idTipoIVA`) REFERENCES `tipoiva` (`idtipoIVA`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente`
--

LOCK TABLES `cliente` WRITE;
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` VALUES (1,'Cliente 1','2023-11-07','2024-11-07',100000,1),(2,'Cliente 2','2023-11-07','2024-11-07',150000,2);
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detallefactura`
--

DROP TABLE IF EXISTS `detallefactura`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `detallefactura` (
  `iddetalleFactura` int(11) NOT NULL AUTO_INCREMENT,
  `idCabeceraFactura` int(11) NOT NULL,
  `idProducto` int(11) NOT NULL,
  `idUnidadDeMedida` int(11) NOT NULL,
  `cantidad` int(11) NOT NULL,
  `monto` double NOT NULL,
  `montoIva` double NOT NULL,
  `montoTotal` double NOT NULL,
  PRIMARY KEY (`iddetalleFactura`,`idCabeceraFactura`),
  KEY `fk_detalle_cabecera_idx` (`idCabeceraFactura`),
  KEY `fk_detalle_producto_idx` (`idProducto`),
  KEY `fk_detalle_unidadDeMedida_idx` (`idUnidadDeMedida`),
  CONSTRAINT `fk_detalle_cabecera` FOREIGN KEY (`idCabeceraFactura`) REFERENCES `cabecerafactura` (`idCabeceraFactura`),
  CONSTRAINT `fk_detalle_producto` FOREIGN KEY (`idProducto`) REFERENCES `producto` (`idproducto`),
  CONSTRAINT `fk_detalle_unidadDeMedida` FOREIGN KEY (`idUnidadDeMedida`) REFERENCES `unidaddemedida` (`idunidadDeMedida`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detallefactura`
--

LOCK TABLES `detallefactura` WRITE;
/*!40000 ALTER TABLE `detallefactura` DISABLE KEYS */;
/*!40000 ALTER TABLE `detallefactura` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `libros`
--

DROP TABLE IF EXISTS `libros`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `libros` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `titulo` varchar(50) DEFAULT NULL,
  `autor` varchar(50) DEFAULT NULL,
  `editorial` varchar(30) DEFAULT NULL,
  `precio` float DEFAULT NULL,
  `stock` int(11) DEFAULT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `libros`
--

LOCK TABLES `libros` WRITE;
/*!40000 ALTER TABLE `libros` DISABLE KEYS */;
INSERT INTO `libros` VALUES (1,'Uno','Richard Bach','Planeta',15,99),(2,'Ilusiones','Richard Bach','Planeta',18,50),(3,'El aleph','Borges','Emece',25,190),(4,'Aprenda PHP','Mario Molina','Emece',45,200),(5,'Aprenda PHP','Mario Molina','Emece',45,200),(6,'Aprenda PHP','Mario Molina','Emece',45,200),(7,'Aprenda PHP','Mario Molina','Emece',45,200);
/*!40000 ALTER TABLE `libros` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `permisos`
--

DROP TABLE IF EXISTS `permisos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `permisos` (
  `idPermisos` int(11) NOT NULL AUTO_INCREMENT,
  `fechaAlta` datetime DEFAULT NULL,
  `descripcion` varchar(45) DEFAULT NULL,
  `fechaBaja` datetime DEFAULT NULL,
  `flagBajaLogica` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`idPermisos`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `permisos`
--

LOCK TABLES `permisos` WRITE;
/*!40000 ALTER TABLE `permisos` DISABLE KEYS */;
INSERT INTO `permisos` VALUES (1,'2023-10-13 10:00:00','usuario admin','2024-09-08 11:23:59',0),(2,'2023-10-13 10:00:00','usuario consulta','2029-09-08 11:23:59',0),(3,'2023-10-13 10:00:00','Permisos de EDICIóN',NULL,0);
/*!40000 ALTER TABLE `permisos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `persona`
--

DROP TABLE IF EXISTS `persona`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `persona` (
  `idPersona` int(11) NOT NULL AUTO_INCREMENT,
  `fechaAlta` datetime DEFAULT NULL,
  `apellidoNombre` varchar(45) NOT NULL,
  `fechaNacimiento` datetime NOT NULL,
  PRIMARY KEY (`idPersona`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `persona`
--

LOCK TABLES `persona` WRITE;
/*!40000 ALTER TABLE `persona` DISABLE KEYS */;
INSERT INTO `persona` VALUES (1,'2023-10-13 10:00:00','Tejerina Martín','1972-12-14 00:00:00'),(2,'2023-10-13 10:00:00','Ruiz Germán','1985-05-06 00:00:00'),(3,'2023-10-13 10:00:00','Dichiaro Gabriela','1988-06-19 00:00:00'),(4,'2023-10-13 10:00:00','Vega Susana','1978-09-09 00:00:00');
/*!40000 ALTER TABLE `persona` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `producto`
--

DROP TABLE IF EXISTS `producto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `producto` (
  `idproducto` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(45) NOT NULL,
  `idUnidadDeMedida` int(11) NOT NULL,
  `valorUnitario` double NOT NULL,
  `habilitado` int(11) NOT NULL,
  PRIMARY KEY (`idproducto`),
  KEY `fk_producto_unidadDeMedida_idx` (`idUnidadDeMedida`),
  CONSTRAINT `fk_producto_unidadDeMedida` FOREIGN KEY (`idUnidadDeMedida`) REFERENCES `unidaddemedida` (`idunidadDeMedida`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `producto`
--

LOCK TABLES `producto` WRITE;
/*!40000 ALTER TABLE `producto` DISABLE KEYS */;
INSERT INTO `producto` VALUES (1,'Producto 1',1,10,1),(2,'Producto 2',2,15,1),(3,'Producto 3',3,20,0);
/*!40000 ALTER TABLE `producto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `roles` (
  `idRol` int(11) NOT NULL AUTO_INCREMENT,
  `fechaAlta` datetime NOT NULL,
  `descripcion` varchar(45) DEFAULT NULL,
  `fechaBaja` datetime DEFAULT NULL,
  `flagBajaLogica` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`idRol`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'2023-10-13 10:00:00','usuario admin','2024-09-10 00:00:00',0),(2,'2023-10-13 10:00:00','usuario consulta','2024-09-10 00:00:00',0),(3,'2023-10-13 10:00:00','Usuario Avanzado',NULL,0);
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rolpermiso`
--

DROP TABLE IF EXISTS `rolpermiso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rolpermiso` (
  `idRolPermiso` int(11) NOT NULL AUTO_INCREMENT,
  `idRol` int(11) DEFAULT NULL,
  `idPermisos` int(11) DEFAULT NULL,
  PRIMARY KEY (`idRolPermiso`),
  KEY `idRol_idx` (`idRol`),
  KEY `idPermisos_idx` (`idPermisos`),
  CONSTRAINT `idPermisos` FOREIGN KEY (`idPermisos`) REFERENCES `permisos` (`idPermisos`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idRol` FOREIGN KEY (`idRol`) REFERENCES `roles` (`idRol`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rolpermiso`
--

LOCK TABLES `rolpermiso` WRITE;
/*!40000 ALTER TABLE `rolpermiso` DISABLE KEYS */;
INSERT INTO `rolpermiso` VALUES (1,1,1),(2,2,1),(3,2,2),(4,3,1),(5,3,2),(6,3,3);
/*!40000 ALTER TABLE `rolpermiso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipoiva`
--

DROP TABLE IF EXISTS `tipoiva`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipoiva` (
  `idtipoIVA` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(45) NOT NULL,
  `porcentaje` double NOT NULL,
  `habilitado` int(11) NOT NULL DEFAULT 1,
  PRIMARY KEY (`idtipoIVA`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipoiva`
--

LOCK TABLES `tipoiva` WRITE;
/*!40000 ALTER TABLE `tipoiva` DISABLE KEYS */;
INSERT INTO `tipoiva` VALUES (1,'Consumidor Final',21,1),(2,'Exento',0,1);
/*!40000 ALTER TABLE `tipoiva` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unidaddemedida`
--

DROP TABLE IF EXISTS `unidaddemedida`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `unidaddemedida` (
  `idunidadDeMedida` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(45) NOT NULL,
  `habilitado` int(11) NOT NULL DEFAULT 1,
  PRIMARY KEY (`idunidadDeMedida`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unidaddemedida`
--

LOCK TABLES `unidaddemedida` WRITE;
/*!40000 ALTER TABLE `unidaddemedida` DISABLE KEYS */;
INSERT INTO `unidaddemedida` VALUES (1,'Unidad',1),(2,'Kilogramo',1),(3,'Litro',1);
/*!40000 ALTER TABLE `unidaddemedida` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuario` (
  `idUsuario` int(11) NOT NULL AUTO_INCREMENT,
  `fechaAlta` datetime NOT NULL,
  `nombreUsuario` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `idPersona` int(11) NOT NULL,
  `fechaCaducidadPassword` datetime DEFAULT NULL,
  `fechaBaja` datetime DEFAULT NULL,
  `flagBloqueado` tinyint(1) DEFAULT NULL,
  `cantidadIntentosFallidos` int(11) DEFAULT NULL,
  `flagBajaLogica` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`idUsuario`),
  KEY `idPersona_idx` (`idPersona`),
  CONSTRAINT `idPersona` FOREIGN KEY (`idPersona`) REFERENCES `persona` (`idPersona`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'2023-10-13 10:00:00','mtejerina','1234@xxi',1,'2023-12-17 00:00:00',NULL,0,0,0),(2,'2023-10-13 10:00:00','gruiz','4321@xxi',2,'2023-12-17 00:00:00',NULL,0,2,0),(3,'2023-10-13 10:00:00','gdichiaro','gaby1234',3,'2023-12-18 00:00:00',NULL,0,3,0),(4,'2023-10-13 10:00:00','susyVega','svega@@1',4,'2023-12-18 00:00:00',NULL,0,1,0);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuariorol`
--

DROP TABLE IF EXISTS `usuariorol`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuariorol` (
  `idUsuarioRol` int(11) NOT NULL AUTO_INCREMENT,
  `idRol` int(11) NOT NULL,
  `idUsuario` int(11) NOT NULL,
  PRIMARY KEY (`idUsuarioRol`),
  KEY `idUsuario_idx` (`idUsuario`),
  KEY `idRol_idx` (`idRol`),
  CONSTRAINT `FK_idRol` FOREIGN KEY (`idRol`) REFERENCES `roles` (`idRol`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_idUsuario` FOREIGN KEY (`idUsuario`) REFERENCES `usuario` (`idUsuario`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuariorol`
--

LOCK TABLES `usuariorol` WRITE;
/*!40000 ALTER TABLE `usuariorol` DISABLE KEYS */;
INSERT INTO `usuariorol` VALUES (1,1,1);
/*!40000 ALTER TABLE `usuariorol` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ventas`
--

DROP TABLE IF EXISTS `ventas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ventas` (
  `numero` int(11) NOT NULL AUTO_INCREMENT,
  `codigolibro` int(11) DEFAULT NULL,
  `precio` float DEFAULT NULL,
  `cantidad` int(11) DEFAULT NULL,
  PRIMARY KEY (`numero`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ventas`
--

LOCK TABLES `ventas` WRITE;
/*!40000 ALTER TABLE `ventas` DISABLE KEYS */;
INSERT INTO `ventas` VALUES (2,3,NULL,10),(3,1,15,1);
/*!40000 ALTER TABLE `ventas` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER ActualizacionStocks
AFTER INSERT ON VENTAS
FOR EACH ROW
BEGIN
update libros set stock = stock - NEW.cantidad WHERE codigo = NEW.codigoLibro; 
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 trigger ActualizarPorDevolucion
   before delete on ventas
   for each row
 begin
  update libros set stock=libros.stock+old.cantidad
     where old.codigolibro=libros.codigo;   
 end */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Dumping events for database 'tp_abm'
--

--
-- Dumping routines for database 'tp_abm'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-11-12 22:02:09

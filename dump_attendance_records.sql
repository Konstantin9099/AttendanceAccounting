-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: localhost    Database: attendance_records
-- ------------------------------------------------------
-- Server version	8.0.27

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `list`
--

DROP TABLE IF EXISTS `list`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `list` (
  `id_list` int DEFAULT NULL,
  `peoples_id` int DEFAULT NULL,
  `work_id` int DEFAULT NULL,
  `when_in` varchar(20) DEFAULT NULL,
  `when_out` varchar(20) DEFAULT NULL,
  KEY `id_list` (`id_list`),
  KEY `fk_list_workers` (`work_id`),
  KEY `fk_list_peoples` (`peoples_id`),
  CONSTRAINT `fk_list_peoples` FOREIGN KEY (`peoples_id`) REFERENCES `peoples` (`id_peoples`),
  CONSTRAINT `fk_list_workers` FOREIGN KEY (`work_id`) REFERENCES `workers` (`id_work`),
  CONSTRAINT `list_ibfk_1` FOREIGN KEY (`id_list`) REFERENCES `workers` (`id_list`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `list`
--

LOCK TABLES `list` WRITE;
/*!40000 ALTER TABLE `list` DISABLE KEYS */;
INSERT INTO `list` VALUES (NULL,NULL,8,'09-11-2022 10:20',NULL),(NULL,NULL,11,'11-11-2022 15:10',NULL),(NULL,NULL,1,'11-11-2022 15:30',NULL),(NULL,NULL,3,'11-11-2022 15:35',NULL),(NULL,NULL,6,'11-11-2022 15:35',NULL),(NULL,NULL,5,'11-11-2022 15:40',NULL),(NULL,NULL,2,'11-11-2022 15:40',NULL),(NULL,NULL,2,NULL,'11-11-2022 20:12'),(NULL,NULL,6,'11-11-2022 21:30',NULL),(NULL,NULL,3,NULL,'11-11-2022 21:40'),(NULL,1,NULL,'10-11-2022 15:10',NULL),(NULL,2,NULL,'11-11-2022 09:10',NULL),(NULL,3,NULL,'11-11-2022 16:15',NULL),(NULL,4,NULL,'11-11-2022 12:15',NULL),(NULL,5,NULL,'11-11-2022 15:25',NULL),(NULL,6,NULL,'11-11-2022 18:25',NULL),(NULL,7,NULL,'12-11-2022 07:55',NULL),(NULL,1,NULL,NULL,'10-11-2022 16:40'),(NULL,8,NULL,'12-11-2022 10:15',NULL),(NULL,9,NULL,'12-11-2022 10:45',NULL),(NULL,2,NULL,NULL,'12-11-2022 11:38'),(NULL,10,NULL,'12-11-2022 14:25',NULL),(NULL,3,NULL,NULL,'12-11-2022 14:30'),(NULL,11,NULL,'12-11-2022 12:45',NULL),(NULL,11,NULL,NULL,'12-11-2022 13:30'),(NULL,NULL,8,'12-11-2022 10:20',NULL),(NULL,NULL,11,NULL,'11-11-2022 17:50'),(NULL,12,NULL,'12-11-2022 10:25',NULL),(NULL,12,NULL,NULL,'12-11-2022 10:31'),(NULL,13,NULL,'12-11-2022 09:10',NULL),(NULL,14,NULL,'12-11-2022 10:10',NULL),(NULL,14,NULL,NULL,'12-11-2022 10:30'),(NULL,6,NULL,NULL,'11-11-2022 18:45');
/*!40000 ALTER TABLE `list` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `login`
--

DROP TABLE IF EXISTS `login`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `login` (
  `id_login` int NOT NULL AUTO_INCREMENT,
  `login` varchar(25) DEFAULT NULL,
  `password` varchar(25) DEFAULT NULL,
  `mode` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id_login`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `login`
--

LOCK TABLES `login` WRITE;
/*!40000 ALTER TABLE `login` DISABLE KEYS */;
INSERT INTO `login` VALUES (1,'admin','admin','Администратор'),(3,'2222','2222','Пользователь'),(4,'3333','3333','Пользователь'),(5,'4444','4444','Пользователь'),(6,'1111','1111','Пользователь'),(7,'5555','5555','Пользователь'),(8,'6666','6666','Пользователь'),(9,'7777','7777','Пользователь'),(10,'8888','8888','Пользователь'),(11,'9999','9999','Пользователь');
/*!40000 ALTER TABLE `login` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `peoples`
--

DROP TABLE IF EXISTS `peoples`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `peoples` (
  `id_peoples` int NOT NULL AUTO_INCREMENT,
  `firstname_p` varchar(20) DEFAULT NULL,
  `middlename_p` varchar(20) DEFAULT NULL,
  `lastname_p` varchar(20) DEFAULT NULL,
  `status_id` int DEFAULT NULL,
  PRIMARY KEY (`id_peoples`),
  KEY `fk_peoples_status` (`status_id`),
  CONSTRAINT `fk_peoples_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`id_status`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `peoples`
--

LOCK TABLES `peoples` WRITE;
/*!40000 ALTER TABLE `peoples` DISABLE KEYS */;
INSERT INTO `peoples` VALUES (1,'Филатов','Матвей','Тимурович',1),(2,'Васильева','Татьяна','Васильевна',2),(3,'Полежаев','Виктор','Андреевич',3),(4,'Пушкин','Александр','Сергеевич',1),(5,'Бочаров','Николай','Гаврилович',2),(6,'Кулаков','Вавилий','Александрович',3),(7,'Куимов','Виктор','Федорович',2),(8,'Карташова','Лариса','Леонидовна',1),(9,'Бородич','Всеволод','Ларионович',2),(10,'Ветров','Геннадий','Алексеевич',3),(11,'Федоров','Андрей','Тимурович',1),(12,'Круглов','Эдуард','Максимович',3),(13,'Будько','Иван','Александрович',2),(14,'Пустовитов','Павел','Платонович',2);
/*!40000 ALTER TABLE `peoples` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `positions`
--

DROP TABLE IF EXISTS `positions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `positions` (
  `id_position` int NOT NULL AUTO_INCREMENT,
  `name_position` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id_position`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `positions`
--

LOCK TABLES `positions` WRITE;
/*!40000 ALTER TABLE `positions` DISABLE KEYS */;
INSERT INTO `positions` VALUES (1,'Директор'),(2,'Бухгалтер'),(3,'Менеджер'),(4,'Инженер'),(5,'Секретарь'),(6,'Водитель'),(7,'Лаборант'),(8,'Уборщица'),(9,'Администратор'),(10,'Кадровик'),(11,'Экономист');
/*!40000 ALTER TABLE `positions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `status`
--

DROP TABLE IF EXISTS `status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `status` (
  `id_status` int NOT NULL AUTO_INCREMENT,
  `name_status` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id_status`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `status`
--

LOCK TABLES `status` WRITE;
/*!40000 ALTER TABLE `status` DISABLE KEYS */;
INSERT INTO `status` VALUES (1,'По личному вопросу'),(2,'По работе'),(3,'Курьер');
/*!40000 ALTER TABLE `status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `workers`
--

DROP TABLE IF EXISTS `workers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `workers` (
  `id_work` int NOT NULL AUTO_INCREMENT,
  `firstname_wo` varchar(20) DEFAULT NULL,
  `middlename_w` varchar(20) DEFAULT NULL,
  `lastname_w` varchar(20) DEFAULT NULL,
  `position_id` int DEFAULT NULL,
  `login_id` int DEFAULT NULL,
  `id_list` int DEFAULT NULL,
  PRIMARY KEY (`id_work`),
  UNIQUE KEY `id_list` (`id_list`),
  KEY `fk_workers_positions` (`position_id`),
  KEY `login_id` (`login_id`),
  CONSTRAINT `fk_workers_positions` FOREIGN KEY (`position_id`) REFERENCES `positions` (`id_position`),
  CONSTRAINT `workers_ibfk_1` FOREIGN KEY (`login_id`) REFERENCES `login` (`id_login`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `workers`
--

LOCK TABLES `workers` WRITE;
/*!40000 ALTER TABLE `workers` DISABLE KEYS */;
INSERT INTO `workers` VALUES (1,'Воробьев','Виталий','Игоревич',1,1,1),(2,'Шишкин','Олег','Николаевич',2,3,2),(3,'Васильева','Татьяна','Эдуардовна',3,4,3),(4,'Калашников','Илья','Федорович',4,5,4),(5,'Дулова','Вера','Викторовна',5,6,5),(6,'Волков','Никита','Андреевич',4,7,6),(8,'Мартынов','Александр','Валерьевич',4,8,8),(9,'Петров','Богдан','Миронович',6,9,9),(10,'Аверьянова','Виолетта','Алексеевна',10,10,10),(11,'Петушков','Сергей','Артемович',11,11,11);
/*!40000 ALTER TABLE `workers` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-11-12 11:01:15

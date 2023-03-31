CREATE DATABASE  IF NOT EXISTS `epiz_32554537_db` /*!40100 DEFAULT CHARACTER SET latin1 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `epiz_32554537_db`;
-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: localhost    Database: epiz_32554537_db
-- ------------------------------------------------------
-- Server version	8.0.31

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `ttrpgfields`
--

DROP TABLE IF EXISTS `ttrpgfields`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ttrpgfields` (
  `id` int NOT NULL AUTO_INCREMENT,
  `gameid` int NOT NULL,
  `tag` varchar(50) NOT NULL COMMENT ' The tag is what is used to reference this field in formulas. ',
  `typeid` int NOT NULL COMMENT 'The typeid is the data type entered.  It matches the enumeration IDs in the code.',
  `valuelist` varchar(2048) NOT NULL COMMENT 'comma separated list of possible values',
  `name` varchar(255) NOT NULL COMMENT 'The displayname is what is displayed on the actual screen for a user to see.',
  `order` int NOT NULL DEFAULT (0),
  PRIMARY KEY (`id`),
  KEY `gameid` (`gameid`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ttrpgfields`
--

LOCK TABLES `ttrpgfields` WRITE;
/*!40000 ALTER TABLE `ttrpgfields` DISABLE KEYS */;
INSERT INTO `ttrpgfields` VALUES (1,0,'charaname',1,'','Character Name',0),(2,0,'race',3,'Human,Elf,Dwarf','Race',2),(3,0,'ac',0,'','Armor Class',3),(4,0,'str',0,'','Strength',5),(5,0,'dex',0,'','Dexterity',7),(6,0,'con',0,'','Constitution',9),(7,0,'int',0,'','Intelligence',11),(8,0,'wis',0,'','Wisdom',13),(9,0,'cha',0,'','Charisma',15),(11,0,'playername',1,'','Player Name',1),(21,0,'base_str',2,'','Base Strength',4),(23,0,'base_dex',2,'','Base Dexterity',6),(24,0,'base_con',2,'','Base Constitution',8),(25,0,'base_int',2,'','Base Intelligence',10),(26,0,'base_wis',2,'','Base Wisdom',12),(27,0,'base_cha',2,'','Base Charisma',14);
/*!40000 ALTER TABLE `ttrpgfields` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ttrpgformulas`
--

DROP TABLE IF EXISTS `ttrpgformulas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ttrpgformulas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `fieldid` int NOT NULL,
  `value` varchar(255) NOT NULL COMMENT 'if the value is NULL, assume it is for ANY value. + if the value is specified, only apply the formula if the field has this specific value. ',
  `formula` varchar(2048) NOT NULL COMMENT 'The javascriptformula that adjusts other fields values by their tag name.',
  `priority` int NOT NULL DEFAULT '0' COMMENT 'priority 0 means run it when the character is created... like rolling stats. priority 1 means apply the formula FIRST every time the a value changes.  2 through infinitiy is the same, but later',
  PRIMARY KEY (`id`),
  KEY `fieldid` (`fieldid`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ttrpgformulas`
--

LOCK TABLES `ttrpgformulas` WRITE;
/*!40000 ALTER TABLE `ttrpgformulas` DISABLE KEYS */;
INSERT INTO `ttrpgformulas` VALUES (1,2,'Elf','addToStat(\"dex\", \"base_dex\", 2); addToStat(\"cha\", \"base_cha\", 1);',2),(2,2,'Dwarf','addToStat(\"con\", \"base_con\", 2); addToStat(\"str\", \"base_str\", 1);',2),(3,21,'','setStat(\"base_str\", 8 + roll(6));',0),(4,23,'','setStat(\"base_dex\", 8 + roll(6));',0),(5,24,'','setStat(\"base_con\", 8 + roll(6));',0),(6,25,'','setStat(\"base_int\", 8 + roll(6));',0),(7,26,'','setStat(\"base_wis\", 8 + roll(6));',0),(8,27,'','setStat(\"base_cha\", 8 + roll(6));',0),(10,2,'Human','addToStat(\"str\", \"base_str\", 1); addToStat(\"dex\", \"base_dex\", 1); addToStat(\"con\", \"base_con\", 1);',2),(19,21,'','addToStat(\"str\", \"base_str\", 0);',1),(20,23,'','addToStat(\"dex\", \"base_dex\", 0);',1),(21,24,'','addToStat(\"con\", \"base_con\", 0);',1),(22,25,'','addToStat(\"int\", \"base_int\", 0);',1),(23,26,'','addToStat(\"wis\", \"base_wis\", 0);',1),(24,27,'','addToStat(\"cha\", \"base_cha\", 0);',1),(25,3,'','addStat(\"ac\", 10);',0);
/*!40000 ALTER TABLE `ttrpgformulas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ttrpggame`
--

DROP TABLE IF EXISTS `ttrpggame`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ttrpggame` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ttrpggame`
--

LOCK TABLES `ttrpggame` WRITE;
/*!40000 ALTER TABLE `ttrpggame` DISABLE KEYS */;
INSERT INTO `ttrpggame` VALUES (0,'ShigginsTest');
/*!40000 ALTER TABLE `ttrpggame` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-03-30 22:34:26

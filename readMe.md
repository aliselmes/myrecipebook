CREATE DATABASE `recipe_tracker`;
USE `recipe_tracker`;
CREATE TABLE `recipes` (
  `id` varchar(36) NOT NULL,
  `name` varchar(1000) NOT NULL,
  `dateAdded` date NOT NULL,
  `author` varchar(1000) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
CREATE TABLE `ingredients` (
  `id` varchar(36) NOT NULL,
  `recipeId` varchar(36) NOT NULL,
  `name` varchar(1000) DEFAULT NULL,
  `amount` varchar(100) DEFAULT NULL,
  `units` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `recipeId_idx` (`recipeId`),
  CONSTRAINT `recipeId` FOREIGN KEY (`recipeId`) REFERENCES `recipes` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
CREATE TABLE `instructions` (
  `id` varchar(36) NOT NULL,
  `recipeId` varchar(36) NOT NULL,
  `stepNumber` int(10) NOT NULL,
  `text` varchar(1000) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `recipeId_idx` (`recipeId`),
  CONSTRAINT `instructions_recipes` FOREIGN KEY (`recipeId`) REFERENCES `recipes` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


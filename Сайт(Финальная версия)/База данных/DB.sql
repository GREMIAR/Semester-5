-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Время создания: Май 03 2021 г., 03:11
-- Версия сервера: 10.4.18-MariaDB
-- Версия PHP: 8.0.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `articles`
--

-- --------------------------------------------------------

--
-- Структура таблицы `accounts`
--

CREATE TABLE `accounts` (
  `IDP` int(11) NOT NULL,
  `Role` int(11) NOT NULL,
  `Login` text NOT NULL,
  `Password` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `accounts`
--

INSERT INTO `accounts` (`IDP`, `Role`, `Login`, `Password`) VALUES
(1, 3, 'Admin!', '123456'),
(2, 2, 'Journalist', '123456'),
(12, 1, 'Tester', '123456');

-- --------------------------------------------------------

--
-- Структура таблицы `article`
--

CREATE TABLE `article` (
  `IDarticle` int(11) NOT NULL,
  `Nomen` text NOT NULL,
  `Textiq` text NOT NULL,
  `ImageURL` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `article`
--

INSERT INTO `article` (`IDarticle`, `Nomen`, `Textiq`, `ImageURL`) VALUES
(1, 'Об игре', 'NewGame — революция в жанре РПГ. Ваш персонаж — детектив с уникальными навыками, которому предстоит исследовать целый район. Допрашивайте незабываемых персонажей, расследуйте убийства или берите взятки. Кем вы станете: героем или неудачником?', 'image/Pic1.jpg'),
(63, '3', '3333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333', ''),
(64, '4', '4444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444', ''),
(65, '5', '5555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555', ''),
(66, '6', '6666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666', '');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `accounts`
--
ALTER TABLE `accounts`
  ADD PRIMARY KEY (`IDP`);

--
-- Индексы таблицы `article`
--
ALTER TABLE `article`
  ADD PRIMARY KEY (`IDarticle`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `accounts`
--
ALTER TABLE `accounts`
  MODIFY `IDP` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT для таблицы `article`
--
ALTER TABLE `article`
  MODIFY `IDarticle` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=67;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

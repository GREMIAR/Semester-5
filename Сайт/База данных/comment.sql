-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3307
-- Время создания: Ноя 08 2021 г., 01:46
-- Версия сервера: 10.4.21-MariaDB
-- Версия PHP: 7.3.31

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
-- Структура таблицы `comment`
--

CREATE TABLE `comment` (
  `id` int(11) NOT NULL,
  `text` text NOT NULL,
  `author` text DEFAULT NULL,
  `time` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `comment`
--

INSERT INTO `comment` (`id`, `text`, `author`, `time`) VALUES
(1, 'Как скачать непонял????', NULL, '2021-11-08 01:40:09'),
(2, 'Крутая игра', NULL, '2021-11-08 01:40:51'),
(3, '0 контента, но на 10 минут пойдёт', NULL, '2021-11-08 01:42:00'),
(4, 'Слишком страшно!!!!!!!!!!!!!!!', NULL, '2021-11-08 01:42:50'),
(5, 'Добавьте факел, а то ничего не видно ', NULL, '2021-11-08 01:43:12'),
(6, 'Фух нашол как скачат всем спасибо кто помог ', NULL, '2021-11-08 01:43:37'),
(7, 'а как усыновить', NULL, '2021-11-08 01:44:17'),
(8, '*установить дурацкий Т9 ', NULL, '2021-11-08 01:44:34'),
(9, 'я сегодня попу помыл', 'Илья Гришин', '2021-11-08 01:45:10'),
(10, 'А как выйти', NULL, '2021-11-08 01:45:32');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `comment`
--
ALTER TABLE `comment`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `comment`
--
ALTER TABLE `comment`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

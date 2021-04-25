-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Время создания: Апр 15 2021 г., 22:45
-- Версия сервера: 10.3.16-MariaDB
-- Версия PHP: 7.3.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `newgame`
--

-- --------------------------------------------------------

--
-- Структура таблицы `article`
--

CREATE TABLE `article` (
  `Article_ID` int(11) NOT NULL,
  `Содержимое` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Дамп данных таблицы `article`
--

INSERT INTO `article` (`Article_ID`, `Содержимое`) VALUES
(1, '<article class=\"ArticleMain\">\r\n	<p id=\"text_change\"><br><center><img src=\"image/Pic1.jpg\" alt=\"Привет пацаны\"></center><br><div class = \"text\"><a class = \"anchor\" name=\"Mid\"></a>NewGame — революция в жанре РПГ. Ваш персонаж — детектив с уникальными навыками, которому предстоит исследовать целый район. Допрашивайте незабываемых персонажей, расследуйте убийства или берите взятки. Кем вы станете: героем или неудачником?</div><br><center><img src=\"image/Pic2.jpg\" alt=\"Иди покакай\"></center><br><div class = \"text\"></p>\r\n</article>'),
(2, '<article class=\"Mainarticle\">\r\n			<p><b>До момента выхода оcталось</b><br><center><img src=\"image/ListC.png\" alt=\"Дней\" width=\"200\" height=\"200\"><img src=\"image/ListC.png\" alt=\"Часов\" width=\"200\" height=\"200\"><img src=\"image/ListC.png\" alt=\"Минут\" width=\"200\" height=\"200\"><img src=\"image/ListC.png\" alt=\"Секунд\" width=\"200\" height=\"200\"></center></p>\r\n  	</article>'),
(3, '<article><div class=\"ButtonDownload\">\r\n<a href=\"https://github.com/GREBIAR-Git/NewGameSetup\" target=\"_blank\">\r\n	\r\n<img src=\"image/download.png\" alt=\"Скачать\" width=\"50\" height=\"50\">\r\nСкачать для Windows\r\n		</a></div>\r\n		<center><table>\r\n			<caption><b style=\"font-size: 22px\">Системные требования</b></caption> \r\n			<tr>\r\n				<th colspan=\"3\">Минимальные</th>\r\n				<th colspan=\"3\">Рекомендуемые</th>\r\n			</tr>\r\n			<tr>\r\n				<td colspan=\"2\">ОС</td>\r\n				<td>Windows 7/8/10 (64 bits)</td>\r\n				<td colspan=\"2\">ОС</td>\r\n				<td>Windows 7/8/10 (64 bits)</td>\r\n			</tr>\r\n			<tr>\r\n				<td rowspan=\"2\">Процессор</td>\r\n				<td>AMD</td>\r\n				<td>FX-4100 (3.6 GHz)</td>\r\n				<td rowspan=\"2\">Процессор</td>\r\n				<td>AMD</td>\r\n				<td>FX-8350 (4.0 GHz)</td>\r\n			</tr>\r\n			<tr>\r\n				<td>Intel</td>\r\n				<td>Core i3-2125 (3.3 GHz)</td>\r\n				<td>Intel</td>\r\n				<td>Core i7-3820 (3.6 GHz)</td>\r\n			</tr>\r\n			<tr>\r\n				<td colspan=\"2\">ОЗУ</td>\r\n				<td>4 GB RAM</td>\r\n				<td colspan=\"2\">ОЗУ</td>\r\n				<td>8 GB RAM</td>\r\n			</tr>\r\n			<tr>\r\n				<td rowspan=\"2\">Видеокарта</td>\r\n				<td>AMD</td>\r\n				<td>Radeon R7 370</td>\r\n				<td rowspan=\"2\">Видеокарта</td>\r\n				<td>AMD</td>\r\n				<td>Radeon R9 280</td>\r\n			</tr>\r\n			<tr>\r\n				<td>nVidia</td>\r\n				<td>2 GB, GeForce GTX 660</td>\r\n				<td>nVidia</td>\r\n				<td>2 GB, GeForce GTX 760</td>\r\n			</tr>\r\n			<tr>\r\n				<td colspan=\"2\">Место на жёстком диске</td>\r\n				<td>2 GB</td>\r\n				<td colspan=\"2\">Место на жёстком диске</td>\r\n				<td>2 GB</td>\r\n			</tr>\r\n		</table></center>\r\n  	</article>');

-- --------------------------------------------------------

--
-- Структура таблицы `head`
--

CREATE TABLE `head` (
  `Head_ID` int(11) NOT NULL,
  `Encoding` varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  `Title` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `Style` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Дамп данных таблицы `head`
--

INSERT INTO `head` (`Head_ID`, `Encoding`, `Title`, `Style`) VALUES
(1, 'utf-8', 'Об игре', '<link type=\"text/css\" href=\"style/style.css\" rel=\"stylesheet\"><script type=\"text/javascript\" src=\"function/script.js\"></script>\r\n'),
(2, 'utf-8', 'Обратный отсчёт', '<link type=\"text/css\" href=\"style/style.css\" rel=\"stylesheet\">\r\n		<link  type=\"text/css\" href=\"style/styleWithoutMenu.css\"rel=\"stylesheet\">\r\n<script type=\"text/javascript\" src=\"function/script.js\"></script>\r\n'),
(3, 'utf-8', 'Скачать', '<link type=\"text/css\" href=\"style/style.css\" rel=\"stylesheet\">\r\n		<link  type=\"text/css\" href=\"style/styleWithoutMenu.css\"rel=\"stylesheet\">\r\n<script type=\"text/javascript\" src=\"function/script.js\"></script>');

-- --------------------------------------------------------

--
-- Структура таблицы `header_footer`
--

CREATE TABLE `header_footer` (
  `header_footer_ID` int(11) NOT NULL,
  `header` text CHARACTER SET utf8 NOT NULL,
  `footer` text CHARACTER SET utf8 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Дамп данных таблицы `header_footer`
--

INSERT INTO `header_footer` (`header_footer_ID`, `header`, `footer`) VALUES
(1, '<a name=\"Start\"></a>\r\n<header>NewGame</header>', '<footer>\r\n  	<p>Музалевский Никита<a href=\"https://github.com/GREBIAR-Git\" target=\"_blank\" name=\"End\"><img src=\"image/gitL.png\" width=\"50\" height=\"50\" alt=\"Музалевский Никита\"></a>\r\n  	<a href=\"https://github.com/mikhail01234\" target=\"_blank\"><img  src=\"image/gitR.png\" width=\"50\" height=\"50\" alt=\"Аллянов Михаил\"></a>Аллянов Михаил</p>\r\n</footer>');

-- --------------------------------------------------------

--
-- Структура таблицы `header_footer_menu_item`
--

CREATE TABLE `header_footer_menu_item` (
  `menu_item_ID` int(11) NOT NULL,
  `header_footer_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Дамп данных таблицы `header_footer_menu_item`
--

INSERT INTO `header_footer_menu_item` (`menu_item_ID`, `header_footer_ID`) VALUES
(1, 1),
(2, 1),
(3, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `head_пункт_меню`
--

CREATE TABLE `head_пункт_меню` (
  `Пункт_Меню_ID` int(11) NOT NULL,
  `Head_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Дамп данных таблицы `head_пункт_меню`
--

INSERT INTO `head_пункт_меню` (`Пункт_Меню_ID`, `Head_ID`) VALUES
(1, 1),
(2, 2),
(3, 3);

-- --------------------------------------------------------

--
-- Структура таблицы `menu item`
--

CREATE TABLE `menu item` (
  `menu_item_ID` int(11) NOT NULL,
  `Содержимое` text CHARACTER SET utf8 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Дамп данных таблицы `menu item`
--

INSERT INTO `menu item` (`menu_item_ID`, `Содержимое`) VALUES
(1, '<form action=\"#\"><section><menu class=\"NavBar\">\r\n<li><button name = \"AboutGame\" class=\"CurrentPlace\">Об игре</button>\r\n				<li><button name=\"Counter\">Обратный отсчёт</button>\r\n				<li><button name=\"Download\">Скачать</button>\r\n</menu></section></from>'),
(2, '<form><section><menu class=\"NavBar\">\r\n<li><button name = \"AboutGame\">Об игре</button><li><button name=\"Counter\" class=\"CurrentPlace\">Обратный отсчёт</button><li><button name=\"Download\">Скачать</button>\r\n</menu></section></from>\r\n'),
(3, '<form><section><menu class=\"NavBar\">\r\n<li><button name = \"AboutGame\">Об игре</button><li><button name=\"Counter\">Обратный отсчёт</button><li><button name=\"Download\" class=\"CurrentPlace\">Скачать</button>\r\n</menu></section></from>');

-- --------------------------------------------------------

--
-- Структура таблицы `пункт_навигации`
--

CREATE TABLE `пункт_навигации` (
  `Пункт_навигации_ID` int(11) NOT NULL,
  `Содержимое` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Дамп данных таблицы `пункт_навигации`
--

INSERT INTO `пункт_навигации` (`Пункт_навигации_ID`, `Содержимое`) VALUES
(1, '<menu class=\"menu\">\r\n	<li><div class = \"menu_btn\"><a href=\"#Start\">Шапка</a></div>\r\n	<li><div class = \"menu_btn\"><a href=\"#Mid\">Середина</a></div>\r\n	<li><div class = \"menu_btn\"><a href=\"#End\">Авторы</a></div>\r\n	</menu>');

-- --------------------------------------------------------

--
-- Структура таблицы `пункт_навигации_пункт_меню`
--

CREATE TABLE `пункт_навигации_пункт_меню` (
  `Пункт_Меню_ID` int(11) NOT NULL,
  `Пункт_навигации_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Дамп данных таблицы `пункт_навигации_пункт_меню`
--

INSERT INTO `пункт_навигации_пункт_меню` (`Пункт_Меню_ID`, `Пункт_навигации_ID`) VALUES
(1, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `статья_пункт_меню`
--

CREATE TABLE `статья_пункт_меню` (
  `Пункт_Меню_ID` int(11) NOT NULL,
  `Article_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Дамп данных таблицы `статья_пункт_меню`
--

INSERT INTO `статья_пункт_меню` (`Пункт_Меню_ID`, `Article_ID`) VALUES
(1, 1),
(2, 2),
(3, 3);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `article`
--
ALTER TABLE `article`
  ADD UNIQUE KEY `Article_ID` (`Article_ID`);

--
-- Индексы таблицы `head`
--
ALTER TABLE `head`
  ADD UNIQUE KEY `Head_ID` (`Head_ID`);

--
-- Индексы таблицы `header_footer`
--
ALTER TABLE `header_footer`
  ADD UNIQUE KEY `header_footer_ID` (`header_footer_ID`);

--
-- Индексы таблицы `header_footer_menu_item`
--
ALTER TABLE `header_footer_menu_item`
  ADD PRIMARY KEY (`menu_item_ID`),
  ADD KEY `header_footer_menu_item_ibfk_2` (`header_footer_ID`);

--
-- Индексы таблицы `head_пункт_меню`
--
ALTER TABLE `head_пункт_меню`
  ADD PRIMARY KEY (`Пункт_Меню_ID`),
  ADD UNIQUE KEY `Head_ID` (`Head_ID`);

--
-- Индексы таблицы `menu item`
--
ALTER TABLE `menu item`
  ADD PRIMARY KEY (`menu_item_ID`);

--
-- Индексы таблицы `пункт_навигации`
--
ALTER TABLE `пункт_навигации`
  ADD UNIQUE KEY `Пункт_Меню_ID` (`Пункт_навигации_ID`);

--
-- Индексы таблицы `пункт_навигации_пункт_меню`
--
ALTER TABLE `пункт_навигации_пункт_меню`
  ADD PRIMARY KEY (`Пункт_Меню_ID`),
  ADD UNIQUE KEY `Пункт_навигации_ID` (`Пункт_навигации_ID`);

--
-- Индексы таблицы `статья_пункт_меню`
--
ALTER TABLE `статья_пункт_меню`
  ADD PRIMARY KEY (`Пункт_Меню_ID`),
  ADD UNIQUE KEY `Article_ID` (`Article_ID`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `article`
--
ALTER TABLE `article`
  MODIFY `Article_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `head`
--
ALTER TABLE `head`
  MODIFY `Head_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `menu item`
--
ALTER TABLE `menu item`
  MODIFY `menu_item_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT для таблицы `пункт_навигации`
--
ALTER TABLE `пункт_навигации`
  MODIFY `Пункт_навигации_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `header_footer_menu_item`
--
ALTER TABLE `header_footer_menu_item`
  ADD CONSTRAINT `header_footer_menu_item_ibfk_1` FOREIGN KEY (`menu_item_ID`) REFERENCES `menu item` (`menu_item_ID`),
  ADD CONSTRAINT `header_footer_menu_item_ibfk_2` FOREIGN KEY (`header_footer_ID`) REFERENCES `header_footer` (`header_footer_ID`);

--
-- Ограничения внешнего ключа таблицы `head_пункт_меню`
--
ALTER TABLE `head_пункт_меню`
  ADD CONSTRAINT `head_пункт_меню_ibfk_2` FOREIGN KEY (`Пункт_Меню_ID`) REFERENCES `menu item` (`menu_item_ID`),
  ADD CONSTRAINT `head_пункт_меню_ibfk_3` FOREIGN KEY (`Head_ID`) REFERENCES `head` (`Head_ID`);

--
-- Ограничения внешнего ключа таблицы `пункт_навигации_пункт_меню`
--
ALTER TABLE `пункт_навигации_пункт_меню`
  ADD CONSTRAINT `пункт_навигации_пункт_меню_ibfk_1` FOREIGN KEY (`Пункт_навигации_ID`) REFERENCES `пункт_навигации` (`Пункт_навигации_ID`),
  ADD CONSTRAINT `пункт_навигации_пункт_меню_ibfk_2` FOREIGN KEY (`Пункт_Меню_ID`) REFERENCES `menu item` (`menu_item_ID`);

--
-- Ограничения внешнего ключа таблицы `статья_пункт_меню`
--
ALTER TABLE `статья_пункт_меню`
  ADD CONSTRAINT `статья_пункт_меню_ibfk_1` FOREIGN KEY (`Article_ID`) REFERENCES `article` (`Article_ID`),
  ADD CONSTRAINT `статья_пункт_меню_ibfk_2` FOREIGN KEY (`Пункт_Меню_ID`) REFERENCES `menu item` (`menu_item_ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

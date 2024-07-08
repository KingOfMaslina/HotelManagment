-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Время создания: Сен 29 2022 г., 16:00
-- Версия сервера: 10.4.24-MariaDB
-- Версия PHP: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `hotel_data`
--

-- --------------------------------------------------------

--
-- Структура таблицы `category`
--

CREATE TABLE `category` (
  `CategoryId` int(10) NOT NULL,
  `Lable` varchar(20) NOT NULL,
  `Price` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `category`
--

INSERT INTO `category` (`CategoryId`, `Lable`, `Price`) VALUES
(1, 'Одноместная', 7000),
(2, 'Двухместная', 10000),
(3, 'Люкс', 15000),
(4, 'Семейный', 18000),
(5, 'Улучшенный люкс', 20000);

-- --------------------------------------------------------

--
-- Структура таблицы `guest`
--

CREATE TABLE `guest` (
  `GuestId` varchar(20) NOT NULL,
  `GuestName` varchar(20) NOT NULL,
  `GuestLastName` varchar(20) NOT NULL,
  `GuestTel` varchar(20) NOT NULL,
  `GuestComm` varchar(256) NOT NULL,
  `GuestComp` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `guest`
--

INSERT INTO `guest` (`GuestId`, `GuestName`, `GuestLastName`, `GuestTel`, `GuestComm`, `GuestComp`) VALUES
('1', 'Бэн', 'Херрингтон', '+82183290323', '.', ''),
('2', 'Дэвид', 'Мартинэз', '+234723894723', '.', ''),
('3', 'Захар', 'Каплунов', '+79047590875', '.', 'б'),
('4', 'Михаил', 'Савченко', '+723894728934', '.', '.');

-- --------------------------------------------------------

--
-- Структура таблицы `reservation`
--

CREATE TABLE `reservation` (
  `ReservId` int(10) NOT NULL,
  `GuestId` varchar(10) NOT NULL,
  `RoomNo` varchar(10) NOT NULL,
  `DateIn` date NOT NULL,
  `DateOut` date NOT NULL,
  `RoomPrice` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `reservation`
--

INSERT INTO `reservation` (`ReservId`, `GuestId`, `RoomNo`, `DateIn`, `DateOut`, `RoomPrice`) VALUES
(14, '1', '003', '2022-09-29', '2022-10-09', 20000);

-- --------------------------------------------------------

--
-- Структура таблицы `room`
--

CREATE TABLE `room` (
  `RoomId` varchar(5) NOT NULL,
  `RoomType` int(5) NOT NULL,
  `RoomPhone` varchar(15) NOT NULL,
  `RoomStatus` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `room`
--

INSERT INTO `room` (`RoomId`, `RoomType`, `RoomPhone`, `RoomStatus`) VALUES
('002', 3, '2133211', 'Свободна'),
('003', 5, '213242', 'Занята'),
('004', 4, '2142342', 'Занята'),
('221', 1, '244312', 'Свободна'),
('435', 1, '2144212', 'Свободна'),
('501', 5, '244122', 'Занята'),
('534', 2, '124235', 'Свободна'),
('664', 2, '044022', 'Свободна'),
('666', 3, '234122', 'Свободна');

-- --------------------------------------------------------

--
-- Структура таблицы `users`
--

CREATE TABLE `users` (
  `username` varchar(20) NOT NULL,
  `password` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `users`
--

INSERT INTO `users` (`username`, `password`) VALUES
('Admin', 'root'),
('Admin', 'root'),
('User', '1234'),
('root', '1111');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`CategoryId`),
  ADD UNIQUE KEY `Price` (`Price`),
  ADD KEY `Price_2` (`Price`),
  ADD KEY `Price_3` (`Price`);

--
-- Индексы таблицы `guest`
--
ALTER TABLE `guest`
  ADD PRIMARY KEY (`GuestId`);

--
-- Индексы таблицы `reservation`
--
ALTER TABLE `reservation`
  ADD PRIMARY KEY (`ReservId`),
  ADD UNIQUE KEY `GuestId_2` (`GuestId`),
  ADD UNIQUE KEY `RoomNo` (`RoomNo`),
  ADD KEY `GuestId` (`GuestId`),
  ADD KEY `RoomNo_2` (`RoomNo`);

--
-- Индексы таблицы `room`
--
ALTER TABLE `room`
  ADD PRIMARY KEY (`RoomId`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `reservation`
--
ALTER TABLE `reservation`
  MODIFY `ReservId` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `reservation`
--
ALTER TABLE `reservation`
  ADD CONSTRAINT `reservation_ibfk_1` FOREIGN KEY (`GuestId`) REFERENCES `guest` (`GuestId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `reservation_ibfk_2` FOREIGN KEY (`RoomNo`) REFERENCES `room` (`RoomId`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

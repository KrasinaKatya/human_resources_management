-- phpMyAdmin SQL Dump
-- version 5.1.2
-- https://www.phpmyadmin.net/
--
-- Хост: localhost:3306
-- Время создания: Май 15 2024 г., 12:15
-- Версия сервера: 5.7.24
-- Версия PHP: 8.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `human_resources_management`
--

-- --------------------------------------------------------

--
-- Структура таблицы `encouragement`
--

CREATE TABLE `encouragement` (
  `id` int(11) NOT NULL,
  `id_worker` int(11) NOT NULL,
  `id_encouragement_type` int(11) NOT NULL,
  `date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `encouragement`
--

INSERT INTO `encouragement` (`id`, `id_worker`, `id_encouragement_type`, `date`) VALUES
(1, 4, 3, '2024-04-01'),
(2, 2, 4, '2024-04-14'),
(3, 1, 6, '2024-04-01'),
(4, 5, 2, '2024-04-21'),
(5, 2, 5, '2024-04-05'),
(6, 3, 4, '2024-04-11');

-- --------------------------------------------------------

--
-- Структура таблицы `encouragement_type`
--

CREATE TABLE `encouragement_type` (
  `id_encouragement_type` int(11) NOT NULL,
  `title` varchar(40) NOT NULL,
  `value` int(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `encouragement_type`
--

INSERT INTO `encouragement_type` (`id_encouragement_type`, `title`, `value`) VALUES
(1, 'Перевыполнение норм выработки', 5),
(2, 'Наставничество', 4),
(3, 'Повышение квалификации', 7),
(4, 'Высокое качество выполнения задач', 10),
(5, 'Безукоризненное соблюдение дисциплины', 1),
(6, 'Новаторские идеи', 2);

-- --------------------------------------------------------

--
-- Структура таблицы `infrigement`
--

CREATE TABLE `infrigement` (
  `id_infrigement` int(11) NOT NULL,
  `id_worker` int(11) NOT NULL,
  `id_infrigement_type` int(11) NOT NULL,
  `date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `infrigement`
--

INSERT INTO `infrigement` (`id_infrigement`, `id_worker`, `id_infrigement_type`, `date`) VALUES
(1, 6, 3, '2024-04-15'),
(2, 6, 6, '2024-04-15'),
(3, 2, 2, '2024-04-09'),
(4, 4, 1, '2024-04-29'),
(5, 5, 4, '2024-04-04'),
(6, 4, 2, '2024-04-02');

-- --------------------------------------------------------

--
-- Структура таблицы `infrigement_type`
--

CREATE TABLE `infrigement_type` (
  `id_infrigement_type` int(11) NOT NULL,
  `title_infrigement_type` varchar(40) NOT NULL,
  `value` int(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `infrigement_type`
--

INSERT INTO `infrigement_type` (`id_infrigement_type`, `title_infrigement_type`, `value`) VALUES
(1, 'Прогул', 3),
(2, 'Опоздание', 1),
(3, 'Неисполнение рабочих обязанностей', 5),
(4, 'Хищение', 7),
(5, 'Порча оборудования', 9),
(6, 'Игнорирование приказов руководства', 10);

-- --------------------------------------------------------

--
-- Структура таблицы `orders`
--

CREATE TABLE `orders` (
  `id_order` int(11) NOT NULL,
  `id_encouragement` int(11) DEFAULT NULL,
  `id_infrigement` int(11) DEFAULT NULL,
  `type_order` varchar(10) NOT NULL,
  `date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `orders`
--

INSERT INTO `orders` (`id_order`, `id_encouragement`, `id_infrigement`, `type_order`, `date`) VALUES
(1, 3, NULL, 'Премия', '2024-05-01'),
(2, 1, NULL, 'Премия', '2024-05-01'),
(3, 2, NULL, 'Премия', '2024-05-01'),
(4, NULL, 1, 'Штраф', '2024-05-01'),
(5, NULL, 2, 'Выговор', '2024-05-01'),
(6, NULL, 5, 'Выговор', '2024-05-01');

-- --------------------------------------------------------

--
-- Структура таблицы `pay_sheet`
--

CREATE TABLE `pay_sheet` (
  `id_pay_sheet` int(11) NOT NULL,
  `id_worker` int(11) NOT NULL,
  `date` date NOT NULL,
  `number_of_hourse` int(11) NOT NULL,
  `price_of_an_hour` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `pay_sheet`
--

INSERT INTO `pay_sheet` (`id_pay_sheet`, `id_worker`, `date`, `number_of_hourse`, `price_of_an_hour`) VALUES
(1, 1, '2024-05-01', 200, 300),
(2, 3, '2024-05-01', 208, 250),
(3, 2, '2024-05-01', 200, 250),
(4, 6, '2024-05-01', 208, 210),
(5, 4, '2024-05-01', 208, 200),
(6, 5, '2024-05-01', 208, 150);

-- --------------------------------------------------------

--
-- Структура таблицы `posts`
--

CREATE TABLE `posts` (
  `id_post` int(11) NOT NULL,
  `title_post` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `posts`
--

INSERT INTO `posts` (`id_post`, `title_post`) VALUES
(1, 'Бухгалтер'),
(2, 'Логист'),
(3, 'Маркетолог'),
(4, 'Менеджер'),
(5, 'Охранник'),
(6, 'Руководитель');

-- --------------------------------------------------------

--
-- Структура таблицы `productiviti_assessment`
--

CREATE TABLE `productiviti_assessment` (
  `id_productiviti_assesment` int(11) NOT NULL,
  `id_worker` int(11) NOT NULL,
  `value` int(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `productiviti_assessment`
--

INSERT INTO `productiviti_assessment` (`id_productiviti_assesment`, `id_worker`, `value`) VALUES
(1, 1, 5),
(2, 3, 4),
(3, 6, 3),
(4, 2, 4),
(5, 5, 3),
(6, 4, 5);

-- --------------------------------------------------------

--
-- Структура таблицы `productiviti_report`
--

CREATE TABLE `productiviti_report` (
  `id_productiviti_report` int(11) NOT NULL,
  `id_order` int(11) NOT NULL,
  `id_productiviti_assesment` int(11) NOT NULL,
  `date` date NOT NULL,
  `report_indicator` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `productiviti_report`
--

INSERT INTO `productiviti_report` (`id_productiviti_report`, `id_order`, `id_productiviti_assesment`, `date`, `report_indicator`) VALUES
(3, 1, 5, '2024-05-01', 5),
(4, 2, 4, '2024-05-01', 5),
(5, 3, 4, '2024-05-01', 5),
(6, 5, 3, '2024-05-01', 1),
(7, 6, 5, '2024-05-01', 3),
(8, 4, 3, '2024-05-01', 1);

-- --------------------------------------------------------

--
-- Структура таблицы `workers`
--

CREATE TABLE `workers` (
  `id_worker` int(11) NOT NULL,
  `last_name` varchar(20) NOT NULL,
  `first_name` varchar(20) NOT NULL,
  `surname` varchar(20) NOT NULL,
  `birthday` date NOT NULL,
  `phone_number` decimal(11,0) NOT NULL,
  `login` varchar(32) NOT NULL,
  `password` varchar(32) NOT NULL,
  `id_post` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `workers`
--

INSERT INTO `workers` (`id_worker`, `last_name`, `first_name`, `surname`, `birthday`, `phone_number`, `login`, `password`, `id_post`) VALUES
(1, 'Орлов', 'Владислав', 'Яковлевич', '1990-04-05', '89303234780', 'orlovvladislav', 'orlov', 6),
(2, 'Белова', 'Ольга', 'Александровна', '1987-05-29', '89205436745', 'belovaolga', 'belova', 1),
(3, 'Павлова', 'Елена', 'Степановна', '1982-08-11', '89201117875', 'pavlovaelena', 'pavlova', 2),
(4, 'Суркова', 'Анна', 'Тимуровна', '1996-10-30', '89304897622', 'surkovaanna', 'surkova', 4),
(5, 'Фролов', 'Антон', 'Юрьевич', '1990-12-01', '89206768768', 'frolovanton', 'frolov', 3),
(6, 'Смирнов', 'Дмитрий', 'Сергеевич', '1975-01-10', '89205424513', 'smirnovdmitriy', 'smirnov', 5);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `encouragement`
--
ALTER TABLE `encouragement`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_worker` (`id_worker`,`id_encouragement_type`),
  ADD KEY `id_encouragement_type` (`id_encouragement_type`);

--
-- Индексы таблицы `encouragement_type`
--
ALTER TABLE `encouragement_type`
  ADD PRIMARY KEY (`id_encouragement_type`);

--
-- Индексы таблицы `infrigement`
--
ALTER TABLE `infrigement`
  ADD PRIMARY KEY (`id_infrigement`),
  ADD KEY `id_worker` (`id_worker`),
  ADD KEY `id_infrigement_type` (`id_infrigement_type`);

--
-- Индексы таблицы `infrigement_type`
--
ALTER TABLE `infrigement_type`
  ADD PRIMARY KEY (`id_infrigement_type`);

--
-- Индексы таблицы `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`id_order`),
  ADD KEY `id_infrigement` (`id_infrigement`),
  ADD KEY `id_encouragement` (`id_encouragement`);

--
-- Индексы таблицы `pay_sheet`
--
ALTER TABLE `pay_sheet`
  ADD PRIMARY KEY (`id_pay_sheet`),
  ADD KEY `id_worker` (`id_worker`);

--
-- Индексы таблицы `posts`
--
ALTER TABLE `posts`
  ADD PRIMARY KEY (`id_post`);

--
-- Индексы таблицы `productiviti_assessment`
--
ALTER TABLE `productiviti_assessment`
  ADD PRIMARY KEY (`id_productiviti_assesment`),
  ADD KEY `id_worker` (`id_worker`);

--
-- Индексы таблицы `productiviti_report`
--
ALTER TABLE `productiviti_report`
  ADD PRIMARY KEY (`id_productiviti_report`),
  ADD KEY `id_productiviti_assesment` (`id_productiviti_assesment`),
  ADD KEY `id_worker_2` (`id_order`,`id_productiviti_assesment`);

--
-- Индексы таблицы `workers`
--
ALTER TABLE `workers`
  ADD PRIMARY KEY (`id_worker`),
  ADD KEY `id_post` (`id_post`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `encouragement`
--
ALTER TABLE `encouragement`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `encouragement_type`
--
ALTER TABLE `encouragement_type`
  MODIFY `id_encouragement_type` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `infrigement`
--
ALTER TABLE `infrigement`
  MODIFY `id_infrigement` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `infrigement_type`
--
ALTER TABLE `infrigement_type`
  MODIFY `id_infrigement_type` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `orders`
--
ALTER TABLE `orders`
  MODIFY `id_order` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `pay_sheet`
--
ALTER TABLE `pay_sheet`
  MODIFY `id_pay_sheet` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT для таблицы `posts`
--
ALTER TABLE `posts`
  MODIFY `id_post` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `productiviti_assessment`
--
ALTER TABLE `productiviti_assessment`
  MODIFY `id_productiviti_assesment` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `productiviti_report`
--
ALTER TABLE `productiviti_report`
  MODIFY `id_productiviti_report` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT для таблицы `workers`
--
ALTER TABLE `workers`
  MODIFY `id_worker` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `encouragement`
--
ALTER TABLE `encouragement`
  ADD CONSTRAINT `encouragement_ibfk_1` FOREIGN KEY (`id_worker`) REFERENCES `workers` (`id_worker`),
  ADD CONSTRAINT `encouragement_ibfk_2` FOREIGN KEY (`id_encouragement_type`) REFERENCES `encouragement_type` (`id_encouragement_type`);

--
-- Ограничения внешнего ключа таблицы `infrigement`
--
ALTER TABLE `infrigement`
  ADD CONSTRAINT `infrigement_ibfk_1` FOREIGN KEY (`id_worker`) REFERENCES `workers` (`id_worker`),
  ADD CONSTRAINT `infrigement_ibfk_2` FOREIGN KEY (`id_infrigement_type`) REFERENCES `infrigement_type` (`id_infrigement_type`);

--
-- Ограничения внешнего ключа таблицы `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `orders_ibfk_3` FOREIGN KEY (`id_infrigement`) REFERENCES `infrigement` (`id_infrigement`),
  ADD CONSTRAINT `orders_ibfk_5` FOREIGN KEY (`id_encouragement`) REFERENCES `encouragement` (`id`);

--
-- Ограничения внешнего ключа таблицы `pay_sheet`
--
ALTER TABLE `pay_sheet`
  ADD CONSTRAINT `pay_sheet_ibfk_1` FOREIGN KEY (`id_worker`) REFERENCES `workers` (`id_worker`);

--
-- Ограничения внешнего ключа таблицы `productiviti_assessment`
--
ALTER TABLE `productiviti_assessment`
  ADD CONSTRAINT `productiviti_assessment_ibfk_1` FOREIGN KEY (`id_worker`) REFERENCES `workers` (`id_worker`);

--
-- Ограничения внешнего ключа таблицы `productiviti_report`
--
ALTER TABLE `productiviti_report`
  ADD CONSTRAINT `productiviti_report_ibfk_2` FOREIGN KEY (`id_productiviti_assesment`) REFERENCES `productiviti_assessment` (`id_productiviti_assesment`),
  ADD CONSTRAINT `productiviti_report_ibfk_4` FOREIGN KEY (`id_order`) REFERENCES `orders` (`id_order`);

--
-- Ограничения внешнего ключа таблицы `workers`
--
ALTER TABLE `workers`
  ADD CONSTRAINT `workers_ibfk_1` FOREIGN KEY (`id_post`) REFERENCES `posts` (`id_post`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

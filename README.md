# Message_Processing_System
###### Проект по курсу ООП


### Описание

Проект реализует систему обработки входящих сообщений и представление агрегированного отчёта с подробной статистикой о полученных сообщениях в рамках заданного периода. В систему поступают сообщения из различных источников - SMS сообщения, сообщения из мессенджеров, электронная почта. Сотрудник входит в систему используя свой логин и пароль и запрашивает из системы сообщения с подконтрольных ему источников (Рабочая почта, телефон и прочие) для дальнейшей работы с ними. Сотрудник отвечает на входящие сообщения и завершает работу. В конце рабочего дня руководитель формирует отчёт о проделанной работе своих сотрудников.

### Архитектура проекта

Проект реализует классическую трехслойную архитектуру.

**Presentation layer (уровень представления)**: это тот уровень, с которым непосредственно взаимодействует пользователь. Этот уровень включает компоненты пользовательского интерфейса.

**Business layer (уровень бизнес-логики)**: содержит набор компонентов, которые отвечают за обработку полученных от уровня представлений данных, реализует всю необходимую логику приложения, все вычисления, передает уровню представления результат обработки.

**Data Access layer (уровень доступа к данным)**: хранит модели, описывающие используемые сущности.

### **Предоставляемые возможности:**

- Реализованы аутентификацию и авторизацию сотрудников
- Реализованы необходимые сущности и предусмотрена возможность их расширения в дальнейшем (Например, появление новых источников сообщений) за счет использования интерфейсов.
- Реализована иерархическую структуру подразделения и доступов к ним. Т.е. доступ до конкретной почты есть у конкретного набора сотрудников. Отчет по подразделению доступен только руководителям.
- Отчёт является иммутабельным, даже есть объект по которому был построен отчёт изменится
- Логика приложения (Application слой) покрыта UnitTest’ами
- Система имеет возможность сохранять и восстанавливать своё состояние после перезапуска.

### Сущности

- ***Сотрудник***. У сотрудника может быть руководитель либо подчиненные.
- ***Сообщение*** (Под каждый источник и общая базовая модель)
- ***Источник сообщений*** (Телефон, электронная почта, мессенджер)
- ***Учётная запись*** (Может быть закреплена как за источником сообщений, так и за сотрудником)
- ***Отчёт***

**Сообщение** может находится в одном из нескольких состояний:

- Новое (Сообщение поступило на устройство, но ещё не было получено системой)
- Полученное (Сообщение было загружено с устройства в систему)
- Обработанное (Сообщение обработано сотрудником)

**Отчёт** содержит следующую статистическую информацию:

- Кол-во сообщений обработанных его подчиненными

- Кол-во сообщений полученных на конкретное устройство

- Статистика по общему кол-ву сообщений в течение запрошенного интервала (например за сутки/смену и т.д.)

#### Система поддерживает следующие сценарии работы:

Сотрудник входит в систему, выбирает пункт меню получения сообщений. После загрузки сообщений в систему сотрудник может в течение продолжительного времени обрабатывать сообщения (отвечать на них, просто помечать прочитанными и т.д.). В конце работы выбирает пункт меню “Завершение сеанса”.

Начальник входит в систему, выбирает пункт меню работы с отчётами. Использует поиск по дате чтобы найти уже созданные отчёты. Открывает конкретные отчёты и смотрит информацию в разрезе по устройствам, по сотрудникам, статистику (кол-во сообщений всего и т.д.). После ознакомления создаёт новый отчёт за сегодня и в конце работы завершает свою смену.

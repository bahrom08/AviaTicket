
# Проект AviaTicketAPI

"AviaTicketAPI" - это учебный проект, созданный на ASP.NET 6.0 с целью изучения создания и работы с API. Вся информация, представленная с помошью API, вымышленная и создана исключительно в образовательных целях.

## Технологии

 - ASP.NET 6.0
 - Entity Framework Core 6
 - MediatR
 - AutoMapper
 - FluentValidation


## Kholbutaev Bahrom

- [@bahrom-kholbutaev](https://www.linkedin.com/in/bahrom-kholbutaev/)


## Архитектура

Архитектура проекта реализована в соответствии с принципами "[Чистой архитектуры - Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)".

Разделение на уровни проекта:
 - **Presentation Layer (Представление)**: Отвечает за представление данных и взаимодействие с пользователем.Включает в себя контроллеры API, представления данных для клиентских приложений и любую другую логику, связанную с визуализацией информации.Не содержит бизнес-логики или прямых вызовов внешних сервисов.
  
 - **Application Layer (Приложение)**: Содержит бизнес-логику и управляет потоком данных между Presentation и Domain слоями.Включает в себя сервисы приложения, которые реализуют конкретные бизнес-операции.Не зависит от конкретных технологий представления или инфраструктуры.
 
 - **Domain Layer (Домен)**: Содержит ядро бизнес-логики и правила предметной области.Включает в себя сущности (Entities), агрегаты, репозитории и сервисы, которые описывают ключевые аспекты бизнес-логики приложения.Не зависит от инфраструктуры или технологий представления.
 
 - **Infrastructure Layer (Инфраструктура)**: Содержит реализации интерфейсов, необходимых для взаимодействия с внешними системами.Включает в себя реализации репозиториев, адаптеры к базам данных, внешние API и другие технические компоненты.Зависит от внешних технологий и инструментов, таких как базы данных, HTTP-клиенты и т.д.
 Каждый из этих слоев имеет четкую ответственность и структуру, обеспечивая легкость в разработке, тестировании и поддержке приложения.







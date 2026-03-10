# Payment_Form

## Технологии
1. Backend: .NET 10, ASP.NET Core
2. ORM: Entity Framework Core
3. База данных: PostgreSQL
4. Frontend: Vue 3, Vite, Vue Router
5. HTTP: Axios

## Функции
Создание платежа через форму (Wallet Number, Account ID, Email, Phone, Amount, Currency, Comment)

Просмотр истории платежей

Статистика платежей: общая сумма, количество, по дням

Проверка легитимности запросов через API Key

## Установка
Backend

Перейти в папку backend/Payment_form/Api

Настроить appsettings.json с данными базы данных

## Создание и применение миграций

Откройте терминал и перейдите в корень проекта backend:

cd backend\Payment_form

Выполните команду для применения миграций:

dotnet ef database update --project Infrastructure --startup-project Api

## Запустить сервер:

dotnet run

Сервер будет доступен по http://localhost:5555

## Frontend

Перейти в папку frontend

## Установить зависимости:

npm install

## Запустить dev-сервер:

npm run dev

Фронтенд будет доступен по http://localhost:5174

## Как пользоваться

В форме создания платежа ввести все обязательные поля

После нажатия кнопки Create Payment появится поле для ввода API Key

API Key = "SuperSecretKey123"

История платежей и статистика отображаются на отдельных страницах

## Структура проекта

backend – сервер, API, сущности, репозитории

frontend – Vue компоненты, маршруты, Axios API

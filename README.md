# PriceObserverAPI
API для отслеживания изменений цены объекта на prinzip.su.

Методы API описаны через Swagger.

В приложении реализованы:
- Метод подписки для слежения цены,
- Метод получения списка всех отслеживаемых объектов,
- Метод обновления цен отслеживаемых объектов с последующей отправкой уведомления по email.

Сама подписка представляет из себя запись в БД (SQLite) и содержит:
- Id,
- Дата создания записи в БД,
- Email,
- Url объекта,
- Текущую цену объекта.

Не реализовано:
- Удаление подписки,
- Валидация вводимых данных,
- Автоматическое обновление данных об объекте.

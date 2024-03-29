# Deck
﻿Сортировщик колод

Предоставляет интерфейс Deck.dll:
- Создать именованную колоду карт (колода создаётся упорядоченной)
- Удалить именованную колоду
- Получить список названий колод
- Перетасовать колоду
- Получить колоду по имени (в её текущем упорядоченном/перетасованном состоянии)

Особенности реализации:

1. Необходимый функционал
- Колоды хранятся в памяти, реализован паттерн Репозиторий, позволяющий перейти на хранение в БД
- Реализация готова для стандартной колоды игральных карт (52 штуки), а также подходит для любого количества карт
- Алгоритма перетасовки 2:
	«простой» - случайная карта перекладывается на случайное место от 50 до 100 раз; 
	«эмуляцию перетасовки вручную» (колода делится примерно посередине ~40-60%, части меняются местами от 5 до 10 раз)
Алгоритм перетасовки задается через конфигурацию приложения App.Config - параметр MixerType="1",
где 1 - Ручное тасование - перекладывание по одной порции n*раз 
    2 - Простое тасование - случайная карта перекладывается в случайное место n*раз

2. Бонусом
- использован DI-контейнр Ninject
- Unit тесты (+Mock)
- добавлена возможность создания колоды 36, 52 и кастом-колоды
- Кастом колода может содержать от 1 до 4 мастей и значения карт от 2 до туза

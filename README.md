# WetControllerLab1

## О проекте
Проект контроллера влажности. Работает с бекенд АПИ. Авторизируется как пользователь и с помощью файла сценария может создавать отчёты по влажности.
Файлом сценария является тектовый файл числовыми значениями показателей влажности разделенных с помощью новой строки. Так же следует указать 128-битный идентификатор контроллера
и адрес хоста (например localhost:67211).

При запуске контроллера он берет первое значение с файла, отправляет на бекенд.
После он получает конфигурацию контроллера и определяет нужно включить полив или нет исходя из данных конфигурации.
Также следуя этим данным контроллер ожидает заданное количество времени до отправки следующего отчета.
Далее берем следущие значение с файла сценария и все продолжает по циклу до того времени пока у нас не закончатся значения.

## Используемые библиотеки
* Newtonsoft JSON. Использовался для работы с JSON форматом (бекенд использует именно его).

Проект сделан для .NET Framework 4.8 и может работать как в х32 и в x64.

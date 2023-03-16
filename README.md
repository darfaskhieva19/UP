# Компания ООО "Телеком Нева Связь"
Данная программа предназначена для автоматизации работы компании ООО "Телеком Нева Связь". В данном имеются следующие данные:
	* ER-диаграмма информационной системы;
	* Data Dictionary (словарь данных);
	* Модуль авторизации пользователя.

## Начало работы
Для начала работы Вам потребуется слонировать проект в программу Visual Studio или скачать архивную копию, после чего разархивировать ее и запустить в программе.

### Необходимые условия
Для открытия приложения Вам необходима программ Visual Studio 2022, которую можно скачать с [официального сайта](https://visualstudio.microsoft.com/ru/downloads/?sku=community&clcid=0x409). В загрузках на компьютере необходимо найти загрузочный файл и установить его.

### Установка
Для установки приложения Вы можете:
1. **Клонировать проект в Visual Studio:**
	* Скопировать [ссылку на репозиторий](https://github.com/darfaskhieva19/UP.git)
	* Запустить Visual Studio
	* Нажмите на пункт «Клонирование репозитория»
	* Вставьте ссылку на репозиторий в поле «Расположение репозитория»
	* Выберите папку на Вашем компьютере, куда нужно сохранить файл 
	* Нажмите кнопку Клонировать 
	* Можете приступать к работе
2. **Скачать архив c приложением:**

    * На данной странице нажмите на кнопку <>Code 
    * В раскрывающемся списке выберите Download ZIP 
    * Перейдите в загрузки на Вашем компьютере и разархивируйте архив 
    * В папке найдите файл с расширением .sln и запустите его

### Механизм работы
Данное приложение имеет клиент-серверную архитектуру. База данных расположена на сервере, а саму программу можно найти на клиентских ПК. Работа авторизации выглядит следующим образом:
	* При вводе номера сотрудника и по нажатию "Enter" происходит проверка. Если номер сотрудника присутствует в базе данных, то поле для ввода пароля становится доступным и в нем устанавливается курсор.
	* После вводе пароля по нажатию "Enter" проверяется корректность введенного пароля. Если он корректный, то отображается окно со сгенерированным кодом доступа. В течении 10 секунд после закрытия окна, пользователь должен ввести код доступа и авторизоваться. Если же пользователь не успевает ввести код доступа за указанное время или не успевает ввести код, то он становится не действительным и его необходимо получить заново, нажав на кнопку обновления.
	* Если авторизация проходит успешно, то сотруднику выводится сообщение с его ролью.
Для тестирования работоспособности авторизации можно воспользоваться следующими данными:
12345 - Номер, 111 - Пароль

## Авторы

* **Фасхиева Дарья** - [darfaskhieva19](https://github.com/darfaskhieva19)
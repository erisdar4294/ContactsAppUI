﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsApp
{
    /// <summary>
    /// Класс, содержащий контакт
    /// </summary>
    public class Contact : ICloneable
    {
        /// <summary>
        /// Фамилия контакта
        /// </summary>
        private string _surname;

        /// <summary>
        /// Имя контакта
        /// </summary>
        private string _name;

        /// <summary>
        /// Номер телефона контакта
        /// </summary>
        public PhoneNumber phoneNumber = new PhoneNumber();

        /// <summary>
        /// Дата рождения контакта
        /// </summary>
        private DateTime _dateOfBirth;

        /// <summary>
        /// E-mail контакта
        /// </summary>
        private string _email;

        /// <summary>
        /// ID Vkontakte контакта
        /// </summary>
        private string _idVk;

        /// <summary>
        /// Метод, устанавливающий ограничения на фамилию контакта
        /// </summary>
        public string Surname
        {
            get { return _surname; }
            set
            {
                //Фамилия не может быть длиннее 50 символов
                if (value.Length > 50)
                {
                    throw new ArgumentException("Введите фамилию, длиной менее 50 символов");
                }

                //Фамилия не может быть короче 2 символов
                if (value.Length < 2)
                {
                    throw new ArgumentException("Введите фамилию, длиной более 2 символов");
                }

                //Проверка на пустую строку
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Вы ввели пустую строку. Повторите ввод");
                }
                else
                {
                    //Вся строка в нижний регистр
                    value.ToLower();

                    //Представляем строку как массив чар
                    char[] familyChar = value.ToCharArray();

                    //1 элемент массива в верхний регистр
                    familyChar[0] = char.ToUpper(familyChar[0]);

                    //Переписываем в стринг
                    string familyString = new string(familyChar);

                    //Вносим данные
                    _surname = familyString;
                }
            }
        }

        /// <summary>
        /// Метод, устанавливающий ограничения на имя контакта
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                //Имя не может быть длиннее 50 символов
                if (value.Length > 50)
                {
                    throw new ArgumentException("Введите имя, длиной менее 50 символов");
                }

                //Имя не может быть короче 2 символов
                if (value.Length < 2)
                {
                    throw new ArgumentException("Введите имя, длиной более 2 символов");
                }

                //Проверка на пустую строку
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Вы ввели пустую строку. Повторите ввод");
                }
                else
                {
                    //Вся строка в нижний регистр
                    value.ToLower();

                    //Представляем строку как массив чар
                    char[] nameChar = value.ToCharArray();

                    //1 элемент массива в верхний регистр
                    nameChar[0] = char.ToUpper(nameChar[0]);

                    //Переписываем в стринг
                    string nameString = new string(nameChar);

                    _name = nameString;
                }
            }
        }

        /// <summary>
        /// Ограничение на устанавливаемую дату рождения (минимум 1 января 1900)
        /// </summary>
        private readonly DateTime _dateMinimum = new DateTime(1900, 01, 01);

        /// <summary>
        /// Метод, устанавливающий ограничения на дату рождения контакта
        /// </summary>
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                //Дата рождения не может быть раньше 1 января 1900 года
                if (value < _dateMinimum)
                {
                    throw new ArgumentException("Введенная дата не может быть раньше 1900 года");
                }

                //Дата рождения не может быть больше нынешней даты
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Дата рождения не может быть позже нынешней");
                }
                else
                    _dateOfBirth = value;
            }
        }

        /// <summary>
        /// Метод, устанавливающий ограничения на E-mail контакта
        /// </summary>
        public string Email
        {
            get { return _email; }
            set
            {
                //E-mail не может быть длиннее 50 символов
                if (value.Length > 50)
                {
                    throw new ArgumentException("Введите e-mail, длиной менее 50 символов");
                }
                //Проверка на пустую строку
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Вы ввели пустую строку. Повторите ввод");
                }
                else
                    _email = value;
            }
        }

        /// <summary>
        /// Метод, устанавливающий ограничения на ID Vkontakte контакта
        /// </summary>
        public string IdVk
        {
            get { return _idVk; }
            set
            {
                //ID не может быть длиннее 15 символов
                if (value.Length > 15)
                {
                    throw new ArgumentException("Введите ID, длиной менее 15 символов");
                }
                //Проверка на пустую строку
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Вы ввели пустую строку. Повторите ввод");
                }
                else
                    _idVk = value;
            }
        }

        /// <summary>
        /// Конструктор класса с 6 входными параметрами
        /// </summary>
        public Contact(long phoneNumber, string name, string surname, string email, DateTime dateOfBirth,
            string idVk)
        {
            this.phoneNumber.Number = phoneNumber;
            Name = name;
            Surname = surname;
            Email = email;
            DateOfBirth = dateOfBirth;
            IdVk = idVk;
        }

        /// <summary>
        /// Реализация клонирования
        /// </summary>
        /// <returns>Возвращает объект - клон контакта, с полями: номер телефона, имя, фамилия, емейл, дата рождения, айди вк.</returns>
        public object Clone()
        {
            return new Contact(phoneNumber.Number, Name, Surname, Email, DateOfBirth, IdVk);
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Contact()
        {   }
    }
}


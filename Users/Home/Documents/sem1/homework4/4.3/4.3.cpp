#include <stdio.h>
#include <stdlib.h>
#include <clocale>
#include <string.h>
#include <ctype.h>
#include "options.h"
#include <windows.h>

void options(int key, PersonalData *phonebook)
{
    switch(key)
    {
    case 1:
        addingData(phonebook);
        break;
    case 2:
        printData(phonebook);
        break;
    case 3:
        seekingByName(phonebook);
        break;
    case 4:
        seekingByPhone(phonebook);
        break;
    case 5:
        saveToFile(phonebook);
        break;
    }
}

int mainMenu(PersonalData *phonebook)
{
    int key = 1;
    printf("Добро пожаловать! Это телефонный справочник. Вы можете управлять данными, хранящимися в нем. Нажмите:\n1, чтобы добавить запись;\n2, чтобы вывести все данные на экран;\n3, чтобы найти телефон по имени;\n4, чтобы найти имя по телефону;\n5, чтобы сохранить текущие данные в файл;\n0, чтобы выйти.\n");
    scanf("%d", &key);
    if (key == 0)
    {
        printf("До свидания!");
        return 0;
    }
    options(key, phonebook);
    mainMenu(phonebook);
}

void test(PersonalData *phonebook)
{
    for (int i = 1; i < 5; i++)
    {
        options(i, phonebook);
    }
}

int main()
{
    SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
    setlocale(LC_ALL, "Russian");
    FILE *file = fopen("C:\\phonebook.txt", "a+");
    personalData *phonebook = (personalData*) malloc(MAX * sizeof(personalData));
    int line = 0;
    while (!feof(file))
    {
        char *buffername = new char[MAX];
        char *bufferphonenumber = new char[MAX];
        int readBytes = fscanf(file, "%s %s", buffername, bufferphonenumber);
        if (readBytes < 0)
        {
            break;
        }
        phonebook[line].name = buffername;
        phonebook[line].phoneNumber = bufferphonenumber;
        line++;
    }
    fclose(file);
    for (int i = line; i < MAX; i++)
    {
        phonebook[i].name = "*пустое имя*";
        phonebook[i].phoneNumber = "*пустой номер телефона*";
    }
    mainMenu(phonebook);
    return EXIT_SUCCESS;
}

#include <stdio.h>
#include <stdlib.h>
#include <clocale>
#include <string.h>
#include <ctype.h>

struct personalData
{
    char name[50];
    int phoneNumber;
};

void addingData()
{
    printf("Здесь вы можете добавлять записи. Чтобы выйти в главное меню, нажмите 0, или введите номер строки, которую вы хотели бы изменить.\n");
    int key = -1;
    scanf("%d ", &key);
    if (key == 0)
    {
        return 0;
    }
    else
    {
        printf()
        printf("")


    }


}



void mainMenu()
{
    printf("Добро пожаловать! Это телефонный справочник. Вы можете управлять данными, хранящимися в нем. Нажмите:\n1, чтобы добавить запись;\n2, чтобы вывести все данные на экран;\n3, чтобы найти телефон по имени;\n4, чтобы найти имя по телефону;\n5, чтобы сохранить текущие данные в файл.\n");
    char key;
    scanf("%c ", &key);
    switch key()
    {
    case 0:
        return 0;
    case 1:
        addingData();
    case 2:
        printData();
    case 3:
        seekingByName();
    case 4:
        seekingByPhone();
    case 5:
        saveTjoFile();
    }
}

int main()
{
    setlocale(LC_ALL, "Russian");
    FILE *file = fopen("C:\\phonebook.txt", "a+");
    char *data[100] = {};
    int line = 0;
    while (!feof(file))
    {
        char *buffer = new char[100];
        const int readBytes = fscanf(file, "%s", buffer);
        if (readBytes < 0)
        {
            break;
        }
        data[line] = buffer;
        line++;
    }
    fclose(file);
    personalData *id = new
    struct personalData phonebook[100];
    for (int line = 0; line < 100; line++)
    {
        char[] word = " ";
        do
        {
        word = scanf("%s", &data[line]);
        {
            phonebook[line].name = word;
        }


        while (letter != ' ')
        {
            phonebook[line].phoneNumber += letter;
        }
        }
    }
    mainMenu();
    return EXIT_SUCCESS;
}

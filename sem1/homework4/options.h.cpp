#pragma once

void addingData(PersonalData *phonebook)
{
    printf("Здесь вы можете добавлять записи. Чтобы выйти в главное меню, нажмите 0, или введите номер строки, которую вы хотели бы изменить.\n");
    int id = -1;
    scanf("%d", &id);
    while (id != 0)
    {
        printf("%s %s\n", phonebook[id].name, phonebook[id].phoneNumber);
        printf("Чтобы изменить имя, нажмите 1, чтобы изменить номер телефона, нажмите 2\n");
        int key = -1;
        scanf("%d", &key);
        char *newdata = new char[MAX]{};
        printf("Введите изменения:\n");
        scanf("%s", newdata);
        if (key == 1)
        {
            phonebook[id].name = newdata;
        }
        else if (key == 0)
        {
            phonebook[id].phoneNumber = newdata;
        }
        printf("Данные изменены. Если хотите продолжить, введите номер строки, которую вы хотели бы изменить. Для выхода нажмите 0.\n");
        addingData(phonebook);
    }
    mainMenu(phonebook);
}

void printData(PersonalData *phonebook)
{
    printf("Телефонная книга сейчас выглядит так:\n");
    for (int j = 0; j < MAX; j++)
    {
        printf("%s\t%s\n", phonebook[j].name, phonebook[j].phoneNumber);
    }
    printf("Переход в главное меню;\n");
}

void seekingByName(PersonalData *phonebook)
{
    printf("Это поиск по имени. Введите имя:\n");
    char *nametoseek = new char[MAX]{};
    scanf("%s", nametoseek);
    printf("%s", nametoseek);
    for (int i = 0; i < MAX; i++)
    {
        if (phonebook[i].name == nametoseek)
        {
            printf("Номер телефона абонента %s: %s", phonebook[i].name, phonebook[i].phoneNumber);
        }
    }
}

void seekingByPhone(PersonalData *phonebook)
{
    printf("Это поиск по номеру телефона. Введите номер:\n");
    char *numbertoseek = new char[MAX]{};
    scanf("%s", numbertoseek);
    for (int i = 0; i < MAX; i++)
    {
        if (phonebook[i].phoneNumber == numbertoseek)
        {
            printf("Имя абонента %s: %s", phonebook[i].phoneNumber, phonebook[i].name);
        }
    }
}

void saveToFile(PersonalData *phonebook)
{
    FILE *file = fopen("C:\\phonebook.txt", "w");
    for (int i = 0; i < MAX; i++)
    {
        fprintf(file, "%s\t%s\n", phonebook[i].name, phonebook[i].phoneNumber);
    }
    fclose(file);
    printf("Данные сохранены!");
}

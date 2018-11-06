#pragma once
#define MAX 100

typedef struct PersonalData
{
    char* name = "9";
    char* phoneNumber = "8";
} personalData;

void skipToMenu()
{
    printf("Переход в главное меню;\n\n");
}

void addingData(PersonalData *phonebook)
{
    printf("Здесь вы можете добавлять записи. Чтобы выйти в главное меню, нажмите 0, или введите номер строки, которую вы хотели бы изменить.\n");
    int id = 0;
    scanf("%d", &id);
    id--;
    while (id > -1)
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
        else if (key == 2)
        {
            phonebook[id].phoneNumber = newdata;
        }
        printf("Данные изменены. Если хотите продолжить, введите номер строки, которую вы хотели бы изменить. Для выхода нажмите 0.\n");
        scanf("%d", &id);
        id--;
    }
    skipToMenu();
}

void printData(PersonalData *phonebook)
{
    printf("Телефонная книга сейчас выглядит так:\n");
    for (int j = 0; j < MAX; j++)
    {
        if ((phonebook[j].name != NULL) || (phonebook[j].phoneNumber != NULL))
        {
            printf("%d. %s\t%s\n", j + 1, phonebook[j].name, phonebook[j].phoneNumber);
        }
    }
    skipToMenu();
}

void seekingByName(PersonalData *phonebook)
{
    printf("Это поиск по имени. Введите имя:\n");
    char *nametoseek = new char[MAX]{};
    scanf("%s", nametoseek);
    bool isSomeone;
    for (int i = 0; i <= MAX; i++)
    {
        if (i == MAX)
        {
            if (!isSomeone)
            {
                printf("Абонент с таким именем не найден;\n");
            }
            break;
        }
        else if (!(strcmp(phonebook[i].name, nametoseek)))
        {
            printf("Номер телефона абонента %s: %s\n", phonebook[i].name, phonebook[i].phoneNumber);
            isSomeone = true;
        }
    }
    skipToMenu();
}

void seekingByPhone(PersonalData *phonebook)
{
    printf("Это поиск по номеру телефона. Введите номер:\n");
    char *numbertoseek = new char[MAX]{};
    scanf("%s", numbertoseek);
    bool isNumber;
    for (int i = 0; i <= MAX; i++)
    {
        if (i == MAX)
        {
            if (!isNumber)
            {
                printf("Абонент с таким номером телефона не найден;\n");
            }
            break;
        }
        else if (!strcmp(phonebook[i].phoneNumber, numbertoseek))
        {
            printf("Имя абонента %s: %s\n", phonebook[i].phoneNumber, phonebook[i].name);
            isNumber = true;
        }
    }
    skipToMenu();
}

void saveToFile(PersonalData *phonebook)
{
    FILE *file = fopen("phonebook.txt", "w");
    for (int i = 0; i < MAX; i++)
    {
        fprintf(file, "%s\t%s\n", phonebook[i].name, phonebook[i].phoneNumber);
    }
    fclose(file);
    printf("Данные сохранены!\n");
}

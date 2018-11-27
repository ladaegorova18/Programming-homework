#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#include "options.h"

void skipToMenu()
{
	printf("Переход в главное меню;\n\n");
}

int scanningNumber()
{
	int id = 0;
	scanf("%d", &id);
	return id;
}

char* scanningString()
{
	char* stringToScan = new char[MAX] {};
	scanf("%s", stringToScan);
	return stringToScan;
}

void adding(PersonalData *phonebook, int id)
{
	while (id != 0)
	{
		id--;
		printf("%s %s\n", phonebook[id].name, phonebook[id].phoneNumber);
		printf("Чтобы изменить имя, нажмите 1, чтобы изменить номер телефона, нажмите 2\n");
		int key = -1;
		scanf("%d", &key);
		char *newData = new char[MAX] {};
		printf("Введите изменения:\n");
		scanf("%s", newData);
		if (key == 1)
		{
			phonebook[id].name = newData;
		}
		else if (key == 2)
		{
			phonebook[id].phoneNumber = newData;
		}
		printf("Данные изменены. Если хотите продолжить, введите номер строки, которую вы хотели бы изменить. Для выхода нажмите 0.\n");
		id = scanningNumber();
	}
}

void addingData(PersonalData *phonebook)
{
	printf("Здесь вы можете добавлять записи. Чтобы выйти в главное меню, нажмите 0, или введите номер строки, которую вы хотели бы изменить.\n");
	int id = scanningNumber();
	adding(phonebook, id);
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

void seekingNameFunction(PersonalData *phonebook, char* nameToSeek)
{
	bool isSomeone = false;
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
		else if (!(strcmp(phonebook[i].name, nameToSeek)))
		{
			printf("Номер телефона абонента %s: %s\n", phonebook[i].name, phonebook[i].phoneNumber);
			isSomeone = true;
		}
	}
}

void seekingByName(PersonalData *phonebook)
{
	printf("Это поиск по имени. Введите имя:\n");
	char *nameToSeek = new char[MAX] {};
	nameToSeek = scanningString();
	seekingNameFunction(phonebook, nameToSeek);
	delete[] nameToSeek;
	skipToMenu();
}

void seekingByPhone(PersonalData *phonebook)
{
	printf("Это поиск по номеру телефона. Введите номер:\n");
	char *numberToSeek = new char[MAX] {};
	scanf("%s", numberToSeek);
	bool isNumber = false;
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
		else if (!strcmp(phonebook[i].phoneNumber, numberToSeek))
		{
			printf("Имя абонента %s: %s\n", phonebook[i].phoneNumber, phonebook[i].name);
			isNumber = true;
		}
	}
	delete[] numberToSeek;
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

void options(int key, PersonalData *phonebook)
{
	switch (key)
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

void mainText()
{
	printf("Добро пожаловать! Это телефонный справочник. Вы можете управлять данными, хранящимися в нем. Нажмите:\n");
	printf("1, чтобы добавить запись;\n");
	printf("2, чтобы вывести все данные на экран;\n");
	printf("3, чтобы найти телефон по имени;\n");
	printf("4, чтобы найти имя по телефону;\n");
	printf("5, чтобы сохранить текущие данные в файл;\n");
	printf("0, чтобы выйти.\n");
}

void mainMenu(PersonalData *phonebook)
{
	int key = 1;
	mainText();
	scanf("%d", &key);
	while (key != 0)
	{
		options(key, phonebook);
		mainText();
		scanf("%d", &key);
	}
	printf("До свидания!");
}

void test()
{
	FILE *file = fopen("phonebook.txt", "r");
	PersonalData *testPhoneBook = new PersonalData[MAX];
	bool testPassed = false;
	int line = 0;
	if (!file)
	{
		printf("File not found!");
		return;
	}
	while (!feof(file))
	{
		char *bufferName = new char[MAX];
		char *bufferPhoneNumber = new char[MAX];
		int readBytes = fscanf(file, "%s %s", bufferName, bufferPhoneNumber);
		if (readBytes < 0)
		{
			delete[] bufferName;
			delete[] bufferPhoneNumber;
			break;
		}
		testPhoneBook[line].name = bufferName;
		testPhoneBook[line].phoneNumber = bufferPhoneNumber;
		line++;
	}
	fclose(file);

	delete[] testPhoneBook;
	printf("Test passed\n");
}
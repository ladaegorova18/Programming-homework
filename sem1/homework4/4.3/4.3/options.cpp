#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#include <assert.h>
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

void adding(PersonalData *phonebook, int id, int key, const char newData[])
{
	if (key == 1)
	{
		if (!phonebook[id].name)
		{
			phonebook[id].name = new char[strlen(newData) + 1];
		}
		strcpy(phonebook[id].name, newData);
	}
	else if (key == 2)
	{
		if (!phonebook[id].phoneNumber)
		{
			phonebook[id].phoneNumber = new char[strlen(newData) + 1];
		}
		strcpy(phonebook[id].phoneNumber, newData);
	}
}

void addingData(PersonalData *phonebook)
{
	int id = scanningNumber();
	while (id != 0)
	{
		id--;
		if (phonebook[id].name) 
		{
			printf("%s %s\n", phonebook[id].name, phonebook[id].phoneNumber);
		}
		printf("Чтобы изменить имя, нажмите 1, чтобы изменить номер телефона, нажмите 2:\n");
		int key = -1;
		scanf("%d", &key);
		char newData[MAX] {};
		printf("Введите изменения:\n");
		scanf("%s", newData);
		adding(phonebook, id, key, newData);
		printf("Данные изменены. Если хотите продолжить, введите номер строки, которую вы хотели бы изменить. Для выхода нажмите 0.\n");
		id = scanningNumber();
	}
	skipToMenu();
}

void printData(PersonalData *phonebook)
{
	for (int j = 0; j < MAX; j++)
	{
		if ((phonebook[j].name != nullptr) || (phonebook[j].phoneNumber != nullptr))
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
		else if ((phonebook[i].name != nullptr) && (!(strcmp(phonebook[i].name, nameToSeek))))
		{
			printf("Номер телефона абонента %s: %s\n", phonebook[i].name, phonebook[i].phoneNumber);
			isSomeone = true;
		}
	}
}

void seekingByName(PersonalData *phonebook)
{
	char *nameToSeek = new char[MAX] {};
	nameToSeek = scanningString();
	seekingNameFunction(phonebook, nameToSeek);
	delete[] nameToSeek;
	skipToMenu();
}

void seekingNumberFunction(PersonalData *phonebook, char* numberToSeek)
{
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
		else if ((!phonebook[i].phoneNumber) && (!strcmp(phonebook[i].phoneNumber, numberToSeek)))
		{
			printf("Имя абонента %s: %s\n", phonebook[i].phoneNumber, phonebook[i].name);
			isNumber = true;
		}
	}
}

void seekingByPhone(PersonalData *phonebook)
{
	char *numberToSeek = new char[MAX] {};
	scanf("%s", numberToSeek);
	seekingNumberFunction(phonebook, numberToSeek);
	delete[] numberToSeek;
	skipToMenu();
}

void saveToFile(PersonalData *phonebook)
{
	FILE *file = fopen("phonebook.txt", "w");
	for (int i = 0; i < MAX; i++)
	{
		if (phonebook[i].name)
		{
			fprintf(file, "%s\t%s\n", phonebook[i].name, phonebook[i].phoneNumber);
		}
	}
	fclose(file);
}

void options(int key, PersonalData *phonebook)
{
	switch (key)
	{
	case 1:
		printf("Здесь вы можете добавлять записи. Чтобы выйти в главное меню, нажмите 0, или введите номер строки, которую вы хотели бы изменить.\n");
		addingData(phonebook);
		break;
	case 2:
		printf("Телефонная книга сейчас выглядит так:\n");
		printData(phonebook);
		break;
	case 3:
		printf("Это поиск по имени. Введите имя:\n");
		seekingByName(phonebook);
		break;
	case 4:
		printf("Это поиск по номеру телефона. Введите номер:\n");
		seekingByPhone(phonebook);
		break;
	case 5:
		saveToFile(phonebook);
		printf("Данные сохранены!\n");
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

void saveTest(PersonalData *phonebook)
{
	FILE *file = fopen("testFile.txt", "w");
	for (int i = 0; i < MAX; i++)
	{
		if (phonebook[i].name != nullptr)
		{
			fprintf(file, "%s\t%s", phonebook[i].name, phonebook[i].phoneNumber);
		}
		else
		{
			fprintf(file, "\n");
		}
	}
	fclose(file);
}

void test()
{
	bool testPassed = 0;
	FILE *file = fopen("testFile.txt", "a+");
	int line = 0;
	if (!file)
	{
		printf("File not found!");
		return;
	}
	PersonalData *testPhoneBook = new PersonalData[MAX];
	const char *nameToAdd = "Jack";
	const char *numberToAdd = "12345";
	adding(testPhoneBook, 0, 1, nameToAdd);
	adding(testPhoneBook, 0, 2, numberToAdd);
	saveTest(testPhoneBook);
	const char *result = "Jack	12345";
	char *buffer = new char[11];
	fgets(buffer, 11, file);
	fclose(file);
	assert(strcmp(buffer, result) == 0);
	delete[] buffer;
	delete[] testPhoneBook;
	printf("Test passed\n");
}
#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <locale>
#include "options.h"

int main()
{
	setlocale(LC_ALL, "Russian");
	FILE *file = fopen("phonebook.txt", "a+");
	PersonalData *phonebook = new PersonalData[MAX];
	int line = 0;
	while (!feof(file))
	{
		char *bufferName = new char[MAX];
		char *bufferPhoneNumber = new char[MAX];
		int readBytes = fscanf(file, "%s %s", bufferName, bufferPhoneNumber);
		if (readBytes < 0)
		{
			break;
		}
		phonebook[line].name = bufferName;
		phonebook[line].phoneNumber = bufferPhoneNumber;
		line++;
	}
	fclose(file);
	for (int i = line; i < MAX; i++)
	{
		phonebook[i].name = "*пустое имя*";
		phonebook[i].phoneNumber = "*пустой номер телефона*";
	}
	/*test(phonebook);*/
	mainMenu(phonebook);
	delete[] phonebook;
	return EXIT_SUCCESS;
}

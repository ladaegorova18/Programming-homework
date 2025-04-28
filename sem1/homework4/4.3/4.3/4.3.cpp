#define _CRT_SECURE_NO_WARNINGS
#include "pch.h"
#include <stdio.h>
#include <stdlib.h>
#include <clocale>
#include "options.h"

int main()
{
	test();
	setlocale(LC_ALL, "rus");
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
			delete[] bufferName;
			delete[] bufferPhoneNumber;
			break;
		}
		phonebook[line].name = bufferName;
		phonebook[line].phoneNumber = bufferPhoneNumber;
		line++;
	}
	fclose(file);
	mainMenu(phonebook);
	delete[] phonebook;
	return EXIT_SUCCESS;
}

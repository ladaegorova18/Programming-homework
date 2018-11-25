#ifndef HEADER_H
#define HEADER_H

#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>

struct PersonalData
{
	const char *name = " ";
	const char *phoneNumber = " ";
};

const int MAX = 100;

void mainMenu(PersonalData *phonebook);
void addingData(PersonalData *phonebook);
void printData(PersonalData *phonebook);
void seekingByName(PersonalData *phonebook);
void seekingByPhone(PersonalData *phonebook);
void saveToFile(PersonalData *phonebook);

void options(int key, PersonalData *phonebook);


#endif // !HEADER_H

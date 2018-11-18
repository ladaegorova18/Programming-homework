#ifndef HEADER_H
#define HEADER_H

#include <stdio.h>
#include <stdlib.h>

struct PersonalData
{
	const char *name = nullptr;
	const char *phoneNumber = nullptr;
};

const int MAX = 100;

void mainText();
void mainMenu(PersonalData *phonebook);
void test(PersonalData *phonebook);
void skipToMenu();
void addingData(PersonalData *phonebook);
void printData(PersonalData *phonebook);
void seekingByName(PersonalData *phonebook);
void seekingByPhone(PersonalData *phonebook);
void saveToFile(PersonalData *phonebook);
void options(int key, PersonalData *phonebook);

#endif // !HEADER_H

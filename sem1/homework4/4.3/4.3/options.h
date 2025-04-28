#ifndef HEADER_H
#define HEADER_H

#define _CRT_SECURE_NO_WARNINGS
#include "pch.h"
#include <stdio.h>
#include <stdlib.h>

const int MAX = 100;

struct PersonalData
{
	char *name = nullptr;
	char *phoneNumber = nullptr;
};

void mainMenu(PersonalData *phonebook);
void addingData(PersonalData *phonebook);
void printData(PersonalData *phonebook);
void seekingByName(PersonalData *phonebook);
void seekingByPhone(PersonalData *phonebook);
void saveToFile(PersonalData *phonebook);

void options(int key, PersonalData *phonebook);

void test();


#endif // !HEADER_H

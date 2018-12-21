#pragma once
#include <string>

struct Element
{
	std::string value;
	Element* next;
};

struct DynList
{
	Element* head;
};

DynList* makeList();

void insertion(DynList *myList, std::string value);

void printData(DynList *myList);

void deleteList(DynList *myList);
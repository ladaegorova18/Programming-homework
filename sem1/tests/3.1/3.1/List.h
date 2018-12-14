#pragma once

struct Element
{
	int value;
	int freq = 0;
	Element* next;
};

struct DynList
{
	Element* head;
};

void insertion(DynList *myList, int newValue);

void printData(DynList *myList);

void deleteList(DynList *myList);
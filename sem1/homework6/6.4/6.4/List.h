#ifndef HEADER_H
#define HEADER_H
#include <iostream>

struct Element
{
    std::string name;
	std::string phoneNumber;
    Element* next;
};

struct DynList
{
	Element *head;
	Element *tail;
	size_t size;
};

void makingList(DynList *myList);
bool isEmpty(DynList *myList);
void addingData(DynList *myList, std::string tempName, std::string tempPhoneNumber);
void printData(Element *head);
DynList* mergeSort(DynList *myList);
Element* getMiddle(Element* head);
DynList* merge(DynList *&firstList, DynList *&secondList);
bool inEquality(std::string first, std::string second);

#endif // HEADER_H

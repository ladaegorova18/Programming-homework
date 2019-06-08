#pragma once
#include <string>

struct Element;

struct DynList;

DynList* makeList();

void insertion(DynList *myList, std::string value);

void printData(DynList *myList);

void deleteList(DynList *myList);

Element* getHead(DynList* myList);

std::string getValue(Element* temp);

Element* getNext(Element* temp);

void deleting(Element *temp);
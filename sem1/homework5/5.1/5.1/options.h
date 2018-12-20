#pragma once

struct Element;

struct DynList;

DynList* makingList();

Element* getHead(DynList *myList);

void deleting(DynList *myList, int value);

void deleteList(DynList *myList);

void addingData(DynList *mylist);

void deleteData(DynList *myList);

bool isEmpty(DynList *myList);

void printData(DynList *myList);

void insertion(DynList *myList, int newValue);

Element* getNext(Element* temp);

int getValue(Element *temp);


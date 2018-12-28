#pragma once

#pragma once

struct Element;

struct DynList;

DynList* makingList();

Element* getHead(DynList *myList);

void deleteList(DynList *&myList);

void insertion(DynList *myList, const int data, bool isStart);

bool isEmpty(DynList *myList);

Element* getNext(Element* temp);

int maxCount(DynList *&myList);

#pragma once

#pragma once

struct Element;

struct DynamicList;

DynamicList* makingList();

Element* getHead(DynamicList *myList);

void deleteList(DynamicList *&myList);

void insertion(DynamicList *myList, const int data, bool isStart);

bool isEmpty(DynamicList *myList);

Element* getNext(Element* temp);

int maxCount(DynamicList *&myList);

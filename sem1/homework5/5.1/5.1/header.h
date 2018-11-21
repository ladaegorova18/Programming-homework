#ifndef HEADER_H
#define HEADER_H

struct Element
{
    int value;
    Element* next;
};

struct DynList
{
    Element *head;
};

bool isEmpty(DynList *myList);
void insertion(DynList *myList, int newValue);
void addingData(DynList *myList);
void deleteData(DynList *myList);
void printData(DynList *myList);

#endif // HEADER_H

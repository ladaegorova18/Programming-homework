#ifndef HEADER_H
#define HEADER_H

struct Element
{
    int value;
    Element* next;
};

struct dynList
{
    Element *head;
};

bool isEmpty(dynList *mylist);
int insertion(dynList *mylist, int newValue);
void addingData(dynList *mylist);
void deleteData(dynList *mylist);
void printData(dynList *mylist);

#endif // HEADER_H

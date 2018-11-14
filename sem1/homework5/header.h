#ifndef HEADER_H
#define HEADER_H

typedef struct Element
{
    int value;
    Element* next;
} Element;

struct dynList
{
    Element *head;
};

bool isEmpty(dynList *mylist);
int insertion(dynList *mylist, int newValue);
int addingData(dynList *mylist);
void deleteData(dynList *mylist);
void printData(dynList *mylist);

#endif // HEADER_H

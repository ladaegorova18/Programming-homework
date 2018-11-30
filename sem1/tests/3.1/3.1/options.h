#ifndef OPTIONS_H
#define OPTIONS_H

struct Element
{
    int value;
    Element* next;
};

struct DynList
{
    Element *head;
	Element *tail;
	int size;
};

bool isEmpty(DynList *myList);
void insertion(DynList *myList, int newValue);
void deleteList(DynList *myList);

#endif // OPTIONS_H

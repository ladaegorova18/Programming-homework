#include "pch.h"
#include <iostream>
#include "options.h"
using namespace std;

bool isEmpty(DynList *myList)
{
	return (myList->head == nullptr);
}

void insertion(DynList *myList, int newValue)
{
	myList->size++;
	Element* data = new Element;
	data->next = myList->head;
	data->value = newValue;
	if (myList->head != nullptr)
	{
		myList->tail->next = data;
		myList->tail = data;
	}
	else
	{
		myList->head = data;
		myList->tail = data;
	}
}

void deleteList(DynList *myList)
{
	Element *current = myList->head;
	Element *previous = nullptr;
	while (current)
	{
		previous = current;
		current = current->next;
		delete previous;
	}
	delete myList;
}
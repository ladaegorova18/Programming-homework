#include "pch.h"
#include <iostream>
#include "List.h"
using namespace std;

struct DynList
{
	Element* head;
};

struct Element
{
	std::string value;
	Element* next;
};

Element* getHead(DynList* myList)
{
	return myList->head;
}

std::string getValue(Element* temp)
{
	return temp->value;
}

Element* getNext(Element* temp)
{
	return temp->next;
}

bool isEmpty(DynList *myList)
{
	return (myList->head == nullptr);
}

DynList* makeList()
{
	DynList *list = new DynList();
	list->head = nullptr;
	return list;
}

void insertion(DynList *myList, std::string newValue)
{
	Element* data = new Element;
	data->value = newValue;
	if (isEmpty(myList))
	{
		myList->head = data;
		data->next = nullptr;
		return;
	}
	Element* current = myList->head;
	Element* previous = nullptr;
	while (current)
	{
		if (current->value == newValue)
		{
			delete data;
			return;
		}
		if (current->value > newValue)
		{
			data->next = current;
			if (previous != nullptr)
			{
				previous->next = data;
			}
			else
			{
				myList->head = data;
			}
			return;
		}
		else if (current->next == nullptr)
		{
			current->next = data;
			data->next = nullptr;
			return;
		}
		previous = current;
		current = current->next;
	}
	previous->next = data;
	return;
}
void printData(DynList *myList)
{
	struct Element *current = myList->head;
	while (current)
	{
		cout << current->value;
		cout << endl;
		current = current->next;
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

void deleting(Element *temp)
{
	delete temp;
}
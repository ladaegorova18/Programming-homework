#include "pch.h"
#include <iostream>
#include "options.h"
using namespace std;

struct Element
{
	int value;
	Element* next;
};

struct DynList
{
	Element* head;
};

DynList* makingList()
{
	DynList* list = new DynList();
	list->head = nullptr;
	return list;
}

Element* getHead(DynList* list)
{
	return list->head;
}

bool isEmpty(DynList *myList)
{
	return (myList->head == nullptr);
}

Element* getNext(Element* temp)
{
	return temp->next;
}

int getValue(Element* temp)
{
	return temp->value;
}

void insertion(DynList *myList, int newValue)
{
    Element* data = new Element;
    data->value = newValue;
    if (isEmpty(myList))
    {
		myList->head = data;
        data->next = nullptr;
        return;
    }
	Element* previous = nullptr;
    Element* current = myList->head;
    while (current)
    {
        if (current->value >= newValue)
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
			delete data;
			delete current;
			delete previous;
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
	delete current;
	delete data;
	delete previous;
	return;
}

void addingData(DynList *mylist)
{
    char key = ' ';
    cin >> key;
    while (key != 'Q')
    {
        int newValue = key - '0';
        insertion(mylist, newValue);
        cin >> key;
    }
}

bool deleting(DynList *myList, int value)
{
	Element* current = myList->head; // проходим по всем элементам и сравниваем каждый с нашим "заказом"
	Element* previous = nullptr;
	while (current != nullptr)
	{
		if (current->value == value) // если совпали, то смотрим на предыдущий
		{
			if (previous == nullptr) // если его нет, то мы находимся в начале списка и нужно заменить head на следующий
			{
				Element* temp = myList->head;
				myList->head = myList->head->next;
				delete temp;
			}
			else
			{
				previous->next = current->next; // если он есть, то делаем следующим за ним не текущий, а следующий за текущим
				delete current;
			}
			return true;
		}
		previous = current;
		current = current->next;
	}
	return false;
}

bool deleteData(DynList *myList)
{
    char key = ' ';
    cin >> key;
    if (key != 'Q')
    {
        int value = (int)key - '0';
		return deleting(myList, value);
    }
	return false;
}

void printData(DynList *myList)
{
    {
        Element *current = myList->head;
        while (current)
        {
            cout << current->value << endl;
            cout << endl;
            current = current->next;
        }
		delete current;
    }
}

void deleteElements(Element *&head)
{
	Element *current = head;
	Element *previous = nullptr;
	while (current)
	{
		previous = current;
		current = current->next;
		delete previous;
	}
	delete current;
}

void deleteList(DynList *&myList)
{
	deleteElements(myList->head);
	delete myList;
}

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
    Element* data = new Element;
    Element* previous = nullptr;
    data->value = newValue;
    if (isEmpty(myList))
    {
		myList->head = data;
        data->next = nullptr;
        return;
    }
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

void deleting(DynList *myList, int value)
{
	Element* current = myList->head; // проходим по всем элементам и сравниваем каждый с нашим "заказом"
	Element* previous = nullptr;
	while (current != nullptr)
	{
		if (current->value == value) // если совпали, то смотрим на предыдущий
		{
			if (previous == nullptr) // если его нет, то мы находимся в начале списка и нужно заменить head на следующий
			{
				myList->head = myList->head->next;
			}
			else
			{
				previous->next = current->next; // если он есть, то делаем следующим за ним не текущий, а следующий за текущим
			}
		}
		previous = current;
		current = current->next;
	}
}

void deleteData(DynList *myList)
{
    char key = ' ';
    cin >> key;
    if (key != 'Q')
    {
        int value = (int)key - '0';
		deleting(myList, value);
    }
}

void printData(DynList *myList)
{
    {
        struct Element *current = myList->head;
        while (current)
        {
            cout << current->value << endl;
            cout << endl;
            current = current->next;
        }
		delete current;
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

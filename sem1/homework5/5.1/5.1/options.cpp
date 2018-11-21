#include "pch.h"
#include <iostream>
#include "header.h"
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
    else
    {
        Element* current = myList->head;
        while (current != nullptr)
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
			previous = current;
			current = current->next;
		}
		previous->next = data;
		delete current;
    }
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

void deleteData(DynList *mylist)
{
    char key = ' ';
    cin >> key;
    if (key != 'Q')
    {
        int order = (int)key - 48;
        Element* current = mylist->head; // проходим по всем элементам и сравниваем каждый с нашим "заказом"
        Element* previous = nullptr;
        while (current != nullptr)
        {
            if (current->value == order) // если совпали, то смотрим на предыдущий
            {
                if (previous == nullptr) // если его нет, то мы находимся в начале списка и нужно заменить head на следующий
                {
                    mylist->head = mylist->head->next;
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

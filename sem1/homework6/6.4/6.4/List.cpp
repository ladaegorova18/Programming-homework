#include "pch.h"
#include <iostream>
#include <string>
#include "List.h"
using namespace std;

void makingList(DynList *myList)
{
	myList->head = nullptr;
	myList->tail = nullptr;
	myList->size = 0;
}

bool isEmpty(DynList *myList)
{
	return (myList->head == nullptr);
}

void addingData(DynList *myList, string newName, string newPhoneNumber)
{
	Element* data = new Element;
	data->name = newName;
	data->phoneNumber = newPhoneNumber;
	data->next = nullptr;
	if (isEmpty(myList))
	{
		myList->head = data;
	}
	else
	{
		myList->tail->next = data;
	}
	myList->tail = data;
	myList->size++;
	return;
}

void printData(Element *head)
{
    {
        Element *current = head;
        while (current)
        {
            cout << current->name << " " << current->phoneNumber << endl;
            current = current->next;
        }
		delete current;
    }
}

bool inEquality(string first, string second)
{
	return (first > second);
}

Element* getMiddle(Element* head)
{
	if (head == nullptr)
	{
		return head;
	}
	Element* slow = head;
	Element* fast = head;
	while ((fast->next != nullptr) && (fast->next->next != nullptr))
	{
		slow = slow->next;
		fast = fast->next->next;
	}
	return slow;
}

DynList* merge(DynList *&firstList, DynList *&secondList)
{	
	DynList *resultList = new DynList();
	resultList->head = nullptr;
	Element *current = resultList->head;
	Element *first = firstList->head;
	Element *second = secondList->head;
	if (!inEquality(first->name, second->name))
	{
		current = first;
		first = first->next;
	}
	else
	{
		current = second;
		second = second->next;
	}
	while ((first != nullptr) && (second != nullptr))
	{
		if (first->name < second->name)
		{
			current->next = first;
			first = first->next;
		}
		else
		{
			current->next = second;
			second = second->next;
		}
		current = current->next;
	}
	current->next = (first == nullptr) ? second : first;
	printData(resultList->head);
	return resultList;
}

DynList* mergeSort(DynList *myList)
{
	if (myList->size <= 1)
	{
		return myList;
	}
	Element *middle = getMiddle(myList->head);
	DynList* firstList = new DynList();
	DynList* secondList = new DynList();
	size_t size = myList->size;
	firstList->head = myList->head;
	secondList->head = middle->next;

	DynList* result = new DynList();
	makingList(result);


	mergeSort(firstList);
	mergeSort(secondList);
	result = merge(firstList, secondList);
	return result;
}
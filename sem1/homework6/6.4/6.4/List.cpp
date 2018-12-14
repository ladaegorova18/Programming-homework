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

DynList* merge(DynList *firstList, DynList *secondList)
{	
	DynList *resultList = new DynList();
	resultList->head = nullptr;
	Element *first = firstList->head;
	Element *second = secondList->head;
	if (!inEquality(first->name, second->name))
	{
		resultList->head = first;
		first = first->next;
	}
	else
	{
		resultList->head = second;
		second = second->next;
	}
	Element *current = resultList->head;
	while ((first != nullptr) && (second != nullptr))
	{
		if (first->name < second->name)
		{
			current->next = first;
			cout << first->name << " " << second->name;
			first = first->next;
		}
		else
		{
			current->next = second;
			cout << second->name << " " << first->name;
			second = second->next;
		}
		current = current->next;
	}
	current->next = (first == nullptr) ? second : first;
	//printData(resultList->head);
	return resultList;
}

void swap(DynList* list)
{
	Element* temp = list->head;
	temp->next = nullptr;
	list->head = list->head->next;
	list->head->next = temp;
}

DynList* mergeSort(DynList *myList, Element *head, Element* tail)
{
	if (head == tail)
	{
		return myList;
	}
	Element *middle = getMiddle(myList->head);
	DynList* firstList = new DynList();
	DynList* secondList = new DynList();
	size_t size = myList->size;
	firstList->size = size / 2;
	secondList->size = size / 2;
	firstList->head = myList->head;
	cout << size;
	if ((middle != nullptr) && (middle->next != nullptr))
	{
		secondList->head = middle->next;
		middle->next = nullptr;
	}
	mergeSort(firstList, firstList->head, middle);
	mergeSort(secondList, middle->next, tail);
	DynList* result = new DynList();
	makingList(result);


	return merge(firstList, secondList);
}



/*
DynList* mergeSort(DynList *myList)
{
	DynList* firstList = new DynList();
	DynList* secondList = new DynList();
	size_t size = myList->size;
	Element *middle = getMiddle(myList->head);
	firstList->size = size / 2;
	secondList->size = size / 2;
	firstList->head = myList->head;
	secondList->head = middle->next;
	middle->next = nullptr;
	while (firstList->size > 2)
	{
		mergeSort(firstList);
	}
	while (secondList->size > 2)
	{
		mergeSort(secondList);
	}
	if (firstList->size == 2)
	{
		if (firstList->head->name > firstList->head->next->name)
		{
			firstList = swap(firstList);
		}
	}
	if (secondList->size == 2)
	{
		if (secondList->head->name > secondList->head->next->name)
		{
			secondList = swap(secondList);
		}
	}
	DynList* result = new DynList();
	makingList(result);
	while (result->size < myList->size)
	{
		merge(firstList, secondList);
	}
	return result;
}
*/
void deleteList(DynList* myList)
{
	Element* previous = nullptr;
	Element* current = myList->head;
	while (current)
	{
		previous = current;
		current = current->next;
		delete previous;
	}
	delete current;
}

//return merge(firstList, secondList);
	/*if ((firstList->size == 1) && (secondList->size == 1))
	{
		cout << firstList->head->name << secondList->head->name;
		return merge(firstList, secondList);
	}
	/*else
	{
		if (firstList->size != 0)
		{
			mergeSort(firstList);
		}
		if (secondList->size != 0)
		{
			mergeSort(secondList);
		}
	}*/

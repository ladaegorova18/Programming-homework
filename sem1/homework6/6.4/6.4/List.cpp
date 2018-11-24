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

Element* merge(Element *first, Element *second)
{
	Element *dummyHead = new Element();
	Element *current = dummyHead;
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
	return dummyHead->next;
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

Element* mergeSort(Element *head)
{
	if ((head == nullptr) || (head->next == nullptr))
	{
		return head;
	}
	else
	{
		Element *middle = getMiddle(head);
		Element *secondHalf = middle->next;
		middle->next = nullptr;
		return merge(mergeSort(head), mergeSort(secondHalf));
	}
}
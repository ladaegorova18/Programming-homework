#include "pch.h"
#include <iostream>
#include <string>
#include "List.h"
using namespace std;

struct Element
{
	int currTime = 0;
	bool isStart = false;
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

void insertion(DynList *myList,const int time, bool isStart)
{
	Element* data = new Element;
	data->currTime = time;
	data->isStart = isStart;
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
		if (current->currTime >= time)
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

int maxCount(DynList *&myList)
{
	int numberOfCalls = 0;
	int max = 0;
	Element* current = myList->head;
	int prevTime = current->currTime;
	while (current)
	{
		if (current->currTime - prevTime > 59)
		{
			if (numberOfCalls > max)
			{
				max = numberOfCalls;
				numberOfCalls = 0;
			}
		}
		if (current->isStart)
		{
			++numberOfCalls;
		}
		else
		{
			--numberOfCalls;
		}
		if (numberOfCalls > max)
		{
			max = numberOfCalls;
		}
		prevTime = current->currTime;
		current = current->next;
	}
	return max;
}
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

struct DynamicList
{
	Element* head;
};

DynamicList* makingList()
{
	DynamicList* list = new DynamicList();
	list->head = nullptr;
	return list;
}

Element* getHead(DynamicList* list)
{
	return list->head;
}

bool isEmpty(DynamicList *myList)
{
	return (myList->head == nullptr);
}

Element* getNext(Element* temp)
{
	return temp->next;
}

void insertion(DynamicList *myList,const int time, bool isStart)
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

void deleteList(DynamicList *&myList)
{
	deleteElements(myList->head);
	delete myList;
}

int maxCount(DynamicList *&myList)
{
	int numberOfCalls = 0;
	int max = 0;
	int hour = 0;
	Element* current = myList->head;
	int time[24] = { 0 };
	while (current)
	{
		time[current->currTime]++;
		current = current->next;
	}
	for (int i = 0; i < 24; ++i)
	{
		if (time[i] > max)
		{
			max = time[i];
			hour = i;
		}
	}
	std::cout << hour << " " << hour + 1 << " hours" << std::endl;
	std::cout << "Max count of clients:" << std::endl;
	return max;
}
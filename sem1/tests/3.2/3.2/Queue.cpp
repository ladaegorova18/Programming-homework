#include "pch.h"
#include <iostream>
#include "Queue.h"
using namespace std;

struct Element
{
	std::string value = "";
	int prior = 0;
	Element* next;
};

struct Queue
{
	Element* head;
};

Queue* makeList()
{
	Queue *list = new Queue();
	list->head = nullptr;
	return list;
}

bool isEmpty(Queue *myList)
{
	return (myList->head == nullptr);
}


void enqueue(Queue *myQueue, std::string newValue, int priority)
{
	Element* data = new Element;
	Element* previous = nullptr;
	data->value = newValue;
	data->prior = priority;
	if (isEmpty(myQueue))
	{
		myQueue->head = data;
		data->next = nullptr;
		return;
	}
	Element* current = myQueue->head;
	while (current)
	{
		if (current->prior > priority)
		{
			data->next = current;
			if (previous != nullptr)
			{
				previous->next = data;
			}
			else
			{
				myQueue->head = data;
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

std::string dequeue(Queue *myList)
{
	if (myList->head)
	{
		Element* top = myList->head;
		myList->head = myList->head->next;
		return top->value;
	}
	return "-1";
}

void printData(Queue *myQueue)
{
	struct Element *current = myQueue->head;
	while (current)
	{
		cout << current->value;
		cout << endl;
		current = current->next;
	}
}

void deleteQueue(Queue *myQueue)
{
	Element *current = myQueue->head;
	Element *previous = nullptr;
	while (current)
	{
		previous = current;
		current = current->next;
		delete previous;
	}
	delete myQueue;
}
#include "pch.h"
#include <iostream>
#include <string>
#include "List.h"

struct Node
{
	int value;
	Node* next;
};

struct List
{
	Node* head;
	Node* tail;
};

List* makingList()
{
	List* list = new List();
	list->head = nullptr;
	return list;
}

int getValue(Node* list)
{
	return list->value;
}

Node* nextNode(Node *list)
{
	return list->next;
}

bool isEmpty(Node *head)
{
	return (head == nullptr);
}

void addingData(List*& list, int newValue)
{
	Node* data = new Node();
	data->value = newValue;
	if (isEmpty(list->head))
	{
		list->head = data;
		list->tail = data;
	}
	else
	{
		list->tail->next = data;
		list->tail = list->tail->next;
	}
}

Node* mergeSort(Node *&firstList, Node *&secondList)
{
	if (firstList == nullptr)
	{
		return secondList;
	}
	if (secondList == nullptr)
	{
		return firstList;
	}
	Node *newHead = nullptr;
	if (firstList->value < secondList->value)
	{
		newHead = firstList;
		newHead->next = mergeSort(firstList->next, secondList);
	}
	else
	{
		newHead = secondList;
		newHead->next = mergeSort(firstList, secondList->next);
	}
	return newHead;
}

List* merge(List *&firstList, List *&secondList)
{
	if (firstList == nullptr)
	{
		return secondList;
	}
	if (secondList == nullptr)
	{
		return firstList;
	}
	List* newList = makingList();
	newList->head = mergeSort(firstList->head, secondList->head);
	delete firstList;
	delete secondList;
	firstList = nullptr;
	secondList = nullptr;
	return newList;
}

Node* getHead(List *&list)
{
	return list->head;
}

void deleteList(List *&list)
{
	if (list == nullptr)
	{
		delete list;
		return;
	}
	Node* current = list->head;
	Node* prev = nullptr;
	while (current)
	{
		prev = current;
		current = current->next;
		delete prev;
	}
	delete current;
	delete list;
}
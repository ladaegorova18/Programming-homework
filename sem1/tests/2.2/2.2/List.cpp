#include "pch.h"
#include <iostream>
#include <string>
#include "List.h"

struct Node
{
	int value;
	Node* next;
};

Node* makingList()
{
	Node* head = nullptr;
	return head;
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

void addInTail(Node *&head, Node*& data)
{
	Node* current = head;
	while (current)
	{
		if (current->next == nullptr)
		{
			current->next = data;
			return;
		}
		current = current->next;
	}
}

void addingData(Node *&head, int newValue)
{
	Node* data = new Node();
	data->value = newValue;
	if (isEmpty(head))
	{
		head = data;
	}
	else
	{
		addInTail(head, data);
	}
}

Node* merge(Node *&firstList, Node *&secondList)
{
	Node* newHead = nullptr;
	if (firstList == nullptr)
	{
		return secondList;
	}
	if (secondList == nullptr)
	{
		return firstList;
	}
	if (firstList->value < secondList->value)
	{
		newHead = firstList;
		newHead->next = merge(firstList->next, secondList);
	}
	else
	{
		newHead = secondList;
		newHead->next = merge(firstList, secondList->next);
	}
	return newHead;
}

void deleteList(Node *&head)
{
	Node* current = head;
	Node* prev = nullptr;
	while (current)
	{
		prev = current;
		current = current->next;
		delete prev;
	}
	delete current;
}
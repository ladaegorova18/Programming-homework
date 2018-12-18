#include "pch.h"
#include "List.h"
#include <iostream>

bool isEmpty(Node* head)
{
	return (head == nullptr);
}

void makeList(Node*& head)
{
	head = nullptr;
}

void adding(Node*& head, int value)
{
	Node* temp = new Node{ value };
	if (isEmpty(head))
	{
		head = temp;
		return;
	}
	Node* tail = head;
	while (tail->next)
	{
		tail = tail->next;
	}
	tail->next = temp;
}

void printing(Node* head)
{
	Node* current = head;
	while (current)
	{
		std::cout << current->value << " ";
		current = current->next;
	}
	delete current;
}

void deleteList(Node*& head)
{
	Node* previous = nullptr;
	Node* temp = head;
	while (temp->next)
	{
		previous = temp;
		temp = temp->next;
		delete previous;
	}
	delete temp;
}

Node* makeSmallList(Node *&head, int pos, int len)
{
	Node* temp = head;
	for (int i = 0; i < pos; ++i)
	{
		temp = temp->next;
	}
	Node* newHead = temp;
	Node* curr = newHead;
	for (int i = 0; i < len; ++i)
	{
		if (curr->next)
		{
			curr = curr->next;
		}
	}
	curr->next = nullptr;
	return newHead;
}

Node* increaseList(Node* head)
{
	int count = 1;
	int max = 0;
	int pos = 1;
	int len = 1;
	Node* newList;
	makeList(newList);
	Node* temp = head;
	Node* prev = nullptr;
	while (temp->next)
	{
		len++;
		prev = temp;
		temp = temp->next;
		if (temp->value > prev->value)
		{
			count++;
		}
		else
		{
			count = 1;
		}
		if (count > max)
		{
			max = count;
			pos = len - max;
		}
	}
	return makeSmallList(head, pos, len);
}
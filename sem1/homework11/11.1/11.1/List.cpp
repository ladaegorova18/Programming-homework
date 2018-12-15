#include "pch.h"
#include "List.h"
#include <iostream>

void add(Node *&head, int value)
{
	Node* data = new Node();
	data->value = value;
	data->next = nullptr;
	if (head == nullptr)
	{
		head = data;
	}
	else
	{
		Node* curr = head;
		while (curr)
		{
			curr = curr->next;
		}
		curr = data;
	}
}

void print(Node *head)
{
	Node* curr = head;
	while (curr)
	{
		std::cout << head->value << std::endl;
	}
	delete curr;
}

void reverse(Node *&head)
{
	Node* curr = head;
	Node* prev = nullptr;
	Node* tail = nullptr;
	while (curr)
	{
		prev = curr;
		curr = curr->next;
		prev->next = tail;
		tail = prev;
		std::cout << curr;
	}
	curr->next = prev;
	head = curr;
}

void deleteList(Node *&head)
{
	Node* curr = head;
	Node* prev = nullptr;
	while (curr)
	{
		prev = curr;
		curr = curr->next;
		delete prev;
	}
	delete curr;
}
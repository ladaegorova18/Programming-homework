#include "pch.h"
#include "List.h"
#include <iostream>

void makeList(Node *&head)
{
	head = nullptr;
}
void add(Node *&head, int value, int position)
{
	Node *temp = new Node(value);
	if (head == nullptr)
	{
		head = temp;
		return;
	}
	if (position == 0)
	{
		temp->next = head;
		head->prev = temp;
		head = temp;
		return;
	}
	Node* curr = head;
	Node* prev = nullptr;
	for (int i = 0; i < position; ++i)
	{
		prev = curr;
		curr = curr->next;
	}
	if (curr == nullptr)
	{
		temp->prev = prev;
		prev->next = temp;
		return;
	}
	prev->next = temp;
	temp->next = curr;
	temp->prev = prev;
	curr->prev = temp;
	return;
}

void deleteFromPos(Node *&head, int position)
{
	if (head == nullptr)
	{
		return;
	}
	if (position == 0)
	{
		if (head->next == nullptr)
		{
			head = nullptr;
			return;
		}
		head = head->next;
		head->prev = nullptr;
		return;
	}
	Node* curr = head;
	Node* prev = nullptr;
	for (int i = 0; i < position; ++i)
	{
		prev = curr;
		curr = curr->next;
	}
	if (curr == nullptr)
	{
		prev->prev->next = nullptr;
		delete prev;
		return;
	}
	curr->prev->next = curr->next;
	if (curr->next)
	{
		curr->next->prev = curr->prev;
	}
	delete curr;
}

void deleteList(Node *&head)
{
	Node* temp = head;
	Node* prev = nullptr;
	while (temp)
	{
		prev = temp;
		temp = temp->next;
		delete prev;
	}
	delete temp;
}

void print(Node *head)
{
	Node *temp = head;
	while (temp->next)
	{
		std::cout << temp->value << " ";
		temp = temp->next;
	}
	std::cout << temp->value;
	std::cout << "\n";
	delete temp;
}
#include "pch.h"
#include "List.h"
#include <iostream>
#include <string>

struct Node
{
	int info;
	Node* next;
	Node(int newValue)
	{
		info = newValue;
		next = nullptr;
	}
};

Node* getNext(Node *&temp)
{
	return temp->next;
}

Node* makeList()
{
	Node* head = nullptr;
	return head;
}

int getLength(Node *&list)
{
	int count = 0;
	Node* curr = list;
	while (curr)
	{
		count++;
		curr = curr->next;
	}
	return count;
}

bool add(Node *&head, int value, int pos)
{
	int count = getLength(head);
	if (pos > count)
	{
		return false;
	}
	Node *temp = new Node(value);
	if (head == nullptr)
	{
		head = temp;
		return true;
	}
	if (pos == 0)
	{
		temp->next = head;
		head = temp;
		return true;
	}
	Node* prev = nullptr;
	Node* curr = head;
	for (int i = 0; i < pos; ++i)
	{
		if (curr)
		{
			prev = curr;
			curr = curr->next;
		}
	}
	temp->next = curr;
	prev->next = temp;
}

bool isEmpty(Node *&head)
{
	return head == nullptr;
}

int getValue(Node *&temp)
{
	return temp->info;
}

bool deleting(Node *&head, int pos)
{
	int count = getLength(head);
	if (pos > count)
	{
		return false;
	}
	if (pos == 0)
	{
		head = head->next;
		return true;
	}
	Node* curr = head;
	Node* prev = nullptr;
	Node* prevPrev = nullptr;
	for (int i = 0; i < pos; ++i)
	{
		if (curr)
		{
			prevPrev = prev;
			prev = curr;
			curr = curr->next;
		}
	}
	if (curr == nullptr)
	{
		prevPrev->next = nullptr;
		return true;
	}
	prev->next = curr->next;
}

void print(Node *head)
{
	std::cout << std::endl;
	Node *temp = head;
	while (temp)
	{
		std::cout << temp->info << "\n";
		temp = temp->next;
	}
	std::cout << "\n";
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
#include "pch.h"
#include "List.h"
#include <iostream>
#include <string>

struct Node
{
	std::string info;
	Node* next;
	Node(std::string newValue)
	{
		info = newValue;
		next = nullptr;
	}
};

Node* nextNode(Node* temp)
{
	return temp->next;
}

std::string getInfo(Node* temp)
{
	return temp->info;
}

Node* makeList()
{
	Node* head = nullptr;
	return head;
}

void add(Node *&head, std::string value)
{
	Node *temp = new Node(value);
	if (head == nullptr)
	{
		head = temp;
		return;
	}
	Node* curr = head;
	while (curr->next)
	{
		curr = curr->next;
	}
	curr->next = temp;
}

Node* makeUnrepList(Node *head)
{
	Node* newList = head;
	Node* temp = newList;
	while (temp)
	{
		Node* curr = temp;
		Node* prev = nullptr;
		while (curr->next)
		{
			prev = curr;
			curr = curr->next;
			if (curr->info == temp->info)
			{
				if (curr)
				{
					prev->next = curr->next;
					print(newList);
				}
				else
				{
					curr = nullptr;
				}
			}
		}
		temp = temp->next;
	}
	return newList;
}

void print(Node *head)
{
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
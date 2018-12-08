#include "pch.h"
#include "List.h"
#include <iostream>

bool List::isEmpty()
{
	return (head == nullptr);
}

void List::makeList()
{
	head = nullptr;
	tail = nullptr;
	length = 0;
}

int List::getLength()
{
	return length;
}

void List::adding(std::string value)
{
	length++;
	Node* temp = new Node{ value };
	if (isEmpty())
	{
		head = temp;
		tail = temp;
		return;
	}
	tail->next = temp;
	tail = temp;
}

bool List::find(std::string value)
{
	Node* current = head;
	while (current)
	{
		if (current->value == value)
		{
			return true;
		}
		current = current->next;
	}
	return false;
}

Node* List::getNode(std::string value)
{
	Node* current = head;
	while (current)
	{
		if (current->value == value)
		{
			return current;
		}
		current = current->next;
	}
	return nullptr;
}

void List::printing(int index)
{
	Node* current = head;
	while (current)
	{
		std::cout << current->value << "\t";
		std::cout << current->count << "\n";
		current = current->next;
	}
}

void List::deleteList()
{
	Node* previous = nullptr;
	Node* temp = head;
	while (temp)
	{
		previous = temp;
		temp = temp->next;
		delete previous;
	}
	delete temp;
}
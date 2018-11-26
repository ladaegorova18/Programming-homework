#include "pch.h"
#include "Set.h"
#include "Node.h"
#include <iostream>

struct Set
{
	Node* head;
};

Set* createSet()
{
	return new Set{ nullptr };
}

void deleteSet(Set* set)
{
	auto* temp = set->head;
	set->head = nullptr;
	delete temp;
	return;
}

void addNode(Node* node, int data);

bool add(Set* set, int const  data)
{
	if (isEmpty(set))
	{
		set->head = new Node{ data, nullptr, nullptr };
	}
	else
	{
		if (!exists(set, data))
		{
			addNode(set->head, data);
		}
		else
		{
			return false;
		}
	}
	return true;
}

void addNode(Node* node, int data)
{
	if (node->data > data && node->leftChild != nullptr)
	{
		addNode(node->leftChild, data);
	}
	else if (node->data < data && node->rightChild != nullptr)
	{
		addNode(node->rightChild, data);
	}
	else
	{
		if (node->data > data)
		{
			node->leftChild = new Node{ data, nullptr, nullptr };
		}
		else
		{
			node->rightChild = new Node{ data, nullptr, nullptr };
		}
	}
}

void removeRecursion(Node*& current, int data);

bool remove(Set* set, int const data)
{
	if (!exists(set, data))
	{
		return false;
	}
	removeRecursion(set->head, data);
	return true;
}

int maximum(Node* current)
{
	auto* temp = current;
	temp = temp->leftChild;
	while (temp->rightChild != nullptr)
	{
		temp = temp->rightChild;
	}
	return temp->data;
}

void removeRecursion(Node*& current, int data)
{
	if (current->data > data)
	{
		removeRecursion(current->leftChild, data);
	}
	else if (current->data < data)
	{
		removeRecursion(current->rightChild, data);
	}
	else
	{
		if (current->leftChild == nullptr && current->rightChild == nullptr)
		{
			auto* temp = current;
			current = nullptr;
			delete temp;
			return;
		}
		else if (current->leftChild == nullptr && current->rightChild != nullptr)
		{
			auto* temp = current;
			current = current->rightChild;
			delete temp;
			return;
		}
		else if (current->leftChild != nullptr && current->rightChild == nullptr)
		{
			auto* temp = current;
			current = current->leftChild;
			delete temp;
			return;
		}
		else
		{
			current->data = maximum(current);
			removeRecursion(current->leftChild, current->data);
		}
	}
}

bool exists(Set* set, int const data)
{
	if (isEmpty(set))
	{
		return false;
	}
	auto* temp = set->head;
	while (true)
	{
		if (temp->data > data)
		{
			if (temp->leftChild != nullptr)
			{
				temp = temp->leftChild;
			}
			else
			{
				return false;
			}
		}
		else if (temp->data < data)
		{
			if (temp->rightChild != nullptr)
			{
				temp = temp->rightChild;
			}
			else
			{
				return false;
			}
		}
		else
		{
			return true;
		}
	}
}

bool isEmpty(Set* set)
{
	return set->head == nullptr;
}

void risePrint(Node* current)
{
	if (current->leftChild != nullptr)
	{
		risePrint(current->leftChild);
	}
	std::cout << current->data << " ";
	if (current->rightChild != nullptr)
	{
		risePrint(current->rightChild);
	}
}

void printIncrease(Set *set)
{
	auto* current = set->head;
	risePrint(current);
}

void downPrint(Node* current)
{
	if (current->rightChild != nullptr)
	{
		downPrint(current->rightChild);
	}
	std::cout << current->data << " ";
	if (current->leftChild != nullptr)
	{
		downPrint(current->leftChild);
	}
}

void printDecrease(Set *set)
{
	auto* current = set->head;
	downPrint(current);
}
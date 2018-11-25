#include "pch.h"
#include <iostream>
#include "Set.h"
using namespace std;

void recursiveAdding(Element *root, int data)
{
	Element *tempData = new Element();
	tempData->value = data;
	if (data < root->value)
	{
		if (root->leftChild == nullptr)
		{
			root->leftChild = tempData;
		}
		else
		{
			recursiveAdding(root->leftChild, data);
		}
	}
	else
	{
		if (root->rightChild == nullptr)
		{
			
			root->rightChild = tempData;
		}
		else
		{
			recursiveAdding(root->rightChild, data);
		}
	}
}

void Set::addingData(int data)
{
	Element *tempData = new Element();
	tempData->value = data;
	tempData->leftChild = nullptr;
	tempData->rightChild = nullptr;
	if (isEmpty())
	{
		root = tempData;
	}
	else
	{
		recursiveAdding(root, data);
	}
}

Element* Set::minimum(Element *current)
{
	Element *minimum = current;
	while (minimum->leftChild != nullptr)
	{
		minimum = minimum->leftChild;
	}
	return minimum;
}

void Set::rootRemoving()
{

}

Element* Set::deleteData(Element *current, int data)
{
	if (current == nullptr)
	{
		return current;
	}
	if (data < current->value)
	{
		current->leftChild = deleteData(current->leftChild, data);
	}
	else if (data > current->value)
	{
		current->rightChild = deleteData(current->rightChild, data);
	}
	else if (root->value == data)
	{
		rootRemoving();
	}
	else if ((current->leftChild != nullptr) && (current->rightChild != nullptr))
	{
		current = minimum(current->rightChild);
		current->rightChild = deleteData(current->rightChild, data);
	}
	else
	{
		if (current->leftChild != nullptr)
		{
			current = current->leftChild;
		}
		else if (current->rightChild != nullptr)
		{
			current = current->rightChild;
		}
		else
		{   
			current = nullptr;
			if (data == root->value)
			{
				root = nullptr;
			}
		}
	}
	return current;
}

bool Set::checkData(int data, Element *current)
{
	if (isEmpty())
	{
		return 0;
	}
	else
	{
		while (current != nullptr)
		{
			if (data == current->value)
			{
				return 1;
			}
			else
			{
				if (data < current->value)
				{
					current = current->leftChild;
					checkData(data, current);
				}
				else
				{
					current = current->rightChild;
					checkData(data, current);
				}
			}
		}
	}
	return 0;
}

void Set::printRise(Element *current)
{
	if (current->leftChild != nullptr)
	{
		printRise(current->leftChild);
	}
	std::cout << current->value << " ";
	if (current->rightChild != nullptr)
	{
		printRise(current->rightChild);
	}
}

void Set::printFalling(Element *current)
{
	if (current->rightChild != nullptr)
	{
		printFalling(current->rightChild);
	}
	std::cout << current->value << " ";
	if (current->leftChild != nullptr)
	{
		printFalling(current->leftChild);
	}
}

bool Set::isEmpty()
{
	return (root == nullptr);
}
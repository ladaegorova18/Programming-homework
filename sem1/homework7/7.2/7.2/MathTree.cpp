#include "pch.h"
#include <ctype.h>
#include <iostream>
#include "MathTree.h"

struct Element
{
	char operand;
	Element* leftChild;
	Element* rightChild;
	Element* parent;
	int value;
};

Element* makeElement()
{
	Element* temp = new Element();
	temp->leftChild = nullptr;
	temp->rightChild = nullptr;
	return temp;
}

int operation(const char operand, const int firstNumber, const int secondNumber)
{
	switch (operand)
	{
	case '+':
	{
		return firstNumber + secondNumber;
		break;
	}
	case '-':
	{
		return firstNumber - secondNumber;
		break;
	}
	case '*':
	{
		return firstNumber * secondNumber;
		break;
	}
	case '/':
	{
		return firstNumber / secondNumber;
		break;
	}
	}
	return 0;
}

bool isOper(char symbol)
{
	return ((symbol == '/') || (symbol == '*') || (symbol == '+') || (symbol == '-'));
}

Element* Tree::getRoot()
{
	return root;
}

int Tree::count(Element* current)
{
	if ((current->leftChild == nullptr) && (current->rightChild == nullptr))
	{
		return current->value;
	}
	return current->value = operation(current->operand, count(current->leftChild), count(current->rightChild));
}

void Tree::makeTree()
{
	Element* root = makeElement();
	root->parent = nullptr;
}

bool Tree::isEmpty()
{
	return (root == nullptr);
}

Element* Tree::adding(const char symbol, Element *current)
{
	Element *temp = new Element();
	if (isOper(symbol))
	{
		temp->operand = symbol;
		temp->value = 'N';
		if (isEmpty())
		{
			root = temp;
			current = root;
		}
		else
		{
			temp->parent = current;
			if (current->leftChild == nullptr)
			{
				current->leftChild = temp;
				current = current->leftChild;
			}
			else if (current->rightChild == nullptr)
			{
				current->rightChild = temp;
				current = current->rightChild;
			}
		}
	}
	else if (isdigit(symbol))
	{
		temp->value = symbol - '0';
		temp->parent = current;
		if (current->leftChild == nullptr)
		{
			current->leftChild = temp;
		}
		else
		{
			current->rightChild = temp;
		}
	}
	else if (symbol == ')')
	{
		if (current->parent != nullptr)
		{
			current = current->parent;
		}
	}
	return current;
}

void Tree::printing(Element *current, const int level)
{
	if (current != nullptr)
	{
		printing(current->leftChild, level + 1);
		for (int i = 0; i < level; i++)
		{
			std::cout << "\t";
		}
		if (current->value != 'N')
		{
			std::cout << current->value << "\n";
		}
		else
		{
			std::cout << current->operand << "\n";
		}
		printing(current->rightChild, level + 1);
	}
}

void Tree::deleteTree(Element* current)
{
	if (current != nullptr)
	{
		deleteTree(current->leftChild);
		deleteTree(current->rightChild);
		delete current;
	}
}
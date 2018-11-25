#include "pch.h"
#include <iostream>
#include "Stack1.h"
using namespace std;

bool Stack::isEmpty() 
{
	return (top == 0);
}

void Stack::makeStack() 
{
	top = 0;
}

int Stack::sizeOfStack()
{
	return top;
}

void Stack::push(char element) 
{
	if (top < MAX)
	{
		node[top] = element;
		top++;
	}
	else
	{
		cout << "Стек полон:)" << endl;
	}
}

char Stack::pop() 
{
	if (isEmpty())
	{
		cout << "Стек пуст:(" << endl;
		return EXIT_SUCCESS;
	}
	else
	{
		char topElement = node[top - 1];
		top--;
		return topElement;
	}
}
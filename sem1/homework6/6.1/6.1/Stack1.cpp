#include <iostream>
#include "pch.h"
#include "Stack1.h"
using namespace std;

bool Stack::isEmpty(Stack *myStack)
{
	return (myStack->top == 0);
}

void Stack::makeStack(Stack *myStack)
{
	myStack->top = 0;
}

void Stack::push(Stack *myStack, char element)
{
	if (myStack->top < MAX)
	{
		myStack->top++;
		myStack->node[myStack->top] = element;
	}
	else
	{
		cout << "Стек полон:)" << endl;
	}
}

char Stack::pop(Stack *myStack)
{
	if (isEmpty(myStack))
	{
		cout << "Стек пуст:(" << endl;
		return EXIT_SUCCESS;
	}
	else
	{
		char topElement = myStack->node[myStack->top];
		myStack->top--;
		return topElement;
	}
}

void Stack::printStack(Stack *myStack)
{
	if (!isEmpty(myStack))
	{
		for (int i = 0; i < myStack->top; i++)
		{
			cout << "Сейчас стек выглядит так:" << endl;
			cout << myStack->node[i];
		}
	}
}
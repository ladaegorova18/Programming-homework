#include "pch.h"
#include <iostream>
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
		cout << "Ñòåê ïîëîí:)" << endl;
	}
}

char Stack::pop(Stack *myStack)
{
	if (isEmpty(myStack))
	{
		cout << "Ñòåê ïóñò:(" << endl;
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
			cout << "Ñåé÷àñ ñòåê âûãëÿäèò òàê:" << endl;
			cout << myStack->node[i];
		}
	}
}
#include "pch.h"
#include <iostream>
#include "Stack1.h"
using namespace std;

bool Stack::isEmpty(Stack *myStack) // проверка стека на пустоту. Если индекс верхнего элемента равен нулю, возвращаем true
{
	return (myStack->top == 0);
}

void Stack::makeStack(Stack *myStack) // создаем стек, присваивая нулевое значение переменной top
{
	myStack->top = 0;
}

void Stack::push(Stack *myStack, char element) // добавляем элемент в стек, для этого увеличиваем top на единицу и в соответствующий элемент массива записываем значение
{
	if (myStack->top < MAX)
	{
		myStack->top++;
		myStack->node[myStack->top] = element; // если количество элементов превышает максимальное, выводим сообщение об этом
	}
	else
	{
		cout << "Ñòåê ïîëîí:)" << endl;
	}
}

char Stack::pop(Stack *myStack) // извлекаем элемент из стека. Если он пуст, выводим соответствующее сообщение. Иначе возвращаем верхний элемент и уменьшаем переменную top на один
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

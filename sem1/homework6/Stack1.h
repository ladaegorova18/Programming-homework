#ifndef STACK_H
#include <iostream>
const int MAX = 100;
using namespace std;

struct stack
{
    private:
        int top;
        char node[MAX];
    public:
        void makeStack(stack *myStack);
        void push(stack *myStack, char element);
        char pop(stack *myStack);
        bool isEmpty(stack *myStack);
        void printStack(stack *myStack);
};

bool stack::isEmpty(stack *myStack)
{
   return (myStack->top == 0);
}

void stack::makeStack(stack *myStack)
{
    myStack->top = 0;
}

void stack::push(stack *myStack, char element)
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

char stack::pop(stack *myStack)
{
    if (isEmpty(myStack))
    {
        cout << "Стек пуст:(" << endl;
    }
    else
    {

        char topElement = myStack->node[myStack->top];
        myStack->top--;
        return topElement;
    }
}

void stack::printStack(stack *myStack)
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

#endif // STACK_H

#ifndef STACK_H
#define STACK_H
#include <iostream>
const int MAX = 100;
using namespace std;

struct Stack
{
    int top;
    char node[MAX];
    void makeStack(Stack *);
    void push(Stack *, char);
    char pop(Stack *);
    bool isEmpty(Stack *);
};

#endif // STACK_H

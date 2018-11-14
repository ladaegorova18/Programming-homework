#include <locale>
#include <iostream>
#include <cstring>
#include "assert.h"
#include "header.h"
#include "options.cpp"
using namespace std;

void makingList(dynList *mylist)
{
    mylist->head = nullptr;
}

bool isEmpty(dynList *mylist)
{
    return (mylist->head == nullptr);
}

int test()
{
    dynList* testList = new dynList;
    makingList(testList);
    for (int i = 0; i < 2; i++)
    {
        for (int j = 1; j < 5; j++)
        {
            insertion(testList, j);
        }
    }
    Element *current = testList->head;
    while (current)
    {
        if (current->next == nullptr)
        {
        cout << "“ест пройден" << endl;
            return 0;
        }
        else
        {
            assert(current->value <= current->next->value);
            current = current->next;
        }
    }
}

int menu(dynList *mylist)
{
    cout << "Ёто главное меню дл€ работы со списком. Ќажмите:\n1, чтобы добавить значение в список;\n2, чтобы удалить значение из списка;\n3, чтобы распечатать список;\n0, чтобы выйти." << endl;;
    int key = -1;
    cin >> key;
    if (key == 0)
    {
        return 0;
    }
    switch (key)
    {
    case 1:
        {
            addingData(mylist);
            break;
        }
    case 2:
        {
            deleteData(mylist);
            break;
        }
    case 3:
        {
            printData(mylist);
            break;
        }
    }
    menu(mylist);
}

int main()
{
    setlocale(LC_ALL, "Russian");
    test();
    dynList* mylist = new (dynList);
    makingList(mylist);
    menu(mylist);
    cout << "ƒо свидани€!";
    return 0;
}

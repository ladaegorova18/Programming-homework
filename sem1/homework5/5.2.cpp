#include <locale>
#include <iostream>
#include "assert.h"
using namespace std;

typedef struct Node
{
    Node *next;
    int number;
}Node;

struct CircleList
{
    Node *head;
    Node *tail;
    int size = 0;
};

bool isEmpty(CircleList *squad)
{
    return (squad->head == nullptr);
}

void makingList(CircleList *squad)
{
    squad->head = nullptr;
    squad->tail = nullptr;
}

int insertion(CircleList *mylist, int newValue)
{
    mylist->size++;
    Node* data = new Node;
    data->next = mylist->head;
    data->number = newValue;
    if (mylist->head != nullptr)
    {
        mylist->tail->next = data;
        mylist->tail = data;
    }
    else
    {
        mylist->head = mylist->tail = data;
    }
}

void makingSquad(CircleList *mylist, int counter)
{
    for (int i = 1; i <= counter; i++)
    {
        insertion(mylist, i);
    }
}

void printData(CircleList *squad)
{
    if (squad->head == nullptr)
    {
        cout << "Список пуст:(" << endl;
    }
    else
    {
        cout << "Сейчас список выглядит так:" << endl;
        struct Node *current;
        current = squad->head;
        while (current)
        {
            cout << current->number << endl;
            cout << endl;
            current = current->next;
            if (current == squad->head)
            {
                return;
            }
        }
    }
}

int killing(CircleList *squad, int distance)
{
    struct Node *current = squad->head;
    struct Node *previous = squad->tail;
    struct Node *data = new Node;
    while (current != previous)
    {
        for (int i = 1; i < distance; i++)
        {
            previous = current;
            current = current->next;
        }
        previous->next = current->next;
        current = current->next;
    }
    return current->number;
}

void test()
{
    int testSize = 1;
    int testDistance = 5;
    CircleList *oneManList = new CircleList;
    makingList(oneManList);
    makingSquad(oneManList, testSize);
    assert(killing(oneManList, testDistance) == 1);
    testSize = 9;
    testDistance = 3;
    CircleList *nineManTestList = new CircleList;
    makingList(nineManTestList);
    makingSquad(nineManTestList, testSize);
    assert(killing(nineManTestList, testDistance) == 1);
}

int main()
{
    setlocale(LC_ALL, "Russian");
    test();
    CircleList *squad = new CircleList;
    makingList(squad);
    int n = 0;
    int m = 0;
    cout << "Введите количество воинов:" << endl;
    cin >> n;
    cout << "Введите интервал:" << endl;
    cin >> m;
    makingSquad(squad, n);
    printData(squad);
    cout << "В живых останется воин номер " << killing(squad, m) << ";" << endl;
    cout << "До свидания!";
    return 0;
}

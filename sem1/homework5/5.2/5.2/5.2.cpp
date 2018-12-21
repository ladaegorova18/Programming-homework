#include "pch.h"
#include <locale>
#include <iostream>
#include <assert.h>
using namespace std;

struct Node
{
	Node *next;
	int number;
};

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

void insertion(CircleList *myList, int newValue)
{
	myList->size++;
	Node* data = new Node;
	data->next = myList->head;
	data->number = newValue;
	if (myList->head != nullptr)
	{
		myList->tail->next = data;
		myList->tail = data;
	}
	else
	{
		myList->head = data;
		myList->tail = data;
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
		Node *current = squad->head;
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

void deleteList(CircleList *squad);

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
	cout << "Test passed" << endl;
	deleteList(oneManList);
	deleteList(nineManTestList);
}

void deleteList(CircleList *squad)
{
	Node* temp = squad->head->next;
	Node* prev = nullptr;
	while (temp && (temp != squad->head))
	{
		prev = temp;
		temp = temp->next;
		if (prev == temp)
		{
			delete temp;
			delete squad;
			return;
		}
		delete prev;
	}
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
	cout << "В живых останется воин номер " << killing(squad, m) << ";" << endl;
	cout << "До свидания!";
	deleteList(squad);
	return 0;
}

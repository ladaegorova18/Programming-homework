#include "pch.h"
#include <locale>
#include <iostream>
#include <assert.h>
using namespace std;

struct Node
{
	int number = 0;
	Node *next = nullptr;
};

struct CircleList
{
	int size = 0;
	Node *head = nullptr;
	Node *tail = nullptr;
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
	Node* data = new Node();
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

int killing(CircleList *squad, int distance)
{
	while (squad->size > 1)
	{
		Node *previous = squad->head;
		Node *current = squad->head->next;
		{
			for (int i = 1; i <= distance; i++)
			{
				previous = current;
				current = current->next;
			}
			previous->next = current->next;
			Node* temp = current;
			if (temp == squad->head)
			{
				squad->head = squad->head->next;
			}
			current = current->next;
			delete temp;
			squad->size--;
		}
	}
	return squad->head->number;
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
	killing(nineManTestList, testDistance);
	cout << "Test passed" << endl;
	deleteList(oneManList);
	deleteList(nineManTestList);
}

void deleteList(CircleList *squad)
{
	if (squad->size <= 1)
	{
		if (squad->head != nullptr)
		{
			delete squad->head;
		}
		delete squad;
		return;
	}
	Node* temp = squad->head->next;
	Node* prev = nullptr;
	while (temp && (temp != squad->head))
	{
		prev = temp;
		temp = temp->next;
		delete prev;
	}
	delete temp;
	delete squad;
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
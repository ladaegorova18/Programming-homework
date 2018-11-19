#include "pch.h"
#include <clocale>
#include <iostream>
#include <cstring>
#include "assert.h"
#include "header.h"
using namespace std;

void makingList(dynList *mylist)
{
	mylist->head = nullptr;
}

bool isEmpty(dynList *mylist)
{
	return (mylist->head == nullptr);
}

void test()
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
			cout << "Тест пройден" << endl;
			return;
		}
		else
		{
			assert(current->value <= current->next->value);
			current = current->next;
		}
	}
}

void menu(dynList *mylist)
{
	cout << "Это главное меню для работы со списком. Нажмите:\n1, чтобы добавить значение в список;\n2, чтобы удалить значение из списка;\n3, чтобы распечатать список;\n0, чтобы выйти." << endl;;
	int key = -1;
	cin >> key;
	if (key == 0)
	{
		return;
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
	dynList* mylist = new (dynList);
	makingList(mylist);
	menu(mylist);
	cout << "До свидания!";
	return 0;
}

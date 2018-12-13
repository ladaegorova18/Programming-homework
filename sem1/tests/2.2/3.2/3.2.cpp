#include "pch.h"
#include "options.h"
#include <clocale>
#include <iostream>
#include <fstream>
using namespace std;

bool symmetry(Element *head, Element *tail, int halfSize)
{
	Element *tempHead = head;
	cout << halfSize;
	for (int i = 1; i <= halfSize; i++)
	{
		if (tempHead->value == tail->value)
		{
			cout << "yes " << endl;
			Element *tempTail = head;
			tempHead = tempHead->next;
			for (int j = 0; j < 2 * halfSize - i; j++)
			{
				tempTail = tempTail->next;
				cout << tempTail->value << endl;
			}
			tail = tempTail;
			cout << endl;
			cout << tail->value;
		}
		else
		{
			return false;
		}
	}
	return true;
}

int main()
{
	setlocale(LC_ALL, "rus");
	DynList *list = new DynList;
	list->head = nullptr;
	list->size = 0;
	ifstream file;
	file.open("array.txt");
	if (!file)
	{
		cout << "file not found!" << endl;
		return 0;
	}
	while (!file.eof())
	{
		int value = 0;
		file >> value;
		insertion(list, value);
	}
	file.close();
	int halfSize = list->size / 2;
	Element *tail = list->head;
	for (int i = 0; i < list->size; i++)
	{
		tail = tail->next;
	}
	if (symmetry(list->head, tail, halfSize))
	{
		cout << "Список симметричен" << endl;
	}
	else
	{
		cout << "Список не симметричен" << endl;
	}
	return 0;
}

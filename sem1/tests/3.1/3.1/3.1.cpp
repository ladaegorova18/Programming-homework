#include "pch.h"
#include <fstream>
#include "options.h"
#include <iostream>
using namespace std;

int main()
{
	DynList *list = new DynList();
	list->head = nullptr;
	ifstream file;
	file.open("f.txt");
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
	cout << "Enter a" << endl;
	int a = 0;
	cin >> a;
	cout << "Enter b" << endl;
	int b = 0;
	cin >> b;
	ofstream g("g.txt");
	Element *current = list->head;
	g << "numbers less than a:";
	g << "\n";
	while (current != list->tail)
	{
		if (current->value < a)
		{
			g << current->value;
		}
		current = current->next;
	}
	g << "\n";
	g << "numbers less than b:" << endl;
	current = list->head;
	while (current != list->tail)
	{
		if ((current->value < b) && (current->value >= a))
		{
			g << current->value;
		}
		current = current->next;
	}
	g << "\n";
	g << "numbers greater than b:";
	g << "\n";
	current = list->head;
	while (current != list->tail)
	{
		if (current->value >= b)
		{
			g << current->value;
		}
		current = current->next;
	}
	g.close();
	cout << "Successfully!" << endl;
	return 0;
}
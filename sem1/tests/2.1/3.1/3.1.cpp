#include "pch.h"
#include <fstream>
#include <assert.h>
#include <string>
#include "options.h"
#include <iostream>
using namespace std;

void test()
{
	int testA = 4;
	int testB = 7;
	DynList *testList = new DynList();
	ifstream testFile;
	testFile.open("testFile.txt");
	if (!testFile)
	{
		cout << "file not found!" << endl;
		return;
	}
	while (!testFile.eof())
	{
		int value = 0;
		testFile >> value;
		insertion(testList, value);
	}
	testFile.close();
	ofstream testG("testG.txt");
	Element *current = testList->head;
	while (current != testList->tail)
	{
		if (current->value < testA)
		{
			testG << current->value;
		}
		current = current->next;
	}
	current = testList->head;
	testG << " ";
	while (current != testList->tail)
	{
		if ((current->value < testB) && (current->value >= testA))
		{
			testG << current->value;
		}
		current = current->next;
	}
	current = testList->head;
	testG << " ";
	while (current != testList->tail)
	{
		if (current->value >= testB)
		{
			testG << current->value;
		}
		current = current->next;
	}
	string result = "3213 46 7";
	testG.close();
	string stringG = "";
	ifstream resultGFile("testG.txt");
	while (resultGFile)
	{
		getline(resultGFile, stringG);
	}
	assert(result == stringG);
	cout << "Test passed:)" << endl;
}

int main()
{
	test();
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
	deleteList(list->head);
	return 0;
}
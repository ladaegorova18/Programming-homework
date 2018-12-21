#include "pch.h"
#include <iostream>
#include <fstream>
#include <locale>
#include <string>
#include "List.h"
#include <assert.h>

void test()
{
	std::ifstream file("test.txt");
	if (!file)
	{
		std::cout << "Файл не найден!" << std::endl;
		return;
	}
	DynList *list = makeList();
	while (!file.eof())
	{
		std::string buffer = " ";
		getline(file, buffer);
		insertion(list, buffer);
	}
	file.close();
	std::fstream newFile("newTest.txt");
	Element *temp = list->head;
	while (temp)
	{
		newFile << temp->value;
		newFile << "\n";
		temp = temp->next;
	}
	delete temp;
	std::string res[] = { "aaa", "bbb", "dddd", "eeee", "rrrr", "vvvv", "wwww" };
	newFile.close();
	std::fstream assertFile("newFile.txt");
	int i = 0;
	while (!assertFile.eof())
	{
		std::string buffer = "";
		assertFile >> buffer;
		assert(buffer == res[i]);
		++i;
	}
	assertFile.close();
	deleteList(list);
	std::cout << "Test passed" << std::endl;
}

int main()
{
	test();
	std::ifstream file("text.txt");
	if (!file)
	{
		std::cout << "Файл не найден!" << std::endl;
		return -1;
	}
	DynList *list = makeList();
	while (!file.eof())
	{
		std::string buffer = " ";
		getline(file, buffer);
		insertion(list, buffer);
	}
	file.close();
	std::ofstream newFile("newFile.txt");
	Element *temp = list->head;
	while (temp)
	{
		newFile << temp->value;
		newFile << "\n";
		temp = temp->next;
	}
	delete temp;
	newFile.close();
	std::cout << "" << std::endl;
	deleteList(list);
	std::cout << "Successfully!" << std::endl;
	return 0;
}
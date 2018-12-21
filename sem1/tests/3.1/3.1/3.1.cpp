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
	std::fstream newFile("newFile.txt");
	Element *temp = getHead(list);
	while (temp)
	{
		newFile << getValue(temp);
		newFile << "\n";
		temp = getNext(temp);
	}
	deleting(temp);
	std::string res[] = { "aaa", "bbb", "dddd", "eeee", "rrrr", "vvvv", "wwww" };
	newFile.close();
	std::ifstream assertFile("newFile.txt");
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
	std::ofstream newNewFile("newNewFile.txt");
	Element *temp = getHead(list);
	while (temp)
	{
		newNewFile << getValue(temp);
		newNewFile << "\n";
		temp = getNext(temp);
	}
	deleting(temp);
	newNewFile.close();
	std::cout << "" << std::endl;
	deleteList(list);
	std::cout << "Successfully!" << std::endl;
	return 0;
}
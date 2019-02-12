#include "pch.h"
#include "Graph.h"
#include <iostream>
#include <fstream>
#include <locale>
#include <assert.h>

void test()
{
	Graph *test = makeGraph(4);
	addNode(test, 1, 0, 1);
	addNode(test, 1, 1, 0);
	addNode(test, 1, 1, 2);
	addNode(test, 1, 2, 1);
	addNode(test, 1, 2, 3);
	addNode(test, 1, 3, 2);
	algorithmPrima(test);
	int parents[] = {-1, 0, 1, 2};
	int currentVert[] = { 0, 1, 2, 3 };
	int distances[] = { 0, 1, 1, 1 };
	for (int i = 0; i < 4; ++i)
	{
		assert(returnParent(test, i) == parents[i]);
		assert(returnKey(test, i) == distances[i]);
	}
	std::cout << "Тест пройден!" << std::endl;
	deleteGraph(test);
}

int main()
{
	setlocale(LC_ALL, "rus");
	test();
	std::ifstream file("matrix.txt");
	if (!file)
	{
		std::cout << "Файл не найден!" << std::endl;
		return -1;
	}
	int size = 0;
	file >> size;
	Graph *graph = makeGraph(size);
	while (!file.eof())
	{
		for (int i = 0; i < size; ++i)
		{
			for (int j = 0; j < size; ++j)
			{
				int value = 0;
				file >> value;
				if (value != 0)
				{
					addNode(graph, value, i, j);
				}
			}
		}
	}
	file.close();
	algorithmPrima(graph);
	std::cout << "Наименьшее остовное дерево этого графа:" << std::endl;
	printResult(graph); 
	std::cout << "До свидания!" << std::endl;
	deleteGraph(graph);
	return 0;
}
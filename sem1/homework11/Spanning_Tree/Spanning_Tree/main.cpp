#include "pch.h"
#include "Graph.h"
#include <iostream>
#include <fstream>
#include <locale>

int main()
{
	setlocale(LC_ALL, "rus");
	std::ifstream file("matrix.txt");
	Graph *graph = new Graph();
	if (!file)
	{
		std::cout << "Файл не найден!" << std::endl;
		return;
	}
	int size = 0;
	int value = 0;
	while ()////
	{
		file >> value;
		graph->matrix[0][size] = value;
		size++;
	}
	while (!file.eof())
	{
		for (int i = 1; i < size; ++i)
		{
			for (int j = 0; j < size; ++j)
			{
				file >> value;
				graph->matrix[i][j] = value;
			}
		}
	}
	file.close();
	graph->makeQueue();
	graph->algorithmPrima();
	graph->

	return 0;
}
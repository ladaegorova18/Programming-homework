#include "pch.h"
#include "Graph.h"
#include <iostream>
#include <fstream>
#include <locale>
#include <assert.h>

void reading(std::ifstream &file, Map*& map)
{
	int n = 0; // количество городов
	int m = 0; // число дорог
	file >> n;
	file >> m;
	resizing(map, n);
	for (int a = 0; a < m; a++)
	{
		int i = 0;
		int j = 0;
		int len = 0;
		file >> i >> j >> len;
		addRoad(map, i, j, len);
	}
	int k = 0; // столицы
	file >> k;
	kingsResizing(map, k);
	for (int i = 0; i < k; i++)
	{
		int capitalNumber = 0;
		file >> capitalNumber;
		addCapital(map, capitalNumber, i);
	}
}

void test()
{
	Map* testMap = makeMap();
	int cities = 3;
	resizing(testMap, cities);
	addRoad(testMap, 1, 2, 1);
	addRoad(testMap, 2, 3, 3);
	addRoad(testMap, 1, 3, 5);
	int capitals = 2;
	kingsResizing(testMap, capitals);
	addCapital(testMap, 1, 0);
	addCapital(testMap, 3, 1);
	war(testMap);
	assert(returnCity(testMap, 0, 0) == 1);
	assert(returnCity(testMap, 0, 1) == 2);
	assert(returnCity(testMap, 1, 0) == 3);
	std::cout << "Тест пройден!" << std::endl;
	deleteMap(testMap);
}

int main()
{
	setlocale(LC_ALL, "rus");
	test();
	Map* map = makeMap();
	std::ifstream file("kingdoms.txt");
	if (!file)
	{
		std::cout << "Файл не найден!" << std::endl;
		return -1;
	}
	reading(file, map);
	file.close();
	war(map);
	print(map);
	std::cout << "До свидания!" << std::endl;
	deleteMap(map);
	return 0;
}
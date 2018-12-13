#include "pch.h"
#include "Graph.h"
#include <iostream>
#include <fstream>
#include <locale>
#include <assert.h>

void addRoad(Map* map, int i, int j, int len)
{
	map->roads[i][j] = len;
	map->roads[j][i] = len;
}

void addCapital(Map* map, int capitalNumber, int i)
{
	map->kingdoms[i].push_back(capitalNumber);
	map->mark[capitalNumber] = 1; // столица уже кому-то принадлежит
}

void resizing(Map* map, int n)
{
	n++;
	map->mark.resize(n);
	map->roads.resize(n);
	for (int i = 0; i < n; i++)
	{
		map->roads[i].resize(n);
		for (int j = 0; j < n; j++)
		{
			map->roads[i][j] = INF;
		}
	}
}

void reading(std::ifstream &file, Map* map)
{
	int n = 0; // количество городов
	int m = 0; // число дорог
	file >> n;
	file >> m;
	resizing(map, n);
	while (!file.eof())
	{
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
		map->kingdoms.resize(k);
		for (int i = 0; i < k; i++)
		{
			int capitalNumber = 0;
			file >> capitalNumber;
			addCapital(map, capitalNumber, i);
		}
	}
}

void test()
{
	Map* testMap = new Map();
	int cities = 3;
	resizing(testMap, cities);
	addRoad(testMap, 1, 2, 1);
	addRoad(testMap, 2, 3, 3);
	addRoad(testMap, 1, 3, 5);
	int capitals = 2;
	testMap->kingdoms.resize(capitals);
	addCapital(testMap, 1, 0);
	addCapital(testMap, 3, 1);
	testMap->war();
	printing(testMap->kingdoms);
	assert(testMap->kingdoms[0][0] == 1);
	assert(testMap->kingdoms[0][1] == 2);
	assert(testMap->kingdoms[1][0] == 3);
	std::cout << "Тест пройден!" << std::endl;
}

int main()
{
	setlocale(LC_ALL, "rus");
	test();
	Map* map = new Map();
	std::ifstream file("kingdoms.txt");
	if (!file)
	{
		std::cout << "Файл не найден!" << std::endl;
		return 0;
	}
	reading(file, map);
	file.close();
	map->war();
	printing(map->kingdoms);
	std::cout << "До свидания!" << std::endl;
	return 0;
}
#include "pch.h"
#include "Graph.h"
#include <iostream>
#include <fstream>
#include <locale>
#include <assert.h>

void reading(std::ifstream &file, Map* map)
{
	if (!file)
	{
		std::cout << "Файл не найден!" << std::endl;
		return;
	}
	int n = 0; // cities
	int m = 0; // roads
	file >> n;
	file >> m;
	map->mark.resize(n);
	map->roads.resize(n);
	for (int i = 0; i < n; i++)
	{
		map->mark[i] = false;
		map->roads[i].resize(n);
		for (int j = 0; j < n; j++)
		{
			map->roads[i][j] = INF;
		}
	}
	while (!file.eof())
	{
		for (int a = 0; a < m; a++)
		{
			int i = 0;
			int j = 0;
			int len = 0;
			file >> i >> j >> len;
			map->roads[i][j] = len;
			map->roads[j][i] = len;
		}
		int k = 0; // capitals
		file >> k;
		map->kingdoms.resize(k);
		for (int i = 0; i < k; i++)
		{
			int capitalNumber = 0;
			file >> capitalNumber;
			map->kingdoms[i].push_back(capitalNumber);
			map->mark[capitalNumber] = 1; // столица уже кому-то принадлежит
		}
	}
}

void test()
{
	std::ifstream testFile("testFile.txt");
	Map* testMap = new Map();
	reading(testFile, testMap);
	testMap->war();

	testFile.close();
	std::cout << "Тест пройден!" << std::endl;
}

int main()
{
	setlocale(LC_ALL, "rus");
	test();
	Map* map = new Map();
	std::ifstream file("kingdoms.txt");
	reading(file, map);
	file.close();
	map->war();
	printing(map->kingdoms);
	std::cout << "До свидания!" << std::endl;
	system("pause");
	return 0;
}
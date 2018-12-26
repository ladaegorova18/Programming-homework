#include "pch.h"
#include "Graph.h"
#include <vector>
#include <iostream>
#include <fstream>

struct Map
{
	// массив расстояний между городами
	std::vector< std::vector<int> > roads;

	// kingdoms[i] массив государств; в каждом есть список владений, принадлежащих им
	std::vector< std::vector<int> > kingdoms;

	// отмечаем здесь города, в которых были
	std::vector <bool> mark{ false };
};

void addRoad(Map*& map, const int i, const int j, const int len)
{
	map->roads[i][j] = len;
	map->roads[j][i] = len;
}

void addCapital(Map*& map, const int capitalNumber, const int i)
{
	map->kingdoms[i].push_back(capitalNumber);
	map->mark[capitalNumber] = 1; // столица уже кому-то принадлежит
}

Map* makeMap()
{
	Map* map = new Map();
	return map;
}

int returnCity(Map *&map, const int i, const int j)
{
	return map->kingdoms[i][j];
}

void war(Map*& map)
{
	int count = 0;
	const int cities = map->mark.size();
	const int capitals = map->kingdoms.size();
	while (count < cities)
	{
		for (int i = 0; i < capitals; i++) // новое королевство
		{ 
			int min = INF;
			int newCity = -1;
			int currKingSize = map->kingdoms[i].size();
			for (int tempCity = 0; tempCity < currKingSize; tempCity++) // новый город в королевстве
			{
				for (int j = 0; j < cities; j++) // все города, связанные с ним
				{
					if ((map->roads[map->kingdoms[i][tempCity]][j] < min) && (!map->mark[j]))
					{
						min = map->roads[map->kingdoms[i][tempCity]][j];
						newCity = j;
					}
				}
			}
			if (newCity > 0)
			{
				map->kingdoms[i].push_back(newCity);
				map->mark[newCity] = 1;
			}
		}
		count++;
	}
}

void resizing(Map*& map, int n)
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

void kingsResizing(Map*& map, int k)
{
	map->kingdoms.resize(k);
}

void printing(std::vector<std::vector<int>> kingdoms)
{
	int kingSize = kingdoms.size();
	for (int i = 0; i < kingSize; i++)
	{
		int currKingdomSize = kingdoms[i].size();
		std::cout << i + 1 << " королевству принадлежат города: " << std::endl;
		for (int j = 0; j < currKingdomSize; j++)
		{
			std::cout << kingdoms[i][j] << " ";
		}
		std::cout << "\n";
	}
}

void print(Map*& map)
{
	printing(map->kingdoms);
}
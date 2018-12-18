#include "pch.h"
#include "pch.h"
#define _CRT_SECURE_NO_WARNINGS
#include "Graph.h"
#include <iterator>
#include <queue>
const int INF = 1000000000;

typedef std::pair<int, int> iPair;

Graph::Graph(int vertices)
{-
	this->vert = vertices;
	branches.resize(vertices);
	parent.resize(vertices);
}

void Graph::addNode(int dist, int i, int j)
{
	branches[i].push_back(std::make_pair(j, dist));
}

void Graph::algorithmPrima()
{
	std::priority_queue<iPair, std::vector<iPair>, std::greater<iPair>> pq;
	int current = 0; // current is vertex 0
	for (int i = 0; i < vert; ++i)
	{
		parent[vert] = -1;
	}
	std::vector<bool> included{ false };
	included.resize(vert);
	pq.push(std::make_pair(0, current));
	std::vector<int> key(vert, INF);
	key[current] = 0;
	while (!pq.empty())
	{
		int currVert = pq.top().second;
		pq.pop(); // взяли вершину и отметили, что она есть в MST
		included[currVert] = true;
		for (auto it = branches[currVert].begin(); it != branches[currVert].end(); ++it)
		{
			int v = it->first;
			int dist = it->second;
			if ((!included[v]) && (dist < key[v]))
			{
				key[v] = dist;
				pq.push(std::make_pair(key[v], v));
				parent[v] = currVert;
			}
		}
	}
	for (int i = 0; i < vert; ++i)
	{
		std::cout << parent[i] << " " << i << " " << key[i] << std::endl;
	}
}

void Graph::deleteGraph()
{
	for (int i = 0; i < vert; ++i)
	{
		branches[i].clear();
	}
	branches.clear();
	parent.clear();
}
/*
void Graph::printResult()
{
	for (int i = 0; i < vert; ++i)
	{
		std::cout << parent[i] << " " << i << " " << key[i] << std::endl;
	}
}*/
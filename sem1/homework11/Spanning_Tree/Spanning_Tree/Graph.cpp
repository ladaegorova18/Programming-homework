#include "pch.h"
#include "Graph.h"
#include <iterator>
#include <queue>
const int INF = 1000000000;

struct Graph
{
	int vert;
	std::vector<std::list<std::pair<int, int>>> branches;
	std::vector<int> parent;
	std::vector<int> key;
	Graph(const int vertices)
	{
		vert = vertices;
		branches.resize(vertices);
		parent.resize(vertices);
		key.resize(vertices);
	}
};

Graph* makeGraph(const int size)
{
	Graph* graph = new Graph(size);
	return graph;
}

void addNode(Graph *graph, const int dist, const int i, const int j)
{
	graph->branches[i].push_back(std::make_pair(j, dist));
}

void algorithmPrima(Graph *graph)
{
	std::priority_queue<std::pair<int, int>, std::vector<std::pair<int, int>>, std::greater<std::pair<int, int>>> pq;
	for (int i = 0; i < graph->vert; ++i)
	{
		graph->parent[i] = -1;
		graph->key[i] = INF;
	}
	std::vector<bool> included{ false };
	included.resize(graph->vert);
	int current = 0; 
	pq.push(std::make_pair(0, current));
	graph->key[current] = 0;
	while (!pq.empty())
	{
		int currVert = pq.top().second;
		pq.pop(); // взяли вершину и отметили, что она есть в MST
		included[currVert] = true;
		for (auto it = graph->branches[currVert].begin(); it != graph->branches[currVert].end(); ++it)
		{
			int v = it->first;
			int dist = it->second;
			if ((!included[v]) && (dist < graph->key[v]))
			{
				graph->key[v] = dist;
				pq.push(std::make_pair(graph->key[v], v));
				graph->parent[v] = currVert;
			}
		}
	}
}

void printResult(Graph const*const graph)
{
	for (int i = 1; i < graph->vert; ++i)
	{
		std::cout << graph->parent[i] << " " << i << " " << graph->key[i] << std::endl;
	}
}

int returnParent(Graph const*const graph, const int i)
{
	return graph->parent[i];
}

int returnKey(Graph const*const graph, const int i)
{
	return graph->key[i];
}

void deleteGraph(Graph *graph)
{
	delete graph;
}

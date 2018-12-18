#include "pch.h"
#include "Graph.h"
#include <iterator>
#include <queue>
const int INF = 1000000000;

void makeGraph(Graph graph, int vertices)
{
	graph.vert = vertices;
	graph.branches.resize(vertices);
	graph.parent.resize(vertices);
}

void addNode(Graph graph, int dist, int i, int j)
{
	graph.branches[i].push_back(std::make_pair(j, dist));
}

void algorithmPrima(Graph graph)
{
	std::priority_queue<std::pair<int, int>, std::vector<std::pair<int, int>>, std::greater<std::pair<int, int>>> pq;
	int current = 0; // current is vertex 0
	for (int i = 0; i < graph.vert; ++i)
	{
		graph.parent[graph.vert] = -1;
	}
	std::vector<bool> included{ false };
	included.resize(graph.vert);
	pq.push(std::make_pair(0, current));
	std::vector<int> key(graph.vert, INF);
	key[current] = 0;
	while (!pq.empty())
	{
		int currVert = pq.top().second;
		pq.pop(); // взяли вершину и отметили, что она есть в MST
		included[currVert] = true;
		for (auto it = graph.branches[currVert].begin(); it != graph.branches[currVert].end(); ++it)
		{
			int v = it->first;
			int dist = it->second;
			if ((!included[v]) && (dist < key[v]))
			{
				key[v] = dist;
				pq.push(std::make_pair(key[v], v));
				graph.parent[v] = currVert;
			}
		}
	}
	for (int i = 0; i < graph.vert; ++i)
	{
		std::cout << graph.parent[i] << " " << i << " " << key[i] << std::endl;
	}
}

void deleteGraph(Graph graph)
{
	for (int i = 0; i < graph.vert; ++i)
	{
		graph.branches[i].clear();
	}
	graph.branches.clear();
	graph.parent.clear();
}
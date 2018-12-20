#pragma once
#include <iostream>
#include <vector>
#include <list>
#include <utility>

struct Graph
{
	int vert;
	std::vector<std::list<std::pair<int, int>>> branches;
	std::vector<int> parent;
	std::vector<int> key;
	Graph(int vertices)
	{
		vert = vertices;
		branches.resize(vertices);
		parent.resize(vertices);
		key.resize(vertices);
	}
};

void algorithmPrima(Graph &graph);

void addNode(Graph &graph, int dist, int i, int j);

void printResult(Graph graph);

void deleteGraph(Graph &graph);


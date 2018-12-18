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
};

void makeGraph(Graph graph, int vertices);
void algorithmPrima(Graph graph);
void addNode(Graph graph, int dist, int i, int j);
//void printResult();
void deleteGraph(Graph graph);


#pragma once
#include <iostream>
#include <vector>
#include <list>
#include <utility>

class Graph
{
	int vert;
	std::vector<std::list<std::pair<int, int>>> branches;
	std::vector<int> parent;
public:
	Graph(int vertices);
	void algorithmPrima();
	void addNode(int dist, int i, int j);
	//void printResult();
	void deleteGraph();
};

#pragma once
#include <queue>
#include <iostream>
#include <vector>

struct Node
{
	int dist;
	int number;
	Node* parent;
	Node(int newDist, int newNumber)
	{
		dist = newDist;
		number = newNumber;
	}
};

struct Graph
{
	std::priority_queue<Node*> priorities;
	std::vector<Node> nodes;
	std::vector<std::vector<int>> matrix;
	std::vector<Node*> result;
	void makeQueue();
	void algorithmPrima();
	void addNode(int number);
	void printResult();
};

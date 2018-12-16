#include "pch.h"
#include "Graph.h"
#include <iterator>
#include <list>
const int INF = 1000000000;

void Graph::makeQueue()
{
	Node* first{ 0, 0 };
	priorities.push(first);
	for (unsigned int i = 1; i < matrix.size(); ++i)
	{
		Node* temp{ INF, i };
		priorities.push(temp);
	}
}

void Graph::addNode(int number)
{
	Node* temp{ 0, number };
	nodes.push_back(temp);
}

Node* min(std::priority_queue<Node> priorities)
{
	int minDist = INF;
	for ()
	{

		if ()
	}
	return min;
}

Node* find(std::priority_queue<Node> priorities, int number)
{

}

void Graph::algorithmPrima()
{
	while (!priorities.empty())
	{
		Node* minimal = priorities.top();
		result.push_back(minimal);
		int line = minimal->number;
		for (unsigned int number = 0; number < matrix.size(); ++i)
		{
			if (matrix[line][number] != 0)
			{
				Node* temp = find(nodes, number);
				if (matrix[line][number] < temp->dist)
				{
					temp->dist = matrix[line][number];
					temp->parent = minimal;
					priorities.pop();
				}
			}
		}
	}
}
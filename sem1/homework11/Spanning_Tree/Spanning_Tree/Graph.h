#pragma once
#include <iostream>
#include <vector>
#include <list>
#include <utility>

struct Graph;

Graph* makeGraph(const int size);

void algorithmPrima(Graph *&graph);

void addNode(Graph *&graph, const int dist, const int i, const int j);

void printResult(Graph *&graph);

void deleteGraph(Graph *&graph);

int returnParent(Graph *&graph, const int i);

int returnKey(Graph *&graph, const int i);


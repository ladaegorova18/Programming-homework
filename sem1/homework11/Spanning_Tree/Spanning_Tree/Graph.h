#pragma once
#include <iostream>
#include <vector>
#include <list>
#include <utility>

struct Graph;

Graph* makeGraph(const int size);

void algorithmPrima(Graph *graph);

void addNode(Graph *graph, const int dist, const int i, const int j);

void printResult(Graph const*const graph);

int returnParent(Graph const*const graph, const int i);

int returnKey(Graph const*const graph, const int i);

void deleteGraph(Graph* graph);


#pragma once
#include <vector>
#include <iostream>
const int INF = 1000000000;

struct Map;

void print(Map*& map);

void resizing(Map*& map, int n);

void kingsResizing(Map*& map, int k);

Map* makeMap();

void war(Map*& map);

void addRoad(Map*& map, const int i, const int j, const int len);

void addCapital(Map*& map, const int capitalNumber, const int i);

int returnCity(Map *&map, const int i, const int j);
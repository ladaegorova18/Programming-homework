#pragma once
#include <string>

struct Element;

struct Queue;

Queue* makeList();

void enqueue(Queue *myQueue, std::string value, int priority);

void printData(Queue *myQueue);

void deleteQueue(Queue *myQueue);

std::string dequeue(Queue *myList);
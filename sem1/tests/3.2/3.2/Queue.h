#pragma once
#include <string>

struct Element;

struct Queue;

Queue* makeQueue();

void enqueue(Queue *myQueue, std::string const &value, int priority);

void printData(Queue *myQueue);

void deleteQueue(Queue *myQueue);

std::string dequeue(Queue *myList);
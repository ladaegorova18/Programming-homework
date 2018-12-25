#pragma once
#include <iostream>
#include <string>

struct Node;

Node* merge(Node *&firstList, Node *&secondList);

Node* makingList();

int getValue(Node* list);

Node* nextNode(Node *list);

void addingData(Node *&head, int newValue);

void deleteList(Node *&head);

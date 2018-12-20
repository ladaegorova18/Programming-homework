#pragma once
#include <iostream>
#include <string>

struct Node;

void add(Node *&head, std::string value);

Node* makeList();

void deleteList(Node *&head);

void print(Node *head);

Node* makeUnrepList(Node *head);

Node* nextNode(Node* temp);

std::string getInfo(Node* temp);
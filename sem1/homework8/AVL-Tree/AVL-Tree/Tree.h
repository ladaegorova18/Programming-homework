#pragma once
#include <iostream>
#include <string>

struct Node;

struct Tree;

// проверяет, пустой корень или нет
bool isEmpty(Tree *tree);

// добавляет значение в дерево
bool addData(std::string const newData, const int index, Tree *&tree);

// обнуляет корень, создавая пустое дерево
Tree* makeTree();

// удаляет дерево
void deleteTree(Tree *&tree);

// получает значение по ключу
std::string getData(const int key, Tree *tree);

// проверяет наличие заданного ключа
Node* seekData(const int key, Tree *&tree);

// удаляет значение из дерева
void deleteInfo(int key, Tree *&tree);
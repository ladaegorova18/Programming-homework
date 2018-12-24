#pragma once

struct Element;

Element* makeElement();

struct Tree;

// вычисляет результат арифметического выражения
int count(Element* current);

// создает корень дерева и делает детей nullptr'ами
Tree* makeTree();

// добавляет символ из выражения на свое место в дереве
Element* adding(Tree* tree, const char symbol, Element *current);

// возвращает, равен ли корень nullptr
bool isEmpty(Tree* tree);

// возвращает корень дерева
Element* getRoot(Tree* tree);

// печатает дерево в явном виде
void printing(Element* current, const int level);

// удаляет дерево
void deleteTree(Tree* tree);
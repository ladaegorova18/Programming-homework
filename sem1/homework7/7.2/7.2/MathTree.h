#pragma once

struct Element
{
	int value;
	char operand;
	Element* leftChild;
	Element* rightChild;
};

struct Tree
{
	int count();

};
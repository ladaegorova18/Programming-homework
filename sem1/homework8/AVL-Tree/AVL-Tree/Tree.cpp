#include "pch.h"
#include "Tree.h"
#include <iostream>
#include <string>
using namespace std;

void Tree::makeTree()
{
	root = nullptr;
	count = 0;
}

bool Tree::isEmpty()
{
	return (root == nullptr);
}

unsigned char height(Node* temp)
{
	return temp ? temp->height : 0;
}

int bfactor(Node* temp)
{
	return height(temp->rightChild) - height(temp->leftChild);
}

void fixHeight(Node* temp)
{
	unsigned char heightLeft = height(temp->leftChild);
	unsigned char heightRight = height(temp->rightChild);
	temp->height = (heightLeft > heightRight) ? heightLeft : heightRight;
}

Node* rotateLeft(Node* temp)
{
	Node* newRoot = temp->rightChild;
	temp->rightChild = newRoot->leftChild;
	newRoot->leftChild = temp;
	fixHeight(temp);
	fixHeight(newRoot);
	return newRoot;
}

Node* rotateRight(Node* temp)
{
	Node* newRoot = temp->leftChild;
	temp->leftChild = newRoot->rightChild;
	newRoot->rightChild = temp;
	fixHeight(temp);
	fixHeight(newRoot);
	return newRoot;
}

Node* balance(Node* temp)
{
	fixHeight(temp);
	if (bfactor(temp) == 2)
	{
		if (bfactor(temp->rightChild) < 0)
		{
			temp->rightChild = rotateRight(temp->rightChild);
		}
		return rotateLeft(temp);
	}
	else if (bfactor(temp) == -2)
	{
		if (bfactor(temp->leftChild) > 0)
		{
			temp->leftChild = rotateLeft(temp->leftChild);
		}
		return rotateRight(temp);
	}
	else
	{
		return temp;
	}
}

Node* Tree::getRoot()
{
	return root;
}

Node* Tree::adding(string newData, const int index, Node* temp)
{
	count++;
	if (isEmpty())
	{
		root = new Node(index, newData);
		return root;
	}
	if (temp == nullptr)
	{
		temp = new Node(index, newData);
		return temp;
	}
	if (index < temp->key)
	{
		temp->leftChild = adding(newData, index, temp->leftChild);
	}
	else if (index > temp->key)
	{
		temp->rightChild = adding(newData, index, temp->rightChild);
	}
	else
	{
		temp->data = newData;
	}
	return balance(temp);
}

string Tree::getData(const int key, Node* temp)
{
	if (findData(key, root) != nullptr)
	{
		return findData(key, root)->data;
	}
	return "\n";
}

Node* Tree::findData(const int key, Node* temp)
{
	if (temp != nullptr)
	{
		if (key == temp->key)
		{
			return temp;
		}
		else if (temp->key > key)
		{
			return findData(key, temp->leftChild);
		}
		else
		{
			return findData(key, temp->rightChild);
		}
	}
	else
	{
		return nullptr;
	}
}

Node* findMin(Node* temp)
{
	return (temp->leftChild) ? findMin(temp->leftChild) : temp;
}

Node* removeMin(Node* temp)
{
	if (temp->leftChild == nullptr)
	{
		return temp->rightChild;
	}
	temp->leftChild = removeMin(temp->leftChild);
	return balance(temp);
}

Node* Tree::deleteFromRoot()
{
	Node* leftChild = root->leftChild;
	Node* rightChild = root->rightChild;
	delete root;
	if (rightChild == nullptr)
	{
		root = leftChild;
		return leftChild;
	}
	Node* min = findMin(rightChild);
	min->rightChild = removeMin(rightChild);
	min->leftChild = leftChild;
	root = min;
	return balance(min);
}

Node* Tree::deleteData(int key, Node* temp)
{
	count--;
	if (count == 0)
	{
		makeTree();
		return nullptr;
	}
	if (temp == nullptr)
	{
		delete temp;
		return nullptr;
	}
	if (key < temp->key)
	{
		temp->leftChild = deleteData(key, temp->leftChild);
	}
	else if (key > temp->key)
	{
		temp->rightChild = deleteData(key, temp->rightChild);
	}
	else
	{
		if (key == root->key)
		{
			deleteFromRoot();
			return root;
		}
		Node* temp = findData(key, root);
		Node* leftChild = temp->leftChild;
		Node* rightChild = temp->rightChild;
		delete temp;
		if (rightChild == nullptr)
		{
			return leftChild;
		}
		Node* min = findMin(rightChild);
		min->rightChild = removeMin(rightChild);
		min->leftChild = leftChild;
		return balance(min);
	}
	return balance(temp);
}

void Tree::deleteTree(Node* temp)
{
	if (temp != nullptr)
	{
		deleteTree(temp->leftChild);
		deleteTree(temp->rightChild);
		delete temp;
	}
}

int Tree::getSize()
{
	return count;
}
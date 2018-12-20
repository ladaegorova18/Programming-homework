#include "pch.h"
#include "Tree.h"
#include <iostream>
#include <string>
using namespace std;

struct Node
{
	Node* leftChild;
	Node* rightChild;
	std::string data;
	int key;
	int height;
	Node(int index, std::string newData) {
		key = index;
		data = newData;
		leftChild = nullptr;
		rightChild = nullptr;
		height = 1;
	}
};

struct Tree
{
	Node* root;
};

Tree* makeTree()
{
	Tree* tree = new Tree();
	tree->root = nullptr;
	return tree;
}

bool isEmpty(Tree *tree)
{
	return (tree->root == nullptr);
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

Node* adding(std::string const newData, const int index, Node *&temp)
{
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

bool addData(std::string const newData, const int index, Tree *&tree)
{
	return adding(newData, index, tree->root);
}

Node* findData(const int key, Node* temp)
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

Node* seekData(const int key, Tree *&tree)
{
	return findData(key, tree->root);
}

string getData(const int key, Tree *tree)
{
	if (seekData(key, tree) != nullptr)
	{
		return findData(key, tree->root)->data;
	}
	return "\n";
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

Node* deleteFromRoot(Node *&root)
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

Node* deleteData(int key, Node*& temp, Node *&root)
{
	if (temp == nullptr)
	{
		delete temp;
		return nullptr;
	}
	if (key < temp->key)
	{
		temp->leftChild = deleteData(key, temp->leftChild, root);
	}
	else if (key > temp->key)
	{
		temp->rightChild = deleteData(key, temp->rightChild, root);
	}
	else
	{
		if (key == root->key)
		{
			deleteFromRoot(root);
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

void deleteInfo(int key, Tree *&tree)
{
	deleteData(key, tree->root, tree->root);
}

void deleteNode(Node*& temp)
{
	if (temp != nullptr)
	{
		deleteNode(temp->leftChild);
		deleteNode(temp->rightChild);
		delete temp;
	}
}

void deleteTree(Tree *&tree)
{
	deleteNode(tree->root);
	delete tree;
}
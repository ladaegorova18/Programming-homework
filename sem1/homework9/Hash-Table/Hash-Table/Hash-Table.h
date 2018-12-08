#pragma once
#include "List.h"
#include <vector>
#include <list>
#include <string>

struct Set
{
private:
	std::vector<List> buckets;
	int elements;
public:
	bool exists(std::string const &str);
	void adding(std::string data);
	void makeSet();
	void printing();
	void deleteSet();
	void statistics();
	int theAverageLength();
	int theMaxLength();
	double coefHash();
};

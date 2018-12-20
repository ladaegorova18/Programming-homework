#pragma once

struct Set;

Set* createSet();
void deleteSet(Set *set);
bool add(Set* set, int const  data);
bool remove(Set* set, int const data);
bool exists(Set* set, int const data);
bool isEmpty(Set* set);
void printIncrease(Set *set);
void printDecrease(Set *set);

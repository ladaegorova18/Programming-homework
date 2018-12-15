#ifndef STACK_H
#define STACK_H
const int MAX = 100;

struct Stack
{
private:
	int top;
	char node[MAX];

public:
	// ������� ����, ���������� ������� �������� ���������� top
	void makeStack();

	// ��������� ������� � ����, ��� ����� ����������� top �� ������� � � ��������������� ������� ������� ���������� ��������
	// ���� ���������� ��������� ��������� ������������, ������� ��������� �� ����
	void push(char element);

	// ��������� ������� �� �����. ���� �� ����, ������� ��������������� ���������. ����� ���������� ������� ������� � ��������� ���������� top �� ����
	char pop();

	// �������� ����� �� �������. ���� ������ �������� �������� ����� ����, ���������� true
	bool isEmpty();

	// ���������� ���������� ��������� � �����
	int sizeOfStack();
};

#endif // STACK_H
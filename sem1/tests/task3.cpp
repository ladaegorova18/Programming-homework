#include <stdlib.h>
#include <stdio.h>
#include <stdlib.h>
#include <iostream>
#include <string>
using namespace std;

void reading(char* data[100])
{
    for (int linesRead = 0; linesRead < 100; linesRead++)
    {
        for (int symbol = 0; symbol < 100; symbol++)
        {
            if (data[linesRead][symbol] == ';')
            {
                while (symbol < 100)
                {
                    printf("%c", data[linesRead][symbol]);
                    symbol++;
                }

                break;
            }
        }
    }
}

int main()
{
    FILE *file = fopen("test.txt", "r");
    if (!file)
    {
        printf("file not found!");
        return 1;
    }
    char *data[100] = { };
    int linesRead = 0;
    while (!feof(file))
    {
        char *buffer = new char[100];
        const int readBytes = fscanf(file, "%[^\n]", buffer);
        if (readBytes < 0)
        {
            break;
        }
        data[linesRead] = buffer;
        ++linesRead;
        fclose(file);
    }
    reading(data);
    return 0;
}

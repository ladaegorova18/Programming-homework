#include <iostream>
#include <fstream>
#include <cstdlib>
using namespace std;

int main()
{
    int compNumber = 0;
    fstream gfile;
    gfile.open("g.txt");
    if (gfile)
    {

        gfile >> compNumber;
    }
    else
    {
        cout << "File not found!" << endl;
    }
    gfile.close();
    fstream fileToRead;
    fileToRead.open("f.txt");


    int *myArray = new int[10];
    int j = 0;
    if (fileToRead)
    {
        for (int i = 0; i < 10; i++)
        {
            fileToRead >> myArray[j];
            j++;
        }
    }
    else
    {
        cout << "File not found!" << endl;
    }
    fileToRead.close();
    ofstream fileWrite("h.txt");
    {
        for (int i = 0; i < j; i++)
        {
            if (myArray[i] < compNumber)
            {
                fileWrite << myArray[i] << endl;
                cout << myArray[i] << " ";
            }
        }
    }
    fileWrite.close();
    delete myArray;
    return 0;
}

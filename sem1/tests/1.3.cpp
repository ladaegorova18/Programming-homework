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
    if (!fileToRead)
    {
        cout << "File not found!" << endl;
    }
    int number = 0;
    ofstream fileWrite("h.txt");
    {
        while (!fileToRead.eof())
        {
            fileToRead >> number;
            if (number < compNumber)
            {
                fileWrite << number << " ";
                cout << number << " ";
            }
        }
    }
    fileToRead.close();
    fileWrite.close();
    return 0;
}

#include iostream
using namespace std;
#define MAXLEN 100
 
int main()
{
    float sa;
    int s, array[MAXLEN];
    int i, inputLenght, br;
 
    do{
        cout  Enter the size of the array. n(1 = n =100) n= ;
        cin  inputLenght;
    }
 
    while (inputLenght1  inputLenghtMAXLEN);
    cout  Enter the array's elements n;
 
    for (i = 0; i  inputLenght; i++)
    {
        cout   a[  i   ] = ;
        cin  array[i];
    }
 
    for (s = i = br = 0; i  inputLenght; i++)
    {
        if (array[i] % 2 == 0)
        {
            s += array[i];
            br++;
        }
    }
    if (br != 0){
        sa = s  br;
        cout  The average value of the elements in the array is   sa  n;
    }
    else {
        cout  There are no elements that are even n;
    }
 
    system(pause);
}
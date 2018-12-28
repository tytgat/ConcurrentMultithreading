// ConsoleApplication2.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>
#include <stdlib.h>
#include <ctime>

#define SIZE 60

using namespace std;

void printMat(int ** M) {
	for (int i = 0; i < SIZE; i++) {
		for (int j = 0; j < SIZE; j++) {
			cout << M[i][j] << ",";
		}
		cout << endl;
	}
	cout << endl;
}


int main()
{
	/*Init Mat*/
	int ** A = new int*[SIZE];
	int ** B = new int*[SIZE];
	int ** C = new int*[SIZE];
	for (int i = 0; i < SIZE; i++) {
		A[i] = new int[SIZE];
		B[i] = new int[SIZE];
		C[i] = new int[SIZE];
	}

	/*Fill Mat*/
	for (int i = 0; i < SIZE; i++) {
		for (int j = 0; j < SIZE; j++) {
			A[i][j] = rand() % 100;
			B[i][j] = rand() % 100;
		}
	}
	clock_t begin = clock();
#pragma omp parallel for shared(C)
	{
		for (int i = 0; i < SIZE; i++) {
#pragma omp parallel for shared(C,i)
			for (int j = 0; j < SIZE; j++) {
				int sum = 0;
				for (int k = 0; k < SIZE; k++) {
					sum += A[i][k] * B[k][j];
				}
				C[i][j] = sum;
			}
		}
	}
	clock_t end = clock();
	float elapsed_secs = float(end - begin) / CLOCKS_PER_SEC;
	cout << elapsed_secs << "s" << endl;
	cout << endl;
	/*
	printMat(A);
	printMat(B);
	printMat(C);
	*/
	/*Free Mat*/
	for (int i = 0; i < SIZE; i++) {
		free(A[i]);
		free(B[i]);
		free(C[i]);
	}
	free(A);
	free(B);
	free(C);

}

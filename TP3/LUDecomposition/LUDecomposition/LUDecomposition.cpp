// LUDecomposition.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
#pragma once
#include "pch.h"
#include <iostream>

//#include "Matrice.h"

int main()
{
	int matSize = 4;
    std::cout << "Hello World!\n"; 
	/*typedef std::shared_ptr<Matrice> myMatrice;
	
	myMatrice A(new Matrice(matSize));
	A->makeRandom();
	A->print();
	
	myMatrice L(new Matrice(matSize));
	myMatrice U(new Matrice(matSize));
	myMatrice P(new Matrice(matSize));
	myMatrice A2(new Matrice(matSize));
	//P = P->multiply(A2);
	//P->print();*/
	/*
	for (int j = 0; j < matSize; j++) {
		L->set(1, j, j);
		for (int i = 0; i < j + 1; i++) {
			double s1 = 0;
			for (int k = 0; k < i; k++)
				s1 += U->get(k,j) * L->get(i,k);
			U->set(A2->get(i, j) - s1, i, j);
		}
		for (int i = j; i < matSize; i++) {
			double s2 = 0;
			for (int k = 0; k < j; k++)
				s2 += U[k][j] * L[i][k];
			L[i][j] = (A2[i][j] - s2) / U[j][j];
		}
	}*/
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
#include "pch.h"
#include <iostream>
#include <ctime>

#define SIZE 1500

using namespace std;

int roundFloat(float val) {
	return (int)(val + 0.5);

}

void printMat(float ** M) {
	for (int i = 0; i < SIZE; i++) {
		for (int j = 0; j < SIZE; j++) {
			cout << float(int(M[i][j] * 100)) / 100 << ", ";
		}
		cout << endl;
	}
	cout << endl;
}

int checkResult(float** L, float ** U, float ** M) {
	float ** C = new float*[SIZE];
	for (int i = 0; i < SIZE; i++) {
		C[i] = new float[SIZE];
	}
#pragma omp parallel for shared(C)
	for (int i = 0; i < SIZE; i++) {
#pragma omp parallel for shared(C,i)
		for (int j = 0; j < SIZE; j++) {
			float sum = 0;
			for (int k = 0; k < SIZE; k++) {
				sum += L[i][k] * U[k][j];
			}
			C[i][j] = sum;
		}
	}
	for (int i = 0; i < SIZE; i++) {
		for (int j = 0; j < SIZE; j++) {
			if (roundFloat(C[i][j]) != roundFloat(M[i][j])) {
				for (int i = 0; i < SIZE; i++) {
					free(C[i]);
				}
				free(C);
				return false;
			}
		}
	}

	for (int i = 0; i < SIZE; i++) {
		free(C[i]);
	}
	free(C);
	return true;
}


int main()
{
	/*Init Mat*/
	float ** L = new float*[SIZE];
	float ** U = new float*[SIZE];
	float ** M = new float*[SIZE];
	for (int i = 0; i < SIZE; i++) {
		L[i] = new float[SIZE];
		U[i] = new float[SIZE];
		M[i] = new float[SIZE];
	}

	/*Fill Mat*/
	for (int i = 0; i < SIZE; i++) {
		for (int j = 0; j < SIZE; j++) {
			M[i][j] = float(rand() % 10);
			L[i][j] = 0;
			U[i][j] = 0;
		}
	}
	clock_t begin = clock();
	for (int i = 0; i < SIZE; i++) {
		{
			//Para U computing --> U[i][k] is modified but never used (i <> j)
#pragma omp parallel for shared(U)
			/* U */
			for (int k = i; k < SIZE; k++) {
				float sum = 0;
				//Para sum of values
#pragma omp parallel for  reduction(+:sum)
				for (int j = 0; j < i; j++) {
					sum += (L[i][j] * U[j][k]);
				}
				U[i][k] = M[i][k] - sum;
			}
			
			//Para L computing --> L[i][k] is modified but never used (i <> j)
#pragma omp parallel for shared(L)
			/* L */
			for (int k = i; k < SIZE; k++) {
				if (i == k)
					L[i][i] = 1; // Diag
				else {
					float sum = 0;
					//Para sum of values
#pragma omp parallel for reduction(+:sum)
					for (int j = 0; j < i; j++) {
						sum += (L[k][j] * U[j][i]);
					}
					L[k][i] = (M[k][i] - sum) / U[i][i];
				}
			}
		}
	}
	clock_t end = clock();
	float elapsed_secs = float(end - begin) / CLOCKS_PER_SEC;
	cout << elapsed_secs << "s" << endl;
	cout << endl;


	if (checkResult(L,U,M)) {
		cout << "result OK" << endl;
	}
	else {
		cout << "Wrong result" << endl;
	}

	/*Free Mat*/
	for (int i = 0; i < SIZE; i++) {
		free(L[i]);
		free(U[i]);
		free(M[i]);
	}
	free(L);
	free(U);
	free(M);
}

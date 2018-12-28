
#include "cuda_runtime.h"
#include "device_launch_parameters.h"

#include <stdio.h>
#include <stdlib.h>

#define N 5
#define M 3

//cudaError_t addWithCuda(int *c, const int *a, const int *b, unsigned int size);
__global__ void MatAdd(int A[][M], int C[][N]) {
	int i = threadIdx.x;
	int j = threadIdx.y;
	int k = blockIdx.x; 
	int val = (A[k][i] - A[k][j]) * (A[k][i] - A[k][j]);
	extern __shared__ int sharedC[N][N];
	sharedC[i][j] = C[i][j];

	if (i == 0 && j == 1)
		printf("[%d - %d] - %d => %d + %d -- (%d-%d)^2\n", i, j, k, val, sharedC[i][j], A[k][i], A[k][j]);

	__syncthreads();
	sharedC[i][j] += val;
	__syncthreads();
	
	C[i][j] = sharedC[i][j];
}

int main() {

	int A[N][M] = { {0,1,1},{4,0,2},{3,1,1},{0,0,0},{2,1,2} };
	int C[N][N];
	int i, j;
	/*for (i = 0; i < N; i++) {
		for (j = 0; j < M; j++) {
			A[i][j] = i + j;
			printf("%d ", A[i][j]);
		}
		printf("\n");
	}*/

	for (i = 0; i < N; i++) {
		for (j = 0; j < N; j++) {
			C[i][j] = 0;
		}
	}

	int(*pA)[M], (*pC)[N];

	cudaMalloc((void**)&pA, (N*M) * sizeof(int));
	cudaMalloc((void**)&pC, (N*N) * sizeof(int));

	cudaMemcpy(pA, A, (N*M) * sizeof(int), cudaMemcpyHostToDevice);
	cudaMemcpy(pC, C, (N*N) * sizeof(int), cudaMemcpyHostToDevice);

	int numBlocks = N;
	dim3 threadsPerBlock(N,N);
	int k;
	//for (k = 0; k < N; k++) {
		MatAdd <<<numBlocks, threadsPerBlock >> > (pA, pC);
	//}

	cudaMemcpy(C, pC, (N*N) * sizeof(int), cudaMemcpyDeviceToHost);

	printf("C = \n");
	for (i = 0; i < N; i++) {
		for (j = 0; j < N; j++) {
			printf("%d ", C[i][j]);
		}
		printf("\n");
	}

	cudaFree(pA);
	cudaFree(pC);

	printf("\n");

	return 0;
}
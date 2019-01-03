
#include "cuda_runtime.h"
#include "device_launch_parameters.h"

#include <stdio.h>
#include <stdlib.h>
#include <time.h>

//#define BLOCK_SIZE 4

#define N 256
#define BLOCK_SIZE 3

__global__ void matMult(float * a, float * d, int n){
	int bx = blockIdx.x;
	int by = blockIdx.y;
	int tx = threadIdx.x; // y index
	int ty = threadIdx.y;

	int ia = n * BLOCK_SIZE * by + n * ty; // index A 
	int ib = BLOCK_SIZE * bx + tx; //index B
	int ic = ia + ib;

	int indexLst = ic;
	int i = indexLst / n;
	int j = indexLst % n;

	float sum = 0.0f;
	__shared__ float ai[BLOCK_SIZE][BLOCK_SIZE+1];
	__shared__ float aj[BLOCK_SIZE][BLOCK_SIZE+1];

	for (int k = 0; k < BLOCK_SIZE; k++) {
		ai[i][k] = a[k + i * BLOCK_SIZE];
		aj[j][k] = a[k + j * BLOCK_SIZE];
	}
	__syncthreads();
	for (int l = 0; l < BLOCK_SIZE; l++) {
		sum += (ai[i][l] - aj[j][l]) * (ai[i][l] - aj[j][l]);
	}
	__syncthreads();
	d[indexLst] = sum;
}

int main() {
	//define memory size
	int numBytes = N * N * sizeof(float); 

	float h_A[N*BLOCK_SIZE];
	float h_D[N*N];

	/*init matrix*/ 
	int i = 0;
	for (i = 0; i < N*BLOCK_SIZE; i++) {
		h_A[i] = (float)i+1;
	}
	for (i = 0; i < N*N; i++) {
		h_D[i] = 0.0;
	}
	

	//assign variable for device
	float * d_A;
	float * d_D;

	// allocate device memory
	cudaMalloc((void**)&d_A, numBytes);
	cudaMalloc((void**)&d_D, numBytes);

	// set kernel launch configuration
	dim3 threads(BLOCK_SIZE, BLOCK_SIZE);
	dim3 blocks(N/ BLOCK_SIZE,N/ BLOCK_SIZE);
	
	//copy data from host to device
	cudaMemcpy(d_A, h_A, numBytes, cudaMemcpyHostToDevice);
	
	clock_t begin = clock();
	//kernel launch
	matMult <<<blocks, threads >> > (d_A, d_D, N);
	clock_t end = clock();
	double time_spent = (double)(end - begin);
	printf("%d", time_spent);
	//copy data from device to host
	cudaMemcpy(h_D, d_D, numBytes, cudaMemcpyDeviceToHost);

	/*for (i = 0; i < N*N; i++) {
		if (i%N == 0) {
			printf("\n");
		}
		printf("%.1f,\t", h_D[i]);
	}*/

	//memory free
	cudaFree(d_A);
	cudaFree(d_D);


	return 0;

}
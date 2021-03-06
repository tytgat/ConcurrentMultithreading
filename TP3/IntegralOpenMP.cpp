// cpp_compiler_options_openmp.cpp  
#include "pch.h"
#include <omp.h>  
#include <stdio.h>  
#include <stdlib.h>  
#include <windows.h>  

#include <math.h>

#include <ctime>
#include <random>
#include <iostream>

double myFunction(double x) //f(x) = sin(x²)
{
	return x+(tan((sin(x*x))));
}

double ComputeIntegralThread(double lowLimit, double upLimit, int numberOfSegments)
{

	if (lowLimit > upLimit)
	{
		return ComputeIntegralThread(upLimit, lowLimit, numberOfSegments);
	}

	double pas = (upLimit - lowLimit) / numberOfSegments;
	double sum = 0.0;
	double r = myFunction(lowLimit);

	#pragma omp parallel for reduction(+:r)
	for (int limit = 1; limit < numberOfSegments; limit++)
	{
		double c = lowLimit + (double)limit * pas;
		r += myFunction(c);
	} 
	r = pas * r;
	return r;
}

double ComputeIntegral(double lowLimit, double upLimit, int numberOfSegments)
{

	if (lowLimit > upLimit)
	{
		return ComputeIntegral(upLimit, lowLimit, numberOfSegments);
	}

	double pas = (upLimit - lowLimit) / numberOfSegments;
	double sum = 0.0;
	double r = myFunction(lowLimit);

	for (int limit = 1; limit < numberOfSegments; limit++)
	{
		double c = lowLimit + (double)limit * pas;
		r += myFunction(c);
	}
	r = pas * r;
	return r;
}

int main(int argc, char * argv[]) {

	int result = 0;

	double b = 0.0; //lower bound
	double a = 50.0; //upper bound

	int n = 1000000;
	clock_t beginT = clock();
	for (int i = 0; i < 1000; i++) {
		result = ComputeIntegralThread(a, b, n);
	}
	clock_t endT = clock();
	double elapsed_secsT = double(endT - beginT) / CLOCKS_PER_SEC;
	std::cout << result << std::endl;
	std::cout << elapsed_secsT << std::endl;

	clock_t begin = clock();
	for (int j = 0; j < 1000; j++) {
		result = ComputeIntegral(a, b, n);
	}
	clock_t end = clock();
	double elapsed_secs = double(end - begin) / CLOCKS_PER_SEC;
	std::cout << result << std::endl;
	std::cout << elapsed_secs << std::endl;
	return 0;
}
#pragma once
#ifndef MATRICE_H
#define MATRICE_H


#include "pch.h"
#include <memory>
#include <iostream>

#include <vector>



class Matrice
{
	typedef std::shared_ptr<Matrice> myMatrice;
	int _size;
	std::shared_ptr<std::shared_ptr<double[]>[]>  _mat;

public:
	void makeRandom();
	void print();
	myMatrice multiply(myMatrice m2);

	double get(int i, int j);
	void set(double val, int i, int j);

	Matrice(int size);
	~Matrice();

private:
	//static double dotProduct(int size, std::shared_ptr<double[]> a, std::shared_ptr<double[]> b);
};
#endif

#pragma once
#include "pch.h"
#include "Matrice.h"

//#include <random>
//#include <numeric>


typedef std::shared_ptr<Matrice> myMatrice;
void Matrice::makeRandom()
{
	/*random*/
	//double lower_bound = 0;
	//double upper_bound = 100;
	/*std::uniform_real_distribution<double> unif(lower_bound, upper_bound);
	std::default_random_engine re;

	for (int i = 0; i < _size; ++i)
	{
		for (int j = 0; j < _size; ++j)
			_mat[i][j] = unif(re);
	}*/
}

void Matrice::print()
{
	/*for (int i = 0; i < _size; ++i)
	{
		for (int j = 0; j < _size; ++j)
			std::cout << _mat[i][j] << ",";
		std::cout << std::endl;
	}*/
}

myMatrice Matrice::multiply(myMatrice m2)
{
	myMatrice result(new Matrice(_size));
	/*std::shared_ptr<double[]> aux(new double[_size]);

	for (int j = 0; j < _size; j++) {

		for (int k = 0; k < _size; k++)
			aux[k] = m2->get(k,j);

		for (int i = 0; i < _size; i++) {

			result->set(Matrice::dotProduct(_size, _mat[i], aux), i, j);
		}
	}*/
	return result;
	
}

double Matrice::get(int i, int j)
{
	return _mat[i][j];
}

void Matrice::set(double val, int i, int j)
{
	_mat[i][j] = val;
}

Matrice::Matrice(int size) : _size{ size },
_mat{ std::make_shared< std::shared_ptr<double[]>[] >(_size) }
{
	/*for (int i = 0; i < _size; ++i)
	{
		_mat[i] = std::make_shared< double[] >(size);

		for (int j = 0; j < _size; ++j)
			_mat[i][j] = 0;
	}*/
}


Matrice::~Matrice()
{
}

/*double Matrice::dotProduct(int size, std::shared_ptr<double[]> a, std::shared_ptr<double[]> b)
{
	std::vector<double> v1;
	std::vector<double> v2;

	/*for (int i = 0; i < size; i++) {
		v1.push_back(a[i]);
		v2.push_back(b[i]);
	}
	
	return 0.0;
	//return std::inner_product((v1).begin(), (v1).end(), (v2).begin(), 0.0);
}*/
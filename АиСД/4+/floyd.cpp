#include <iostream>
using namespace std;
const int maxV = 1000;
const int V = 6;
int S[V][V];
int D[V][V] = {
	{0, 28, 21, 59, 12, 27},
	{7, 0, 24, INT_MAX, 21, 9},
	{9, 32, 0, 13, 11, INT_MAX},
	{8, INT_MAX, 5, 0, 16, INT_MAX},
	{14, 13, 15, 10, 0, 22},
	{15, 18, INT_MAX, INT_MAX, 6, 0}
};
void floyd() {
	for (int i = 0; i < V; i++) {
		for (int j = 0; j < V; j++) {
			if (i == j) {
				D[i][j] = 0;
				S[i][j] = 0;
			}
			else
				S[i][j] = j + 1;
		}
	}
	for (int k = 0; k < V; k++)
		for (int i = 0; i < V; i++)
			for (int j = 0; j < V; j++)
				if (D[i][k] + D[k][j] < D[i][j]) {
					D[i][j] = D[i][k] + D[k][j];
					S[i][j] = S[i][k];
				}
	for (int i = 0; i < V; i++) {
		for (int j = 0; j < V; j++)
			cout << D[i][j] << "\t";
		cout << endl;
	}
	cout << "������� ������������������ ������: " << endl;
	for (int i = 0; i < V; i++) {
		for (int j = 0; j < V; j++)
			cout << S[i][j] << "\t";
		cout << endl;
	}
}
void main() {
	setlocale(LC_ALL, "Russian");
	cout << "������� ���������� �����:" << endl;
	floyd();
}
#include <iostream>
using namespace std;
const int V = 9;
void Dijkstra(int GR[V][V], int st) {
	int distance[V]{}, index, u, m = st + 1;
	bool visited[V]{};
	for (int i = 0; i < V; i++) {
		distance[i] = INT_MAX;
		visited[i] = false;
	}
	distance[st] = 0;
	for (int count = 0; count < V - 1; count++) {
		int min = INT_MAX;
		for (int i = 0; i < V; i++)
			if (!visited[i] && distance[i] <= min) {
				min = distance[i];
				index = i;
			}
		u = index;
		visited[u] = true;
		for (int i = 0; i < V; i++)
			if (!visited[i] && GR[u][i] && distance[u] != INT_MAX && distance[u] + GR[u][i] < distance[i])
				distance[i] = distance[u] + GR[u][i];
	}
	cout << "Стоимость пути из начальной вершины до остальных:\t\n";
	for (int i = 0; i < V; i++) {
		if (distance[i] != INT_MAX)
			cout << m << " > " << i + 1 << " = " << distance[i] << endl;
		else
			cout << m << " > " << i + 1 << " = " << "маршрут недоступен" << endl;
	}
}
void main() {
	setlocale(LC_ALL, "Russian");
	int start;
	int GR[V][V] = {
		{0,  7,  10, 0,  0,  0,  0,  0,  0},
		{7,  0,  0,  0,  0,  9,  27, 0,  0},
		{10, 0,  0,  0,  31, 8,  0,  0,  0},
		{0,  0,  0,  0,  32, 0,  0,  17, 21},
		{0,  0,  31, 32, 0,  0,  0,  0,  0},
		{0,  9,  8,  0,  0,  0,  0,  11, 0},
		{0,  27, 0,  0,  0,  0,  0,  0,  15},
		{0,  0,  0,  17, 0,  11, 0,  0,  15},
		{0,  0,  0,  21, 0,  0,  15, 15, 0}
	};
	char startPoint;
	cout << "Начальная вершина >> ";
	cin >> startPoint;
	char word[9] = { 'A','B','C','D','E','F','G','H','I' };
	for (int i = 0; i < 9; i++) {
		if (word[i] == startPoint)
			start = i;
	}
	Dijkstra(GR, start);
}
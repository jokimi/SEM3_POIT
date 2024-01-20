#include <iostream>
#include <vector>
#include <algorithm> 
#include "Graph.h"
using namespace std;
int main() {
    setlocale(LC_ALL, "Russian");
    Graph graph;
    cout << "Список ребер остовного дерева и их вес (через алгоритм Прима)" << endl;
    graph.Prim();
    cout << "\nСписок ребер остовного дерева и их вес (через алгоритм Краскала)" << endl;
    graph.Kruskal();
}
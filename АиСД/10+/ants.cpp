#include <iostream>
#include <vector>
#include <algorithm>
#include <cmath>

const int MAX_ITERATIONS = 100;
const double ALPHA = 1.0;  // Параметр альфа
const double BETA = 2.0;   // Параметр бета
const double EVAPORATION = 0.5;  // Коэффициент испарения феромонов

class Ant {
public:
    Ant(int numCities) : numCities(numCities) {
        tabuList.resize(numCities, false);
        path.resize(numCities);
    }

    void clear() {
        std::fill(tabuList.begin(), tabuList.end(), false);
        path.clear();
    }

    void visitCity(int city) {
        tabuList[city] = true;
        path.push_back(city);
    }

    bool isVisited(int city) const {
        return tabuList[city];
    }

    int getCurrentCity() const {
        return path.back();
    }

    const std::vector<int>& getPath() const {
        return path;
    }

private:
    int numCities;
    std::vector<bool> tabuList;
    std::vector<int> path;
};

class AntColony {
public:
    AntColony(int numCities, const std::vector<std::vector<double>>& distanceMatrix)
        : numCities(numCities), distanceMatrix(distanceMatrix) {
        pheromoneMatrix.resize(numCities, std::vector<double>(numCities, 1.0));
    }

    void run() {
        bestPathLength = std::numeric_limits<double>::max();

        for (int iteration = 0; iteration < MAX_ITERATIONS; ++iteration) {
            resetAnts();
            constructSolutions();
            updatePheromones();
            updateBestPath();
        }
    }

    const std::vector<int>& getBestPath() const {
        return bestPath;
    }

    double getBestPathLength() const {
        return bestPathLength;
    }

private:
    int numCities;
    std::vector<std::vector<double>> distanceMatrix;
    std::vector<std::vector<double>> pheromoneMatrix;
    std::vector<Ant> ants;
    std::vector<int> bestPath;
    double bestPathLength;

    void resetAnts() {
        for (auto& ant : ants) {
            ant.clear();
        }
    }

    void constructSolutions() {
        for (auto& ant : ants) {
            ant.visitCity(rand() % numCities);

            while (ant.getPath().size() < numCities) {
                int currentCity = ant.getCurrentCity();
                int nextCity = selectNextCity(ant);
                ant.visitCity(nextCity);
            }
        }
    }

    int selectNextCity(const Ant& ant) {
        int currentCity = ant.getCurrentCity();
        double total = 0.0;

        for (int city = 0; city < numCities; ++city) {
            if (!ant.isVisited(city)) {
                total += pow(pheromoneMatrix[currentCity][city], ALPHA) *
                    pow(1.0 / distanceMatrix[currentCity][city], BETA);
            }
        }

        double randomValue = static_cast<double>(rand()) / RAND_MAX;
        double cumulativeProbability = 0.0;

        for (int city = 0; city < numCities; ++city) {
            if (!ant.isVisited(city)) {
                double probability =
                    pow(pheromoneMatrix[currentCity][city], ALPHA) *
                    pow(1.0 / distanceMatrix[currentCity][city], BETA) /
                    total;

                cumulativeProbability += probability;

                if (randomValue <= cumulativeProbability) {
                    return city;
                }
            }
        }

        return -1;  // Недостижимый код
    }

    void updatePheromones() {
        for (auto& row : pheromoneMatrix) {
            for (auto& value : row) {
                value *= EVAPORATION;
            }
        }

        for (const auto& ant : ants) {
            const auto& path = ant.getPath();
            double pathLength = calculatePathLength(path);

            for (int i = 0; i < numCities - 1; ++i) {
                int city1 = path[i];
                int city2 = path[i + 1];
                pheromoneMatrix[city1][city2] += 1.0 / pathLength;
                pheromoneMatrix[city2][city1] += 1.0 / pathLength;
            }
        }
    }

    double calculatePathLength(const std::vector<int>& path) const {
        double length = 0.0;

        for (int i = 0; i < numCities - 1; ++i) {
            int city1 = path[i];
            int city2 = path[i + 1];
            length += distanceMatrix[city1][city2];
        }

        return length;
    }

    void updateBestPath() {
        for (const auto& ant : ants) {
            const auto& path = ant.getPath();
            double pathLength = calculatePathLength(path);

            if (pathLength < bestPathLength) {
                bestPathLength = pathLength;
                bestPath = path;
            }
        }
    }
};

int main() {
    setlocale(LC_ALL, "Russian");
    int numCities;
    std::cout << "Введите количество городов: ";
    std::cin >> numCities;

    std::vector<std::vector<double>> distanceMatrix(numCities, std::vector<double>(numCities));

    std::cout << "Введите расстояния между городами:\n";
    for (int i = 0; i < numCities; ++i) {
        for (int j = 0; j < numCities; ++j) {
            std::cout << "Расстояние от города " << i << " до города " << j << ": ";
            std::cin >> distanceMatrix[i][j];
        }
    }

    int initialPheromone;
    double alpha, beta;
    int numIterations;

    std::cout << "Введите начальное значение феромонов: ";
    std::cin >> initialPheromone;

    std::cout << "Введите значение альфа: ";
    std::cin >> alpha;

    std::cout << "Введите значение бета: ";
    std::cin >> beta;

    std::cout << "Введите количество итераций: ";
    std::cin >> numIterations;

    srand(time(NULL));  // Инициализация генератора случайных чисел

    AntColony antColony(numCities, distanceMatrix);
    antColony.run();

    std::cout << "Лучший маршрут: ";
    const std::vector<int>& bestPath = antColony.getBestPath();
    for (int city : bestPath) {
        std::cout << city << " ";
    }
    std::cout << std::endl;

    std::cout << "Расстояние лучшего маршрута: " << antColony.getBestPathLength() << std::endl;

    return 0;
}
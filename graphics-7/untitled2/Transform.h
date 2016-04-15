#include <array>
#include <vector>


value struct point {
	float x, y;
};

value struct line {
	point start, end;
	System::String^ name;
};

// Порядок матрицы преобразований
// Для N-мерных преобразований порядок N+1 
#define M 3
typedef std::tr1::array<float, M> vec;
typedef std::tr1::array<vec, M> mat;
typedef System::Collections::Generic::List<point> polygon;

// Матрица совмещенного преобразования
extern mat T, R;
extern std::vector<mat> matrices;

// Умножение матрицы a на матрицу b и запись результата в матрицу c
void times(mat a, mat b, mat &result);

// Умножение матрицы a на вектор b и запись результата в вектор c
void timesMatVec(mat a, vec b, vec &result);

// Присвоение матрицы а матрице b
void set(mat a, mat &result);

// Преобразует декартовы координаты точки в однородные координаты (вектор)
void point2vec(point a, vec &b);

// Преобразует однородные координаты (вектор) в декартовы координаты точки
void vec2point(vec a, point &b);

// Преобразует декартовы координаты точки в однородные координаты (вектор)
void makeHomogenVec(float x, float y, vec &c);

// Преобразование матрицы в еденичную матрицу
void unit(mat &a);

// Восстановление изображения к минимальному размеру
void limit(mat &a);

// Процедура передвижения изображения к точке
void move(float x, float y, mat &result);

// Процедура вращения изображения против часовой стрелки относительно крайней точки окна
void rotateCounterclockwisePivot(float angle, mat &result);

// Процедура вращения изображения по часовой стрелки относительно крайней точки окна
void rotateClockwisePivot(float angle, mat &result);

// Процедура вращения изображения против часовой стрелки относительно заданной точки
void rotateCounterclockwisePoint(float angle, float x, float y, mat &result);

// Процедура вращения изображения по часовой стрелки относительно заданной точки
void rotateClockwisePoint(float angle, float x, float y, mat &result);

// Процедура масштабирования относительной крайней точки окна
void scaleOverPivot(float scalar, mat &result);

void scaleOverPivot(float scalarX, float scalarY, mat &result);

// Процедура масштабирования относительной заданной точки
void scaleOverPoint(float scalar, float x, float y, mat &result);

void scaleOverPoint(float scalarX, float scalarY, float x, float y, mat &result);

// Процедура масштабирования относительно горизонтальной линии
void scaleHorizontally(float scalar, float lineY, mat &result);

// Процедура масштабирования относительно вертикальной линии
void scaleVertically(float scalar, float lineX, mat &result);

// Процедура отображения изображения относительно горизонтальной линии
void reflectHorizontally(float lineY, mat &result);

// Процедура отображения изображения относительно вертикальной линии
void reflectVertically(float lineX, mat &result);

// Процедура кадрирования
void frame(float Vx, float Vy, float Vcx, float Vcy,
			float Wx, float Wy, float Wcx, float Wcy,
			mat &c);
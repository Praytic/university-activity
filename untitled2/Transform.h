#include <fstream>
#include <sstream>

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
typedef float vec[M];
typedef float mat[M][M];

// Матрица совмещенного преобразования
extern mat T;

// Умножение матрицы a на матрицу b и запись результата в матрицу c
void times(mat a, mat b, mat c);
// Умножение матрицы a на вектор b и запись результата в вектор c
void timesMatVec(mat a, vec b, vec c);
// Присвоение матрицы а матрице b
void set(mat a, mat b);
// Преобразует декартовы координаты точки в однородные координаты (вектор)
void point2vec(point a, vec b);
// Преобразует однородные координаты (вектор) в декартовы координаты точки
void vec2point(vec a, point &b);
// Преобразует декартовы координаты точки в однородные координаты (вектор)
void makeHomogenVec(float x, float y, vec c);
// Преобразование матрицы в еденичную матрицу
void unit(mat a);
// Процедура поворота
void move(float Tx, float Ty, mat c);
// Процедура вращения
void rotate(float phi, mat c);
// Процедура вращения относительно точки
void rotatePoint(float phi, mat c, point p);
// Процедура масштабирования
void scale(float S, mat c);
void scale(float Sx, float Sy, mat c);
// Процедура масштабирования по горизонтали
void scaleHorizontally(float S, mat c);
// Процедура масштабирования по вертикали
void scaleVertically(float S, mat c);
// Процедура кадрирования
void frame(float Vx, float Vy, float Vcx, float Vcy,
			float Wx, float Wy, float Wcx, float Wcy,
			mat c, point utmost);
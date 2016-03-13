#include <fstream>
#include <sstream>

value struct point {
	float x, y;
};

value struct line {
	point start, end;
	System::String^ name;
};

// ������� ������� ��������������
// ��� N-������ �������������� ������� N+1 
#define M 3
typedef float vec[M];
typedef float mat[M][M];

// ������� ������������ ��������������
extern mat T;

// ��������� ������� a �� ������� b � ������ ���������� � ������� c
void times(mat a, mat b, mat c);
// ��������� ������� a �� ������ b � ������ ���������� � ������ c
void timesMatVec(mat a, vec b, vec c);
// ���������� ������� � ������� b
void set(mat a, mat b);
// ����������� ��������� ���������� ����� � ���������� ���������� (������)
void point2vec(point a, vec b);
// ����������� ���������� ���������� (������) � ��������� ���������� �����
void vec2point(vec a, point &b);
// ����������� ��������� ���������� ����� � ���������� ���������� (������)
void makeHomogenVec(float x, float y, vec c);
// �������������� ������� � ��������� �������
void unit(mat a);
// ��������� ��������
void move(float Tx, float Ty, mat c);
// ��������� ��������
void rotate(float phi, mat c);
// ��������� �������� ������������ �����
void rotatePoint(float phi, mat c, point p);
// ��������� ���������������
void scale(float S, mat c);
void scale(float Sx, float Sy, mat c);
// ��������� ��������������� �� �����������
void scaleHorizontally(float S, mat c);
// ��������� ��������������� �� ���������
void scaleVertically(float S, mat c);
// ��������� ������������
void frame(float Vx, float Vy, float Vcx, float Vcy,
			float Wx, float Wy, float Wcx, float Wcy,
			mat c, point utmost);
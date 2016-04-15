#include <array>
#include <vector>


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
typedef std::tr1::array<float, M> vec;
typedef std::tr1::array<vec, M> mat;
typedef System::Collections::Generic::List<point> polygon;

// ������� ������������ ��������������
extern mat T, R;
extern std::vector<mat> matrices;

// ��������� ������� a �� ������� b � ������ ���������� � ������� c
void times(mat a, mat b, mat &result);

// ��������� ������� a �� ������ b � ������ ���������� � ������ c
void timesMatVec(mat a, vec b, vec &result);

// ���������� ������� � ������� b
void set(mat a, mat &result);

// ����������� ��������� ���������� ����� � ���������� ���������� (������)
void point2vec(point a, vec &b);

// ����������� ���������� ���������� (������) � ��������� ���������� �����
void vec2point(vec a, point &b);

// ����������� ��������� ���������� ����� � ���������� ���������� (������)
void makeHomogenVec(float x, float y, vec &c);

// �������������� ������� � ��������� �������
void unit(mat &a);

// �������������� ����������� � ������������ �������
void limit(mat &a);

// ��������� ������������ ����������� � �����
void move(float x, float y, mat &result);

// ��������� �������� ����������� ������ ������� ������� ������������ ������� ����� ����
void rotateCounterclockwisePivot(float angle, mat &result);

// ��������� �������� ����������� �� ������� ������� ������������ ������� ����� ����
void rotateClockwisePivot(float angle, mat &result);

// ��������� �������� ����������� ������ ������� ������� ������������ �������� �����
void rotateCounterclockwisePoint(float angle, float x, float y, mat &result);

// ��������� �������� ����������� �� ������� ������� ������������ �������� �����
void rotateClockwisePoint(float angle, float x, float y, mat &result);

// ��������� ��������������� ������������� ������� ����� ����
void scaleOverPivot(float scalar, mat &result);

void scaleOverPivot(float scalarX, float scalarY, mat &result);

// ��������� ��������������� ������������� �������� �����
void scaleOverPoint(float scalar, float x, float y, mat &result);

void scaleOverPoint(float scalarX, float scalarY, float x, float y, mat &result);

// ��������� ��������������� ������������ �������������� �����
void scaleHorizontally(float scalar, float lineY, mat &result);

// ��������� ��������������� ������������ ������������ �����
void scaleVertically(float scalar, float lineX, mat &result);

// ��������� ����������� ����������� ������������ �������������� �����
void reflectHorizontally(float lineY, mat &result);

// ��������� ����������� ����������� ������������ ������������ �����
void reflectVertically(float lineX, mat &result);

// ��������� ������������
void frame(float Vx, float Vy, float Vcx, float Vcy,
			float Wx, float Wy, float Wcx, float Wcy,
			mat &c);
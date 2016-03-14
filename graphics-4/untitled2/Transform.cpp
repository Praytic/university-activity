#pragma once
#include "stdafx.h"
#include "Transform.h"
#include <math.h>

mat T;

void times(mat a, mat b, mat result) {
	for(int i = 0; i < M; i++) {
		for(int j = 0; j < M; j++) {
			float scalar = 0;
			for(int k = 0; k < M; k++)
				scalar += a[i][k] * b[k][j];
			result[i][j] = scalar;
		}
	}
}

void timesMatVec(mat a, vec b, vec result) {
	for(int i = 0; i < M; i++) {
		float scalar = 0;
		for(int j = 0; j < M; j++)
			scalar += a[i][j] * b[j];
		result[i] = scalar;
	}
}

void set(mat a, mat result) {
	for(int i = 0; i < M; i++)
		for (int j = 0; j < M; j++)
			result[i][j] = a[i][j];
}

void point2vec(point a, vec result) {
	result[0] = a.x; result[1] = a.y; result[2] = 1;
}

void vec2point(vec a, point &result) {
	result.x = ((float)a[0])/a[2];
	result.y = ((float)a[1])/a[2];
}

void makeHomogenVec(float x, float y, vec result){
	result[0] = x; result[1] = y; result[2] = 1;
}

void unit(mat result) {
	for (int i = 0; i < M; i++) {
		for (int j = 0; j < M; j++) {
			if (i == j) result[i][j] = 1;
			else result[i][j] = 0;
		}
	}

}

void move(float x, float y, mat result) {
	unit (result);
	/*
	* | 1 0 x |
	* | 0 1 y |
	* | 0 0 1 |
	*/
	result[0][M-1] = x;
	result[1][M-1] = y;
}

void rotateCounterclockwisePivot(float angle, mat result) {
	unit (result);
	float A = angle;
	/*
	* | cos(A) -sin(A) 0 |
	* | sin(A)  cos(A) 0 |
	* | 0		0	   1 |
	*/
	result[0][0] = cos(A); 
	result[0][1] = -sin(A);
	result[1][0] = sin(A); 
	result[1][1] = cos(A);
}

void rotateClockwisePivot(float angle, mat result) {
	unit (result);
	float A = angle;
	/*
	* | cos(A)  sin(A) 0 |
	* | -sin(A) cos(A) 0 |
	* | 0		0	   1 |
	*/
	result[0][0] = cos(A);  
	result[0][1] = sin(A);
	result[1][0] = -sin(A); 
	result[1][1] = cos(A);
}

void rotateCounterclockwisePoint(float angle, float x, float y, mat result) {
	unit (result);
	float A = angle;
	float X = x*(1-cos(A))+y*sin(A);
	float Y = y*(1-cos(A))-x*sin(A);
	/*
	* | cos(A) -sin(A) X |
	* | sin(A)  cos(A) Y |
	* | 0		0	   1 |
	*/
	result[0][0] = cos(A); 
	result[0][1] = -sin(A); 
	result[0][2] = X;
	result[1][0] = sin(A); 
	result[1][1] = cos(A);  
	result[1][2] = Y;
}

void rotateClockwisePoint(float angle, float x, float y, mat result) {
	unit (result);
	float A = angle;
	float Rx = x*(1-cos(A))+x*sin(A);
	float Ry = y*(1-cos(A))-y*sin(A);
	/*
	* | cos(A)  sin(A) Rx |
	* | -sin(A) cos(A) Ry |
	* | 0		0	   1  |
	*/
	result[0][0] = cos(A);  
	result[0][1] = sin(A); 
	result[0][2] = Rx;
	result[1][0] = -sin(A); 
	result[1][1] = cos(A); 
	result[1][2] = Ry;
}

void scaleOverPivot(float scalar, mat result) {
	unit (result);
	float S = scalar;
	/*
	* | S 0 0 |
	* | 0 S 0 |
	* | 0 0 1 |
	*/
	result[0][0] = S;
	result[1][1] = S;
}

void scaleOverPivot(float scalarX, float scalarY, mat result) {
	unit (result);
	float Sx = scalarX;
	float Sy = scalarY;
	/*
	* | Sx 0  0 |
	* | 0  Sy 0 |
	* | 0  0  1 |
	*/
	result[0][0] = Sx;
	result[1][1] = Sy;
}

void scaleOverPoint(float scalar, float x, float y, mat result) {
	unit (result);
	float S = scalar;
	float X = x*(1-S);
	float Y = y*(1-S);
	/*
	* | S 0 X |
	* | 0 S Y |
	* | 0 0 1 |
	*/
	result[0][0] = S; 
	result[0][2] = X;
	result[1][1] = S; 
	result[1][2] = Y;
}

void scaleOverPoint(float scalarX, float scalarY, float x, float y, mat result) {
	unit (result);
	float Sx = scalarX;
	float Sy = scalarY;
	float X = x*(1-Sx);
	float Y = y*(1-Sy);
	/*
	* | Sx 0  X |
	* | 0  Sy Y |
	* | 0  0  1 |
	*/
	result[0][0] = Sx; 
	result[1][1] = Sy; 
	result[0][2] = X;
	result[1][2] = Y;
}

void scaleHorizontally(float scalar, float lineY, mat result) {
	unit (result);
	float S = scalar;
	float Y = lineY*(1-S);
	/*
	* | S 0 0 |
	* | 0 1 Y |
	* | 0 0 1 |
	*/
	result[1][1] = S; 
	result[1][2] = Y;
}

void scaleVertically(float scalar, float lineX, mat result) {
	unit (result);
	float S = scalar;
	float X = lineX*(1-S);
	/*
	* | 1 0 X |
	* | 0 S 0 |
	* | 0 0 1 |
	*/
	result[0][0] = S; 
	result[0][2] = X;
}

void reflectHorizontally(float lineY, mat result){
	unit (result);
	float L = lineY*2;
	/*
	* | 1  0 0 |
	* | 0 -1 L |
	* | 0  0 1 |
	*/
	result[1][1] = -1; 
	result[1][2] = L;
}

void reflectVertically(float lineX, mat result){
	unit (result);
	float L = lineX*2;
	/*
	* | -1 0 L |
	* |  0 1 0 |
	* |  0 0 1 |
	*/
	result[0][0] = -1; 
	result[0][2] = L;
}

void frame (float Vx, float Vy, float Vcx, float Vcy,
			float Wx, float Wy, float Wcx, float Wcy,
			mat result, point utmost) {
	unit (result);
	mat R, T1;
	move(-Vcx, -Vcy, R);
	times(R, result, T1);
	set(T1, result);
	scaleOverPivot(Wx/Vx, Wy/Vy, R);
	times(R, result, T1);
	set(T1, result);
	reflectHorizontally(0, R);
	times(R, result, T1);
	set(T1, result);
	move(Wcx, Wcy, R);
	times(R, result, T1);
	set(T1, result);
	//scaleOverPoint(Wx/Vx, -Wy/Vy, Wcx-((Vcx*Wx)/Vx), Wcy+((Vcy*Wy)/Vy), result);

	//result[0][0] = Wx/Vx;  
	//result[1][1] = -Wy/Vy; 
	//result[0][2] = Wcx-((Vcx*Wx)/Vx);
	//result[1][2] = Wcy+((Vcy*Wy)/Vy);
}

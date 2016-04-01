#pragma once
#include "stdafx.h"
#include "Transform.h"
#include "clip.h"

bool clip(point &A, point &B, point Pmin, point Pmax) {
	while (true) {
		float x1 = A.x, x2 = B.x,
			y1 = A.y, y2 = B.y,
			xmin = Pmin.x, ymin = Pmin.y,
			xmax = Pmax.x, ymax = Pmax.y;

		int C1 = 0;
		if (x1 < xmin) C1 += 1;
		if (x1 > xmax) C1 += 2;
		if (y1 < ymin) C1 += 4;
		if (y1 > ymax) C1 += 8;

		int C2 = 0;
		if (x2 < xmin) C2 += 1;
		if (x2 > xmax) C2 += 2;
		if (y2 < ymin) C2 += 4;
		if (y2 > ymax) C2 += 8;

		if (C1 == C2 && C2 == 0) 
			return true;
	
		if ((C1 & C2) != 0) 
			return false;

		if (C1 == 0) {
			float tmp = x1; x1 = x2; x2 = tmp;
			tmp = y1; y1 = y2; y2 = tmp;
			int tmp2 = C1; C1 = C2; C2 = tmp2;
		}

		if ((C1 & 1) != 0) {
			y1 = y2 - (x2 - xmin) * (y2 - y1) / (x2 - x1);
			x1 = xmin;
		}
		if ((C1 & 2) != 0) {
			y1 = y2 - (x2 - xmax) * (y2 - y1) / (x2 - x1);
			x1 = xmax;
		}
		if ((C1 & 4) != 0) {
			x1 = x2 - (y2 - ymin) * (x2 - x1) / (y2 - y1);
			y1 = ymin;
		}
		if ((C1 & 8) != 0) {
			x1 = x2 - (y2 - ymax) * (x2 - x1) / (y2 - y1);
			y1 = ymax;
		}
		A.x = x1;
		A.y = y1;
		B.x = x2;
		B.y = y2;
	}
}


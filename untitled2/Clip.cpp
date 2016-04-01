#pragma once
#include "stdafx.h"
#include "Transform.h"
#include "Clip.h"
#include <math.h>

bool clip(point &A, point &B, point Pmin, point Pmax) {
    int C1, C2;
    float temp;

    while (true) {
        C1 = 0;
        if (A.x < Pmin.x) C1 += 1;
        if (A.x > Pmax.x) C1 += 2;
        if (A.y < Pmin.y) C1 += 4;
        if (A.y > Pmax.y) C1 += 8;

        C2 = 0;
        if (B.x < Pmin.x) C2 += 1;
        if (B.x > Pmax.x)  C2 += 2;
        if (B.y < Pmin.y) C2 += 4;
        if (B.y > Pmax.y) C2 += 8;

        if (C1 == 0 && C2 == 0) return true;

        if ((C1 & C2) != 0) return false;

        if (C1 == 0) {
            temp = A.x; A.x = B.x; B.x = temp;
            temp = A.y; A.y = B.y; B.y = temp;
            C1 = C2; C2 = 0;
        }
        if ((C1 & 1) != 0) {
            temp = (B.y - A.y) / (B.x - A.x);
            A.y = B.y - (B.x - Pmin.x) * temp;
            A.x = Pmin.x;
        }
        else if ((C1 & 2) != 0) {
            temp = (B.y - A.y) / (B.x - A.x);
            A.y = B.y - (B.x - Pmax.x) * temp;
            A.x = Pmax.x;
        }
        else if ((C1 & 4) != 0) {
            temp = (B.x - A.x) / (B.y - A.y);
            A.x = B.x - (B.y - Pmin.y) * temp;
            A.y = Pmin.y;
        }
        else if ((C1 & 8) != 0) {
            temp = (B.x - A.x) / (B.y - A.y);
            A.x = B.x - (B.y - Pmax.y) * temp;
            A.y = Pmax.y;
        }
    }
}
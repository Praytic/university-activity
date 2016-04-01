#pragma once

#include "stdafx.h"
#include "Transform.h"
#include <cmath>

float f(float x) {
    return 1/x;
}
bool fexists(float x) {
    if (abs(x) < 1e-2f)
        return false;
    else return true;
}

#pragma once
#include "stdafx.h"
#include "Transform.h"
#include "PClip.h"
#include <math.h>
#include <algorithm>
#include <vector>
#include <math.h>

polygon^ Pclip (polygon^ P, point Pmin, point Pmax)
{
	point p1;
	p1.x = P[P->Count - 1].x;
	p1.y = P[P->Count - 1].y;
	int k = 1;
	int n1 = 0;
	polygon^ P1 = gcnew polygon(0);
m:	
		if(k>P->Count)
			return P1;
		else
		{
		point p2;
		p2.x = P[k - 1].x;
		p2.y = P[k - 1].y;
		float dx = p2.x - p1.x;
		float dy = p2.y - p1.y;
		point in;
		point out;
		if (dx > 0 || (dx == 0 && p1.x > Pmax.x))
		{
			in.x = Pmin.x;
			out.x = Pmax.x;
		}
		else
		{
			in.x = Pmax.x;
			out.x = Pmin.x;
		}
		if (dy > 0 || (dy == 0 && p1.y > Pmax.y))
		{
			in.y = Pmin.y;
			out.y = Pmax.y;
		}
		else
		{
			in.y = Pmax.y;
			out.y = Pmin.y;
		}
		point tout, tin;
		if (dx != 0)
			tout.x = (out.x - p1.x) / dx;
		else
			if (p1.x >= Pmin.x && p1.x <= Pmax.x)
				tout.x = FLT_MAX;
			else
				tout.x = -FLT_MAX - 1;
		if (dy != 0)
			tout.y = (out.y - p1.y) / dy;
		else
			if (p1.y >= Pmin.y && p1.y <= Pmax.y)
				tout.y = FLT_MAX;
			else
				tout.y = -FLT_MAX - 1;
		float t1out, t2out, t2in;
		if (tout.x < tout.y)
		{
			t1out = tout.x;
			t2out = tout.y;
		}
		else
		{
			t1out = tout.y;
			t2out = tout.x;
		}
		if (t2out > 0)
		{
			if (dx != 0)
				tin.x = (in.x - p1.x) / dx;
			else
				tin.x = -FLT_MAX - 1;
			if (dy != 0)
				tin.y = (in.y - p1.y) / dy;
			else
				tin.y = -FLT_MAX - 1;
			if (tin.x < tin.y)
				t2in = tin.y;
			else
				t2in = tin.x;
			if (t1out < t2in)
			{
				if (t1out > 0 && t1out <= 1)
				{
					n1++;
					if (tin.x < tin.y)
					{
						point ppr;
						ppr.x = out.x;
						ppr.y = in.y;
						P1->Add(ppr);
					}
					else
					{
						point ppr;
						ppr.x = in.x;
						ppr.y = out.y;
						P1->Add(ppr);
					}
				}
			}
			else
				if (t1out > 0 && t2in <= 1)
				{
					if (t2in >= 0)
					{
						n1++;
						if (tin.x > tin.y)
						{
							point ppr;
							ppr.x = in.x;
							ppr.y = p1.y + tin.x*dy;
							P1->Add(ppr);
						}
						else
						{
							point ppr;
							ppr.x = p1.x + tin.y*dx;
							ppr.y = in.y;
							P1->Add(ppr);
						}
					}
					if (t1out <= 1)
					{
						n1++;
						if (tout.x < tout.y)
						{
							point ppr;
							ppr.x = out.x;
							ppr.y = p1.y + tout.x*dy;
							P1->Add(ppr);
						}
						else
						{
							point ppr;
							ppr.x = p1.x + tout.y*dx;
							ppr.y = out.y;
							P1->Add(ppr);
						}
					}
					else
					{
						n1++;
						point ppr;
						ppr.x = p2.x;
						ppr.y = p2.y;
						P1->Add(ppr);
					}
				}
			if (t2out > 0 && t2out <= 1)
			{
				n1++;
				point ppr;
				ppr.x = out.x;
				ppr.y = out.y;
				P1->Add(ppr);
			}
		}
		p1.x = p2.x;
		p1.y = p2.y;
		k++;
		goto m;
	}
}
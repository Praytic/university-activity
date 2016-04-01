#pragma once
#include "stdafx.h"
#include "Transform.h"

System::Void Make_Line(std::ofstream& out, int x1, int y1, int x2, int y2) {
	out << x1 << ' ' << y1 << ' ' << x2 << ' ' << y2 << '\n';
}

System::Void Make_House(std::ofstream& out) {
	Make_Line(out, 80, 0, 210, 0);
	Make_Line(out, 80, 150, 210, 150);
	Make_Line(out, 80, 0, 80, 150);
	Make_Line(out, 210, 0, 210, 150);
	Make_Line(out, 140, 120, 160, 120);
	Make_Line(out, 140, 120, 140, 150);
	Make_Line(out, 160, 120, 160, 150);
}

System::Void Make_Window(std::ofstream& out, int x, int y) {
	Make_Line(out, x, y, x, y - 30);
	Make_Line(out, x, y, x + 10, y);
	Make_Line(out, x + 10, y, x + 10, y - 30);
	Make_Line(out, x, y - 30, x + 10, y - 30);
}

System::Void Make_Balcon(std::ofstream& out, int x, int y) {
	Make_Line(out, x, y, x, y - 10);
	Make_Line(out, x, y, x + 30, y);
	Make_Line(out, x + 30, y, x + 30, y - 10);
	Make_Line(out, x, y - 10, x + 30, y - 10);
	Make_Line(out, x + 10, y - 10, x + 20, y - 10);
	Make_Line(out, x + 10, y - 10, x + 10, y - 30);
	Make_Line(out, x + 20, y - 10, x + 20, y - 30);
	Make_Line(out, x + 10, y - 30, x + 20, y - 30);
}

System::Void Make_Asset(std::ofstream& out, int x, int y) {
	Make_Line(out, x, y, x, y - 5);
	Make_Line(out, x, y, x + 40, y);
	Make_Line(out, x + 40, y, x + 40, y - 5);
	Make_Line(out, x, y - 5, x + 40, y - 5);
	Make_Line(out, x + 20, y - 5, x + 20, y - 20);
	Make_Line(out, x, y - 20, x + 20, y - 30);
	Make_Line(out, x + 40, y - 20, x + 20, y - 30);
	Make_Line(out, x, y - 20, x + 40, y - 20);
}

System::Void Fill_Coordinates_File(std::ofstream& out) {
	Make_House(out);
	Make_Window(out, 100, 140);
	Make_Window(out, 180, 140);
	Make_Balcon(out, 90, 90);
	Make_Balcon(out, 130, 90);
	Make_Balcon(out, 170, 90);
	Make_Balcon(out, 90, 40);
	Make_Balcon(out, 130, 40);
	Make_Balcon(out, 170, 40);
	Make_Asset(out, 20, 150);
}